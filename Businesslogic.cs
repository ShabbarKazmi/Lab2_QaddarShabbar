using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2_QaddarShabbar
{
    public class Businesslogic
    {
        public Database db;
        

        public Businesslogic()
        {
            db = new Database();
        }
        
        public Boolean onAdd(String clue, String answer, String date ,int difficulty)
        {
            int id = 0;
            if ( clue is not null && answer is not null && date is not null &&
            difficulty != -1 && db.Add(new Entry(clue, answer, difficulty, date,++id)))
            { 
                return true;
            }
            return false;
        }

        public Boolean onDelete(int id)
        {
            Entry entryToDelete = getEntry(id);

            if (entryToDelete is not null && db.Delete(entryToDelete))
            {
                return true;
            }
            return false;
        }

        public Boolean onEdit(int id)
        {
            Entry entryToEdit = getEntry(id);

            if (entryToEdit is not null && db.Edit(entryToEdit))
            {
                return true;
            }
            return false;
        }

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
