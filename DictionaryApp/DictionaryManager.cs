using System;
using System.Collections.Generic;
using System.IO;

namespace DictionaryApp
{
    public class DictionaryManager
    {
        private Dictionary<string, WordEntry> dictionary = new Dictionary<string, WordEntry>();

        // Đọc file từ điển và lưu vào Dictionary
        public void LoadFromFile(string filePath)
        {
            if (File.Exists(filePath))
            {
                foreach (var line in File.ReadAllLines(filePath))
                {
                    var parts = line.Split(','); // Giả sử file có định dạng: từ,từ tiếng Việt,loại từ,phát âm
                    if (parts.Length == 4)
                    {
                        string english = parts[0].Trim();
                        string vietnamese = parts[1].Trim();
                        string partOfSpeech = parts[2].Trim();
                        string pronunciation = parts[3].Trim();

                        dictionary[english] = new WordEntry(english, vietnamese, partOfSpeech, pronunciation);
                    }
                }
            }
        }

        // Tìm kiếm từ vựng
        public string SearchWord(string englishWord)
        {
            return dictionary.TryGetValue(englishWord, out WordEntry entry)
                ? entry.ToString()
                : "Không tìm thấy!";
        }
    }
}
