using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.IO;
using System.Diagnostics;
using System.Reflection;

namespace mashtunweb.SVNServeGUILite.Classes
{
    public static class AppVersion
    {

        public static String Number { get; private set; }
        public static String CompanyName { get; private set; }
        public static String Copywrite { get; private set; }

        private static string[] _aRevHeaders = {"$WCREV$", 
                        "$WCDATE$", 
                        "$WCNOW$", 
                        "$WCRANGE$", 
                        "$WCMIXED$", 
                        "$WCMODS$", 
                        "$WCURL$", 
                        "$WCNOW$", 
                        "$WCINSVN?Versioned:Not Versioned$", 
                        "$WCNEEDSLOCK$", 
                        "$WCISLOCKED$", 
                        "$WCLOCKDATE$", 
                        "$WCLOCKOWNER$", 
                        "$WCLOCKCOMMENT$"};

        private static string[] _aRevData = { "0", "", "", "", "", "", "", "", "", "", "", "", "", "", "" };
        
        // Input file containing the SubWcRev keywords
        private static string _strTemplateFile = "svntemplate.txt";

        // Output file that will contain the SVN revisions after calling SubWcRev.exe
        private static string _strRevOutputFile = "svnrev.txt";

        static AppVersion()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            FileVersionInfo fileInfo = FileVersionInfo.GetVersionInfo(assembly.Location);
            AssemblyName assemblyName = assembly.GetName();


            Number = assembly.GetName().Version.ToString();
            CompanyName = fileInfo.CompanyName;
            Copywrite = fileInfo.LegalCopyright;

            if (InIDE())
            {

                // Read and write to the svnrevisions text file so that it forces subversion to update 
                // the file with the latest revision - there are no global revisions keyword so this 
                // is an alternative!
                try
                {
                    SvnGetlatestRev();
                    // Create and read the svn revision file
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                //dirty
                string[] strVersion = Number.Split('.');
                Number = string.Format("{0}.{1}.{2}.{3}", strVersion[0],
                                                  strVersion[1], strVersion[2], _aRevData[0]);
                SetApplicationVersionSetting();
            }
            Number = Properties.Settings.Default.Version;
        }

        private static void SetApplicationVersionSetting()
        {
            DirectoryInfo dirInfo = new DirectoryInfo(Application.ExecutablePath);
            DirectoryInfo dirinfoSourceWorkingDir;
            dirinfoSourceWorkingDir = dirInfo.Parent.Parent.Parent;
            string strSourceWorkingDir = dirinfoSourceWorkingDir.FullName + "\\Properties\\";

            StreamReader reader = new StreamReader(strSourceWorkingDir + "Settings.Designer.cs");
            string content = reader.ReadToEnd();
            reader.Close();

            content = Regex.Replace(content, "DefaultSettingValueAttribute\\(\\\"\\d+\\.\\d+\\.\\d+\\.\\d+\\\"\\)\\]"
                , "DefaultSettingValueAttribute(\""+Number+"\")]");

            StreamWriter writer = new StreamWriter(strSourceWorkingDir + "Settings.Designer.cs");
            writer.Write(content);
            writer.Close();
        }

        private static void SvnGetlatestRev()
        {
            // If we are running as an exe (i.e. not in the Visual Studio IDE) 
            // then we dont want to create the revisions but read what 
            // is already there. This assumes that the exe is being used 
            // on a non-subversion machine

            // Check for the IDE, True is it is or false if it is not 
            // (assume false is running as an exe)
            if (InIDE())
            {

                // Get the working directory of the application exe - not the most 
                // glamourous way to do this so need to rethink this!!!
                DirectoryInfo dirInfo = new DirectoryInfo(Application.ExecutablePath);
                DirectoryInfo dirinfoSourceWorkingDir;
                dirinfoSourceWorkingDir = dirInfo.Parent.Parent.Parent;
                string strSourceWorkingDir = dirinfoSourceWorkingDir.FullName;

                // The template file is a text file containing some keyword that are ~
                // recognised by SubWcRev.exe when it 
                // is run against the root project directory.
                // Creates the template file is it is not already there
                SvnCreateTemplate();

                // Now create a process to run the SubWcRec.exe
                try
                {
                    Process p = new Process();

                    {
                        p.StartInfo.UseShellExecute = true;
                        p.StartInfo.FileName = "subwcrev.exe";
                        p.StartInfo.Arguments = "\"" + strSourceWorkingDir +
                                                "\" \"" + _strTemplateFile + "\" \"" +
                                                _strRevOutputFile + "\"";
                        p.StartInfo.UseShellExecute = false;
                        p.StartInfo.RedirectStandardOutput = true;
                    }


                    // Execute the process and wait for it to exit
                    if (p.Start())
                    {
                        string output = p.StandardOutput.ReadToEnd();
                        Console.WriteLine(output);

                        p.WaitForExit();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    // Probably because Subversion not installed and SubWcRev.exe was not found
                }

            }
            // The revison should now be available in the output file - reading this 
            // will get the revision
            // There are three lines (Rev, Modifed status and Rev Date) 
            string strContents = "";
            StreamReader objReader;
            try
            {

                objReader = new StreamReader(_strRevOutputFile);
                strContents = objReader.ReadToEnd();
                objReader.Close();

                // Get the revision from the contents of the file
                _aRevData = strContents.Split(Environment.NewLine.ToCharArray());
            }

            catch (Exception Ex)
            {
                Console.WriteLine(Ex.Message);
                // Probably because Subversion is not installed or this project 
                // has not been checked into
                // subversion yet. You muct make sure it is checked in to create a revision
                if (System.Diagnostics.Debugger.IsAttached)
                {
                    MessageBox.Show(Ex.Message + Environment.NewLine + Environment.NewLine +
                    "This is probably because this project is not under subversion " +
                    "revision control yet or the output file was not " +
                    "created by \"subwcrev.exe\"");
                }
                else
                {
                    MessageBox.Show(Ex.Message + Environment.NewLine + Environment.NewLine +
                                    "This is probably because the output file \"svnrev.txt\" " +
                                    "has not been created yet - need run this using the " +
                                    "Visual Studio IDE first to create the svnrev.txt file " +
                                    "containing the SVN values!");
                }

                _aRevData[0] = "\"svnrev.txt\" file not Found";
            }
        }

        private static void SvnCreateTemplate()
        {
            StreamWriter objReader;
            string strData;

            strData = "$WCREV$" + Environment.NewLine +
                      "$WCDATE$" + Environment.NewLine +
                      "$WCNOW$" + Environment.NewLine +
                      "$WCRANGE$" + Environment.NewLine +
                      "$WCMIXED?Mixed update revision:Not mixed$" + Environment.NewLine +
                      "$WCMODS?Modified:Not modified$" + Environment.NewLine +
                      "$WCURL$" + Environment.NewLine +
                      "$WCNOW$" + Environment.NewLine +
                      "$WCINSVN?Versioned:Not Versioned$" + Environment.NewLine +
                      "$WCNEEDSLOCK?Lock Required:Lock not required$" + Environment.NewLine +
                      "$WCISLOCKED?Locked:Not Locked$" + Environment.NewLine +
                      "$WCLOCKDATE$" + Environment.NewLine +
                      "$WCLOCKOWNER$" + Environment.NewLine +
                      "$WCLOCKCOMMENT$" + Environment.NewLine;
            try
            {
                objReader = new StreamWriter(_strTemplateFile);
                objReader.Write(strData);
                objReader.Close();
            }
            catch (Exception Ex)
            {
                Console.WriteLine(Ex.Message);
            }
        }

        private static bool InIDE()
        {
            return System.Diagnostics.Debugger.IsAttached;
        }
    }
}