using System;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Lab2_QaddarShabbar
{ 
    public class Entry : ObservableObject 
    {
        String clue;
        String answer;
        String date;

        int difficulty;
        int id;

        
        public String Clue { get { return clue; } set { SetProperty(ref clue, value); } }
        public String Answer { get { return answer; } set { SetProperty(ref answer, value); } }
        public String CurrentDate { get { return date; } set { SetProperty(ref date, value); } }
        public int Difficulty { get { return difficulty; } set { SetProperty(ref difficulty, value); } }
        public int Id { get { return id; } set { SetProperty(ref id, value); } }

        public Entry(String clue, String answer, int difficulty, String date, int id)
        {
            this.answer = answer;
            this.clue = clue;
            this.difficulty = difficulty;
            this.date = date;
            this.id = id;
        }
    }
}
