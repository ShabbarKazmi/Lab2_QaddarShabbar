using System.Text.Json;

namespace Lab2_QaddarShabbar;

public partial class MainPage : ContentPage
{

    public string userClue = null;
    public string userAnswer = null;
    public string userDate = null;
    public int userDifficulty = -1;

    public Businesslogic bl;

    public MainPage()
	{
		InitializeComponent();
        bl = new Businesslogic();
        EntriesLV.ItemsSource = bl.db.AllEntries;
    }

    // Clue Entry object
    private void ClueCompleted(object sender, EventArgs e)
    {
        userClue = Clue.Text;
    }
    
    private void ClueTextChanged(object sender, TextChangedEventArgs e)
    {
        userClue = Clue.Text;
    }

    //Answer Entry 
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


    //Date Picker object
    void OnDateSelected(object sender, DateChangedEventArgs args)
    {
        userDate = (((DatePicker)sender).Date.ToString("d"));
    }


    //On Add button. Checks if the entry is valid and then gives a popup accordingly

    async void  onAdd(System.Object sender, System.EventArgs e)
    {
        if (bl.onAdd(userClue, userAnswer, userDate, userDifficulty))
        {
            await DisplayAlert("Add","Entry has been successfully added", "Ok");
        }
        else
        {
           await DisplayAlert("Add","There was an error in adding current entry. Please make sure Date is Selected and All fields are filled", "Ok");
        }

    }

    //On Delete. Checks if the entry is valid and then gives a popup accordingly
    async void onDelete(System.Object sender, System.EventArgs e)
    {
        int idToDelete;
        
        Entry Selected = (Entry)EntriesLV.SelectedItem;
        if ( Selected is not null)
        {
            idToDelete = Selected.Id;

            if (bl.onDelete(idToDelete))
            {
                await DisplayAlert("Delete", "Entry Deleted sucessfully ", "Ok");
            }
            else
            {
                await DisplayAlert("Delete", "There was an error in adding current entry. Please try again", "Ok");
            }
        }
        else
        { 
            await DisplayAlert("Delete", "Please Select ID to Delete", "Ok"); 
        }
            
         

    }

    //On Edit button. Checks if the entry is valid and then gives a popup accordingly.
    async void onEdit(System.Object sender, System.EventArgs e) 
    {

        int idToEdit;
        Entry Selected = (Entry)EntriesLV.SelectedItem;

        if (Selected is not null) 
        {
            idToEdit = Selected.Id;

            if (bl.onEdit(idToEdit, userClue, userAnswer, userDate, userDifficulty))
            {

                await DisplayAlert("Edit", "Entry was Edited Sucessfully ", "Ok");
            }
            else
            {
                await DisplayAlert("Edit", "There was an error in editing current entry. Please try again", "Ok");
            }
        } else
        {
            await DisplayAlert("Edit", "Please Select ID to Edit", "Ok");
        }

    }   
}

