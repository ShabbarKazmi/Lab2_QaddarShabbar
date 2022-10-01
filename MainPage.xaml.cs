using System.Text.Json;

namespace Lab2_QaddarShabbar;

public partial class MainPage : ContentPage
{

    public String userClue = null;
    public String userAnswer = null;
    public String userDate = null;
    public int userDifficulty = -1;
    public int id = 0;
    
    // MauiProgram.crossword.AllEntries.Last().Id;


    public MainPage()
	{
		InitializeComponent();
        EntriesLV.ItemsSource = MauiProgram.crossword.AllEntries;
    }

    // Clue Field 
    private void ClueCompleted(object sender, EventArgs e)
    {
        userClue = Clue.Text;
    }
    
    private void ClueTextChanged(object sender, TextChangedEventArgs e)
    {
        userClue = Clue.Text;
    }

    //Answer Field 
    private void AnswerTextChanged(object sender, TextChangedEventArgs e)
    {
        userAnswer = Answer.Text;
    }
    private void AnswerCompleted(object sender, EventArgs e)

    {
        userAnswer = Answer.Text;
    }

    private void DifficultyCompleted(object sender, EventArgs e)
    {
        
        int changedDifficulty = Int32.Parse(Difficulty.Text);
        
        if (changedDifficulty < 4 && changedDifficulty > 0)
        {
             userDifficulty = changedDifficulty;
        }
        else
        {
            DisplayAlert("Invalid Difficulty", "Please make sure difficulty is within range (1-3", "Ok");
        }

        
    }

    void OnDateSelected(object sender, DateChangedEventArgs args)
    {
        userDate = (((DatePicker)sender).Date.ToString("d"));
    }


    async void  onAdd(System.Object sender, System.EventArgs e)
    {
        if ()
        {

            MauiProgram.crossword.AllEntries.Add(new Entry(userClue, userAnswer, userDifficulty, userDate, ++id));

        }
        else
        {
            await DisplayAlert("Invalid Entry", "Please make sure difficulty is within range (1-3)", "Ok");
        }
          
    }

    async void onDelete(System.Object sender, System.EventArgs e)
    {
        string id = await DisplayPromptAsync("Edit Entry", "Enter Id of entry:", keyboard: Keyboard.Numeric);

        int IdToDetle = Int32.Parse(id);


        
          Entry entryToDelete = getEntry(IdToDetle);

          if (entryToDelete is not null)
          {

              MauiProgram.crossword.AllEntries.Remove(entryToDelete);
          }
          else
          {
             await DisplayAlert("Invalid Entry", "Please make sure difficulty is within range (1-3)", "Ok");
          }
        


    }

    async void onEdit(System.Object sender, System.EventArgs e) 
    {

        string userEditId = await DisplayPromptAsync("Edit Entry", "Enter Id of entry:", keyboard: Keyboard.Numeric);

        Entry editEntry = getEntry(Int32.Parse(userEditId));

        if (editEntry is not null)
        {
            int editId = MauiProgram.crossword.AllEntries.IndexOf(editEntry);

            String editClue = await DisplayPromptAsync("Edit Entry", "Enter new Clue:", keyboard: Keyboard.Text);
            String editAnswer = await DisplayPromptAsync("Edit Entry", "Enter new Answer:", keyboard: Keyboard.Text);
            String editDifficulty = await DisplayPromptAsync("Edit Entry", "Enter new Difficulty:", keyboard: Keyboard.Numeric);
            String editdate = await DisplayPromptAsync("Edit Entry", "Enter new date:", keyboard: Keyboard.Text);


            MauiProgram.crossword.AllEntries[editId].Clue = editClue;
            MauiProgram.crossword.AllEntries[editId].Answer = editAnswer;
            MauiProgram.crossword.AllEntries[editId].CurrentDate = editdate;
            MauiProgram.crossword.AllEntries[editId].Difficulty = Int32.Parse(editDifficulty);

            await DisplayAlert("Edit Entry", "Entry was edited successfully", "Ok");
        }
        else
        {
            await DisplayAlert("Edit Entry", "Entry was not found, Please enter valid Id", "Ok");
        }

    }
       public Entry getEntry(int id)
       {

            foreach (Entry entry in MauiProgram.crossword.AllEntries)
            {
                if (entry.Id == id)
                {
                    return entry;
                }
            }
            return null;
        
        }
    
}

