public class WordEntry
{
    public string Word { get; set; }
    public string Meaning { get; set; }
    public string Pronunciation { get; set; }
    public string Type { get; set; }

    public WordEntry(string word, string meaning, string pronunciation, string type)
    {
        Word = word;
        Meaning = meaning;
        Pronunciation = pronunciation;
        Type = type;
    }
}
