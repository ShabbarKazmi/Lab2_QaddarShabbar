using System.Collections.ObjectModel;
using System.Linq.Expressions;

namespace Lab2_QaddarShabbar
{
    public class Database
    {

        public ObservableCollection<Entry> entries = new ObservableCollection<Entry>();

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

        public Boolean Edit(Entry entry,String clue, String answer, String date, int difficulty)
        {
            int currentEntryIndex = entries.IndexOf(entry);

       
                entries[currentEntryIndex].Clue = clue;
                entries[currentEntryIndex].Answer = answer;
                entries[currentEntryIndex].CurrentDate = date;
                entries[currentEntryIndex].Difficulty = difficulty;
            


     
            return true;

        }

        public Boolean readFromFile()
        {
            return false;
        }

    }
}
