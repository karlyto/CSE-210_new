using System;
using System.Collections.Generic;
using System.IO;
using System.Data.SqlClient;
using Newtonsoft.Json;

namespace JournalProgram
{
    class Journal
    {
        private List<Entry> entries;
        private List<string> prompts;

        public Journal()
        {
            entries = new List<Entry>();
            prompts = new List<string>();
            prompts.Add("Who was the most interesting person I interacted with today?");
            prompts.Add("What was the best part of my day?");
            prompts.Add("How did I see the hand of the Lord in my life today?");
            prompts.Add("What was the strongest emotion I felt today?");
            prompts.Add("If I had one thing I could do over today, what would it be?");
        }

        public void WriteEntry()
        {
            Random rnd = new Random();
            int index = rnd.Next(prompts.Count);
            string prompt = prompts[index];

            Console.WriteLine($"\n{prompt}");
            string response = Console.ReadLine();

            Console.WriteLine("\nEnter any other information you would like to save (optional):");
            string otherInfo = Console.ReadLine();

            Entry entry = new Entry(prompt, response, otherInfo);
            entries.Add(entry);

            Console.WriteLine("\nEntry saved!");
        }

        public void DisplayEntries()
        {
            if (entries.Count == 0)
            {
                Console.WriteLine("\nThere are no entries to display!");
                return;
            }

            Console.WriteLine("\nJournal Entries:");
            foreach (Entry entry in entries)
            {
                Console.WriteLine($"Date: {entry.Date}");
                Console.WriteLine($"Prompt: {entry.Prompt}");
                Console.WriteLine($"Response: {entry.Response}");
                if (!string.IsNullOrEmpty(entry.OtherInfo))
                {
                    Console.WriteLine($"Other Information: {entry.OtherInfo}");
                }
                Console.WriteLine();
            }
        }

        public void LoadEntries()
        {
            Console.Write("\nEnter the filename to load from: ");
            string filename = Console.ReadLine();

            if (!File.Exists(filename))
            {
                Console.WriteLine("\nFile does not exist!");
                return;
            }

            string json = File.ReadAllText(filename);
            entries = JsonConvert.DeserializeObject<List<Entry>>(json);

            Console.WriteLine("\nEntries loaded!");
        }

        public void SaveToCSV()
        {
            if (entries.Count == 0)
            {
                Console.WriteLine("\nThere are no entries to save!");
                return;
            }

            Console.Write("\nEnter the filename to save to: ");
            string filename = Console.ReadLine
