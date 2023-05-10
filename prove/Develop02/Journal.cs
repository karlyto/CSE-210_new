using System;
using System.Collections.Generic;
using System.IO;

namespace DailyJournal
{
    class Journal
    {
        private List<Entry> entries;
        private readonly string[] prompts = {
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "What was the most hardest task you had to do today?",
            "How did I see the hand of the Lord in my life today?",
            "What was the strongest emotion I felt today?",
            "If I had one thing I could do over today, what would it be?",
            "What is your favorite character from the holy scriptures?"
        };

        public Journal()
        {
            entries = new List<Entry>();
        }

        public void AddEntry()
        {
            Random rand = new Random();
            string prompt = prompts[rand.Next(prompts.Length)];
            Console.WriteLine(prompt);

            string response = Console.ReadLine();

            Entry entry = new Entry(prompt, response, DateTime.Now.ToString());
            entries.Add(entry);

            Console.WriteLine("You have successfully added an entry.");
        }

        public void DisplayEntries()
        {
            foreach (Entry entry in entries)
            {
                Console.WriteLine(entry);
            }
        }

        public void SaveEntries()
        {
            Console.Write("What is the filename?: ");
            string filename = Console.ReadLine();

            using (StreamWriter writer = new StreamWriter(filename))
            {
                foreach (Entry entry in entries)
                {
                    writer.WriteLine(entry);
                }
            }

            Console.WriteLine("Entries saved successfully.");
        }

        public void LoadEntries()
        {
            Console.Write("Please enter a filename to load from: ");
            string filename = Console.ReadLine();

            List<Entry> loadedEntries = new List<Entry>();

            using (StreamReader reader = new StreamReader(filename))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split(',');
                    Entry entry = new Entry(parts[0], parts[1], parts[2]);
                    loadedEntries.Add(entry);
                }
            }

            entries = loadedEntries;

            Console.WriteLine("Entries loaded successfully.");
        }
    }
}