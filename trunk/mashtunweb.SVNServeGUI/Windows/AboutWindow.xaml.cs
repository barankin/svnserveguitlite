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
using System.Windows.Shapes;
using System.Reflection;
using System.Diagnostics;

namespace mashtunweb.SVNServeGUILite.Windows
{
    /// <summary>
    /// Interaction logic for AboutWindow.xaml
    /// </summary>
    public partial class AboutWindow : Window
    {
        public AboutWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            FileVersionInfo fileInfo = FileVersionInfo.GetVersionInfo(Assembly.GetAssembly(GetType()).Location);
            _companyLabel.Text = fileInfo.CompanyName;
            _copyrightLabel.Text = fileInfo.LegalCopyright;
        }

        private void _CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
