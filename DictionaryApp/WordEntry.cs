using System;

namespace DictionaryApp
{
    public class WordEntry
    {
        public string English { get; set; }
        public string Vietnamese { get; set; }
        public string PartOfSpeech { get; set; }
        public string Pronunciation { get; set; }

        public WordEntry(string english, string vietnamese, string partOfSpeech, string pronunciation)
        {
            English = english;
            Vietnamese = vietnamese;
            PartOfSpeech = partOfSpeech;
            Pronunciation = pronunciation;
        }

        public override string ToString()
        {
            return $"{English} [{Pronunciation}] ({PartOfSpeech}): {Vietnamese}";
        }
    }
}
