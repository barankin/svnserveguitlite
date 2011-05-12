
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