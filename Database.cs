using System;
using System.IO;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq.Expressions;
using System.Text.Json;

namespace Lab2_QaddarShabbar
{
    public class Database : IDatabase
    {

        String appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

        JsonSerializerOptions options;
        string fileName;

        public ObservableCollection<Entry> entries;
        public List<Entry> entriesList;

        public ObservableCollection<Entry> AllEntries
        {
            get { return entries; }
            set { entries = value; }
        }
        public Database()
        {
            fileName = $"{appDataPath}/clues.db"; // added new 
            options = new JsonSerializerOptions { WriteIndented = true }; // added new
            entries = GetEntries();

        }



        public Boolean Add(string clue, string answer, int difficulty, string date)
        {


            int id = 0;
            Entry entry = new Entry(clue, answer, difficulty, date, id++);


            try
            {
                entries.Add(entry);

                string jsonString = JsonSerializer.Serialize(entries, options);
                File.WriteAllText(fileName, jsonString);
                return true;

            }
            catch (IOException ioe)
            {
                Console.WriteLine(ioe.ToString());
            }

            return false;


        }

        public Boolean Delete(Entry entry)
        {

            try
            {
                entries.Remove(entry);

                string jsonString = JsonSerializer.Serialize(entries, options);
                File.WriteAllText(fileName, jsonString);
                return true;

            }
            catch (IOException ioe)
            {
                Console.WriteLine(ioe.ToString());
            }

            return false;


        }

        public Boolean Edit(Entry entry, string clue, string answer, string date, int difficulty)
        {
            int currentEntryIndex = entries.IndexOf(entry);

            entries[currentEntryIndex].Clue = clue;
            entries[currentEntryIndex].Answer = answer;
            entries[currentEntryIndex].CurrentDate = date;
            entries[currentEntryIndex].Difficulty = difficulty;

            try
            {
                string jsonString = JsonSerializer.Serialize(entries, options);
                File.WriteAllText(fileName, jsonString);
                return true;
            }
            catch (IOException ioe)
            {
                Console.WriteLine("Error while replacing entry: {0}", ioe);
            }

            return false;



        }

        public ObservableCollection<Entry> GetEntries()
        {

            if (!File.Exists(fileName))
            {
                File.CreateText(fileName);
                entries = new ObservableCollection<Entry>();
                return entries;

            }

            string jsonString = File.ReadAllText(fileName);

            if (jsonString.Length > 0)
            {
                
                entries = JsonSerializer.Deserialize<ObservableCollection<Entry>>(jsonString);

            }
            else
            {
                entries = new ObservableCollection<Entry>();
            }

            return entries;

        }

    }
}
