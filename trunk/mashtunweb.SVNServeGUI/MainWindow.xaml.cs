using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using SCNServeGUI.Actions;
using System.Diagnostics;
using System.IO;
using System.Collections.ObjectModel;
using System.Threading;
using mashtunweb.SVNServeGUILite.Classes;

namespace mashtunweb.SVNServeGUILite
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Process _svnserveProcess;
        private Process _svnadminProcess;
        private bool _svnserveRunning = false;
        private ObjectDataProvider _dataObject;
        private Data _data;

        public MainWindow()
        {
            InitializeComponent();

            // Enable "minimize to tray" behavior for this Window
            MinimizeToTray.Enable(this, "SVN Gui is still running in the background.");
            Console.WriteLine(AppVersion.Number);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _svnserveProcess = new Process();
            _svnserveProcess.StartInfo.UseShellExecute = false;
            _svnserveProcess.StartInfo.RedirectStandardOutput = true;
            _svnserveProcess.StartInfo.FileName = Properties.Settings.Default.SVNServeExePath;
            _svnserveProcess.StartInfo.Arguments = "-d";
            _svnserveProcess.StartInfo.CreateNoWindow = true;

            _data = new Data();

            _dataObject = (ObjectDataProvider)FindResource("Data");
            _dataObject.ObjectInstance = _data;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (_svnserveRunning)
            {
                _svnserveProcess.Kill();
            }
        }

        #region Click Event Handlers
        private void CloseMenuItem_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void playButton_Click(object sender, RoutedEventArgs e)
        {
            if (_svnserveRunning)
            {
                _svnserveProcess.Kill();
            }
            _svnserveProcess.Start();
            if (!_svnserveProcess.HasExited)
            {
                _svnserveRunning = true;
                setPlayButtonImage("Images/svn-restart.png");
            }
            else
            {
                //oops
            }
        }

        private void stopButton_Click(object sender, RoutedEventArgs e)
        {
            if (_svnserveRunning)
            {
                setPlayButtonImage("Images/svn-start.png");
                _svnserveProcess.Kill();
                _svnserveRunning = false;
            }
        }

        private void setPlayButtonImage(string imagePath)
        {
            BitmapImage logo = new BitmapImage();
            logo.BeginInit();
            logo.UriSource = new Uri("pack://application:,,,/" + imagePath);
            logo.EndInit();
            playButtonImage.Source = logo;
        }
        #endregion

        private void _addUserButton_Click(object sender, RoutedEventArgs e)
        {
            _data.Users.Add(new KeyValuePair<string, string>(_userNameBox.Text, _passwordBox.Password));
            _userNameBox.Text = "";
            _passwordBox.Password = "";
        }

        private void _removeUserButton_Click(object sender, RoutedEventArgs e)
        {
            _data.Users.Remove((KeyValuePair<string, string>)_userListBox.SelectedItem);
        }

        private void _createRepoButton_Click(object sender, RoutedEventArgs e)
        {
            ThreadPool.QueueUserWorkItem(new WaitCallback(runAdminProcess),
                new object[] { ((ComboBoxItem)_fsComboBox.SelectedItem).Content, _pathTextBox.Text, });
        }

        private void runAdminProcess(object state)
        {
            string value = (string)((object[])state)[0];
            string path = (string)((object[])state)[1];
            this.Dispatcher.Invoke(System.Windows.Threading.DispatcherPriority.Normal, new System.Action(
                delegate() { _createRepoButton.IsEnabled = false; }
            ));
            try
            {
                this.Dispatcher.Invoke(System.Windows.Threading.DispatcherPriority.Normal, new System.Action(
                    delegate() { _progressBar.Value = 0; }
                ));
                _svnadminProcess = new Process();
                _svnadminProcess.StartInfo.UseShellExecute = false;
                _svnadminProcess.StartInfo.RedirectStandardOutput = true;
                _svnadminProcess.StartInfo.RedirectStandardError = true;
                _svnadminProcess.StartInfo.FileName = Properties.Settings.Default.SVNAdminExePath;
                _svnadminProcess.StartInfo.Arguments = "create --fs-type " +
                    value + " " + path;
                _svnserveProcess.StartInfo.CreateNoWindow = true;
                this.Dispatcher.Invoke(System.Windows.Threading.DispatcherPriority.Normal, new System.Action(
                    delegate() { _progressBar.Value = 25; }
                ));
                _svnadminProcess.Start();
                _svnadminProcess.WaitForExit();
                this.Dispatcher.Invoke(System.Windows.Threading.DispatcherPriority.Normal, new System.Action(
                    delegate() { _progressBar.Value = 50; }
                ));

                if (Directory.Exists(path + "/conf"))
                {
                    if (_data.Users.Count > 0)
                    {
                        TextWriter passwdStream = new StreamWriter(path + "/conf/passwd");
                        passwdStream.WriteLine(Properties.Settings.Default.passwdFile);
                        this.Dispatcher.Invoke(System.Windows.Threading.DispatcherPriority.Normal, new System.Action(
                            delegate() { _progressBar.Value = 60; }
                        ));
                        foreach (KeyValuePair<string, string> pair in _data.Users)
                        {
                            passwdStream.WriteLine(pair.Key + " = " + pair.Value);
                        }
                        passwdStream.Close();
                    }

                    TextWriter svnserveconf = new StreamWriter(path + "/conf/svnserve.conf");
                    this.Dispatcher.Invoke(
                        System.Windows.Threading.DispatcherPriority.Normal, new System.Action(
                         delegate() { _progressBar.Value = 70; }
                     ));

                    int lastIndex = path.LastIndexOf("\\");

                    string reponame = path.Substring(lastIndex+1);

                    svnserveconf.WriteLine(
                        Properties.Settings.Default.svnserveconf.Replace("!!REPOSITORYNAME!!", reponame));

                    svnserveconf.Close();
                }
                this.Dispatcher.Invoke(System.Windows.Threading.DispatcherPriority.Normal, new System.Action(
                    delegate() { _progressBar.Value = 100; }
                ));
                this.Dispatcher.Invoke(System.Windows.Threading.DispatcherPriority.Normal, new System.Action(
                    delegate()
                    {
                        _statusLabel.Content = "Status: Finished building repository at " + path;
                    }
                ));
            }
            catch (Exception)
            {
                this.Dispatcher.Invoke(System.Windows.Threading.DispatcherPriority.Normal, new System.Action(
                    delegate()
                    {
                        _statusLabel.Content = "Status: Error building repository at " + path;
                    }
                ));
            }
            finally
            {
                this.Dispatcher.Invoke(System.Windows.Threading.DispatcherPriority.Normal, new System.Action(
                    delegate() { _createRepoButton.IsEnabled = true; }
                ));
                this.Dispatcher.Invoke(System.Windows.Threading.DispatcherPriority.Normal, new System.Action(
                    delegate() { _progressBar.Value = 0; }
                ));
            }
        }
    }
}
