using System.Text.Json;

namespace Lab2_QaddarShabbar;

public partial class MainPage : ContentPage
{

    public String userClue = null;
    public String userAnswer = null;
    public String userDate = null;
    public int userDifficulty = -1;

    public Businesslogic bl;

    public MainPage()
	{
		InitializeComponent();
        bl = new Businesslogic();
        //EntriesLV.ItemsSource = MauiProgram.crossword.AllEntries;
        EntriesLV.ItemsSource = bl.db.AllEntries;
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
        
        userDifficulty = Int32.Parse(Difficulty.Text);
        
    }

    void OnDateSelected(object sender, DateChangedEventArgs args)
    {
        userDate = (((DatePicker)sender).Date.ToString("d"));
    }


    async void  onAdd(System.Object sender, System.EventArgs e)
    {
        if (bl.onAdd(userClue, userAnswer, userDate, userDifficulty))
        {
            await DisplayAlert("Add","Entry has been successfully added", "Ok");
        }
        else
        {
           await DisplayAlert("Add","There was an error in adding current entry.Please try again", "Ok");
        }

    }

    async void onDelete(System.Object sender, System.EventArgs e)
    {
        string id = await DisplayPromptAsync("Edit Entry", "Enter Id of entry:", keyboard: Keyboard.Numeric);

        int IdToDetle = Int32.Parse(id);

        if (bl.onDelete(IdToDetle))
        {
            await DisplayAlert("Delete", "Entry Deleted sucessfully ", "Ok");
        }
        else
        {
            await DisplayAlert("Delete", "There was an error in adding current entry.Please try again", "Ok");
        }
    }

    async void onEdit(System.Object sender, System.EventArgs e) 
    {

        /*
        string userEditId = await DisplayPromptAsync("Edit Entry", "Enter Id of entry:", keyboard: Keyboard.Numeric);

        int entryEditId = Int32.Parse(userEditId);

        if (bl.onEdit(entryEditId))
        {

            await DisplayAlert("Delete", "Entry Deleted sucessfully ", "Ok");
        }
        else
        {
            await DisplayAlert("Delete", "There was an error in adding current entry.Please try again", "Ok");
        }
        */


    }   
}

