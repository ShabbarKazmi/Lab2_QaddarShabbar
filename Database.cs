using System.Collections.ObjectModel;
using System.Linq.Expressions;

namespace Lab2_QaddarShabbar
{
    public class Database
    {

        private ObservableCollection<Entry> entries = new ObservableCollection<Entry>();

        public ObservableCollection<Entry> AllEntries
        {
            get { return entries; }
            set { entries = value; }
        }
        public Database()
        {
            GetEntries();
        }

        public ObservableCollection<Entry> GetEntries()
        {
            return AllEntries;
        }

        public Boolean Add(Entry entry) 
        {
            entries.Add(entry);
            return true;
        }

        public Boolean Delete(Entry entry)
        {
            entries.Remove(entry);
            return true;
        }

        public Boolean Edit(Entry entry)
        {
            int currentEntryIndex = entries.IndexOf(entry);

            return false;

        }

        public Boolean readFromFile()
        {
            return false;
        }

    }
}
