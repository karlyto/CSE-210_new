using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        ScriptureLoader scriptureLoader = new ScriptureLoader();
        List<BibleScripture> scriptures = scriptureLoader.LoadScripturesFromFile("bible_scriptures.txt");

        Console.WriteLine("Scripture Memorizing");
        Console.WriteLine("-^-^-^-^-^-^-^-^-^-^-^-^-^-^-^-^-^-^-^-");

        Random random = new Random();

        while (scriptures.Count > 0)
        {
            int randomIndex = random.Next(scriptures.Count);
            BibleScripture scripture = scriptures[randomIndex];
            scriptures.RemoveAt(randomIndex);

            while (!scripture.AllWordsHidden)
            {
                Console.WriteLine(scripture.GetHiddenText());
                Console.WriteLine("Press Enter to continue or type 'quit' to finish.");

                string input = Console.ReadLine().Trim();

                if (input.Equals("quit", StringComparison.OrdinalIgnoreCase))
                    return;

                scripture.HideRandomWord();
                Console.Clear();
            }
        }
    }
}

class ScriptureLoader
{
    public List<BibleScripture> LoadScripturesFromFile(string filePath)
    {
        List<BibleScripture> scriptures = new List<BibleScripture>();

        string[] lines = System.IO.File.ReadAllLines(filePath);

        foreach (string line in lines)
        {
            string[] parts = line.Split(':');
            string reference = parts[0].Trim();
            string text = parts[1].Trim();

            BibleScripture scripture = new BibleScripture(reference, text);
            scriptures.Add(scripture);
        }

        return scriptures;
    }
}

class BibleScripture
{
    private List<ScriptureVerse> verses;
    private List<int> hiddenWordIndices;

    public bool AllWordsHidden { get; private set; }

    public BibleScripture(string reference, string text)
    {
        verses = new List<ScriptureVerse>();
        hiddenWordIndices = new List<int>();

        ScriptureVerse verse = new ScriptureVerse(reference, text);
        verses.Add(verse);
    }

    public void HideRandomWord()
    {
        if (hiddenWordIndices.Count >= GetTotalWordCount())
        {
            AllWordsHidden = true;
            return;
        }

        Random random = new Random();
        int wordIndex;

        do
        {
            wordIndex = random.Next(GetTotalWordCount());
        } while (hiddenWordIndices.Contains(wordIndex));

        hiddenWordIndices.Add(wordIndex);
    }

    public string GetHiddenText()
    {
        string hiddenText = string.Empty;
        int wordIndex = 0;

        foreach (ScriptureVerse verse in verses)
        {
            foreach (string word in verse.GetWords())
            {
                if (hiddenWordIndices.Contains(wordIndex))
                    hiddenText += "____ ";
                else
                    hiddenText += word + " ";

                wordIndex++;
            }

            hiddenText += Environment.NewLine;
        }

        return hiddenText;
    }

    private int GetTotalWordCount()
    {
        int count = 0;

        foreach (ScriptureVerse verse in verses)
        {
            count += verse.GetWordCount();
        }

        return count;
    }
}

class ScriptureVerse
{
    private string reference;
    private string text;

    public ScriptureVerse(string reference, string text)
    {
        this.reference = reference;
        this.text = text;
    }

    public string[] GetWords()
    {
        return text.Split(' ', StringSplitOptions.RemoveEmptyEntries);
    }

    public int GetWordCount()
    {
        return GetWords().Length;
    }
}
