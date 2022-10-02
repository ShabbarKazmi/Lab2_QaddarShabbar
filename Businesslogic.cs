using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2_QaddarShabbar
{
    public class Businesslogic : IBusinesslogic
    {
        public IDatabase db;


        public Businesslogic()
        {
            db = new Database();
        }


        //checks if all the parameters are filled and returns boolean to signify if it is a valid add
        public Boolean onAdd(String clue, String answer, String date, int difficulty)
        {
            if (clue is not null && answer is not null && date is not null &&
            difficulty != -1 && db.Add(clue, answer, difficulty, date))
            {
                return true;
            }
            return false;
        }


        //checks if the id selected is valid and then returns a boolean to check if it is a valid Delete
        public Boolean onDelete(int id)
        {
            Entry entryToDelete = getEntry(id);

            if (entryToDelete is not null && db.Delete(entryToDelete))
            {
                return true;
            }
            return false;
        }


        //checks if the id selected is valid, and also checks if all the inputs are valid and
        //then returns a boolean to signify edit
        public Boolean onEdit(int id, string clue, string answer, string date, int difficulty)
        {
            Entry entryToEdit = getEntry(id);

            if (clue is not null && answer is not null && date is not null &&
            difficulty != -1 && db.Add(clue, answer, difficulty, date) &&
            entryToEdit is not null && db.Edit(entryToEdit, clue, answer, date, difficulty))
            {
                return true;
            }
            return false;
        }


        // method to see if the entry with specified ID is in the collection or not.
        // returns entry if the entry is found otherwise it return null
        public Entry getEntry(int id)
        {
            foreach (Entry entry in db.AllEntries)
            {
                if (entry.Id == id)
                {
                    return entry;
                }
            }
            return null;

        }
    }
}
