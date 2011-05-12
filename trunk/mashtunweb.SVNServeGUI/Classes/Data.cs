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
using System.Collections.ObjectModel;
using System.Collections.Generic;
namespace mashtunweb.SVNServeGUILite
{
    public class Data
    {
        public Data()
        {
            Users = new ObservableCollection<KeyValuePair<string, string>>();
        }

        public ObservableCollection<KeyValuePair<string, string>> Users { get; private set; }
    }
}