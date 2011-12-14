/*This file is part of mashtunweb.SVNServeGUILite.

    mashtunweb.SVNServeGUILite is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    mashtunweb.SVNServeGUILite is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with mashtunweb.SVNServeGUILite.  If not, see <http://www.gnu.org/licenses/>.
 */
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.225
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace mashtunweb.SVNServeGUILite.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "10.0.0.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("C:/Program Files/SlikSvn/bin/svnserve.exe")]
        public string SVNServeExePath {
            get {
                return ((string)(this["SVNServeExePath"]));
            }
            set {
                this["SVNServeExePath"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("svnadmin")]
        public string SVNAdminExePath {
            get {
                return ((string)(this["SVNAdminExePath"]));
            }
            set {
                this["SVNAdminExePath"] = value;
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute(@"### This file is an example password file for svnserve.
### Its format is similar to that of svnserve.conf. As shown in the
### example below it contains one section labelled [users].
### The name and password for each user follow, one account per line.

[users]")]
        public string passwdFile {
            get {
                return ((string)(this["passwdFile"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("### This file controls the configuration of the svnserve daemon, if you\r\n### use " +
            "it to allow access to this repository.  (If you only allow\r\n### access through h" +
            "ttp: and/or file: URLs, then this file is\r\n### irrelevant.)\r\n\r\n### Visit http://" +
            "subversion.tigris.org/ for more information.\r\n\r\n[general]\r\n### These options con" +
            "trol access to the repository for unauthenticated\r\n### and authenticated users. " +
            " Valid values are \"write\", \"read\",\r\n### and \"none\".  The sample settings below a" +
            "re the defaults.\r\nanon-access = read\r\nauth-access = write\r\n### The password-db o" +
            "ption controls the location of the password\r\n### database file.  Unless you spec" +
            "ify a path starting with a /,\r\n### the file\'s location is relative to the direct" +
            "ory containing\r\n### this configuration file.\r\n### If SASL is enabled (see below)" +
            ", this file will NOT be used.\r\n### Uncomment the line below to use the default p" +
            "assword file.\r\npassword-db = passwd\r\n### The authz-db option controls the locati" +
            "on of the authorization\r\n### rules for path-based access control.  Unless you sp" +
            "ecify a path\r\n### starting with a /, the file\'s location is relative to the the\r" +
            "\n### directory containing this file.  If you don\'t specify an\r\n### authz-db, no " +
            "path-based access control is done.\r\n### Uncomment the line below to use the defa" +
            "ult authorization file.\r\n# authz-db = authz\r\n### This option specifies the authe" +
            "ntication realm of the repository.\r\n### If two repositories have the same authen" +
            "tication realm, they should\r\n### have the same password database, and vice versa" +
            ".  The default realm\r\n### is repository\'s uuid.\r\nrealm = !!REPOSITORYNAME!!\r\n\r\n[" +
            "sasl]\r\n### This option specifies whether you want to use the Cyrus SASL\r\n### lib" +
            "rary for authentication. Default is false.\r\n### This section will be ignored if " +
            "svnserve is not built with Cyrus\r\n### SASL support; to check, run \'svnserve --ve" +
            "rsion\' and look for a line\r\n### reading \'Cyrus SASL authentication is available." +
            "\'\r\n# use-sasl = true\r\n### These options specify the desired strength of the secu" +
            "rity layer\r\n### that you want SASL to provide. 0 means no encryption, 1 means\r\n#" +
            "## integrity-checking only, values larger than 1 are correlated\r\n### to the effe" +
            "ctive key length for encryption (e.g. 128 means 128-bit\r\n### encryption). The va" +
            "lues below are the defaults.\r\n# min-encryption = 0\r\n# max-encryption = 256")]
        public string svnserveconf {
            get {
                return ((string)(this["svnserveconf"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("0.1.0.10")]
        public string Version {
            get {
                return ((string)(this["Version"]));
            }
        }
    }
}
