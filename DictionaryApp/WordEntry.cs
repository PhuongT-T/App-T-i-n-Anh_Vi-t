 public class WordEntry
{
    public string English { get; set; }  // Từ tiếng Anh
    public string Meaning { get; set; }  // Nghĩa tiếng Việt
    public string Pronunciation { get; set; } // Phiên âm
    public string Type { get; set; } // Loại từ (danh từ, tính từ, v.v.)

    public WordEntry(string english, string meaning, string pronunciation, string type)
    {
        English = english;
        Meaning = meaning;
        Pronunciation = pronunciation;
        Type = type;
    }

    public override string ToString()
    {
        return $"{English} [{Pronunciation}] ({Type}): {Meaning}";
    }
}