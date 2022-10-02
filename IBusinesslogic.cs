namespace Lab2_QaddarShabbar
{
    public interface IBusinesslogic
    {
        Entry getEntry(int id);
        bool onAdd(string clue, string answer, string date, int difficulty);
        bool onDelete(int id);
        bool onEdit(int id, string clue, string answer, string date, int difficulty);
    }
}