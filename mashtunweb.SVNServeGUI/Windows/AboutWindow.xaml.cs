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

        private void Hyperlink_RequestNavigate(object sender, System.Windows.Navigation.RequestNavigateEventArgs e)
        {
            try
            {
                Process.Start(new ProcessStartInfo(e.Uri.ToString()));
            }
            catch (Exception)
            {
            }
            finally
            {

                e.Handled = true;
            }
        }
    }
}
