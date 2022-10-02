using System.Collections.ObjectModel;

namespace Lab2_QaddarShabbar
{
    public interface IDatabase
    {
        ObservableCollection<Entry> AllEntries { get; set; }

        bool Add(string clue, string answer, int difficulty, string date);
        bool Delete(Entry entry);
        bool Edit(Entry entry, string clue, string answer, string date, int difficulty);
        ObservableCollection<Entry> GetEntries();
    }
}