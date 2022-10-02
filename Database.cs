using System;
using System.IO;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq.Expressions;
using System.Text.Json;


/**
 * 
 * 
 */

namespace Lab2_QaddarShabbar
{
    public class Database : IDatabase
    {
        // enviroment where to save the folder 
        String appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

        //initilization of the JsonSerializer
        JsonSerializerOptions options;
        string fileName;

        public ObservableCollection<Entry> entries;

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


        // adds the entry and writes it to the json text file 
        public Boolean Add(string clue, string answer, int difficulty, string date)
        {


            int id = entries.Count//0;
            Entry entry = new Entry(clue, answer, difficulty, date,++id);


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

        // adds the entry and writes it to the json text file 
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

        // checks the index of the entry and makes changes to appropriate entry.
        // saves to file after the entry is edited
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

        // checks if text file exists if it does it return a collection with the items from the file
        // otherwise it creates a new observable collection. 
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
