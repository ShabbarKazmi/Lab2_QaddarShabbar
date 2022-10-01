using System.Collections.ObjectModel;

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
            async void onAdd(System.Object sender, System.EventArgs e)
            {
                if (userClue is not null && userAnswer is not null && userDate is not null &&
                     userDifficulty != -1 && id != -1)
                {

                    MauiProgram.crossword.AllEntries.Add(new Entry(userClue, userAnswer, userDifficulty, userDate, ++id));
                    return false;
                }
                else
                {
                    await DisplayAlert("Invalid Entry", "Please make sure difficulty is within range (1-3)", "Ok");
                    
                }

                return false;

            }
            
        }

        public Boolean Delete(Entry entry)
        {
            return false;
        }

        public Boolean readFromFile()
        {
            return false;
        }

    }
}
