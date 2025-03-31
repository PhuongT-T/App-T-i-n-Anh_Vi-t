using System;
using System.Collections;

public class DictionaryManager : DictionaryBase
{
    // ✅ Thêm từ vào từ điển
    public void AddWord(string word, string meaning)
    {
        // Directly add the word and its meaning (no check needed)
        base.InnerHashtable.Add(word, meaning);
    }

    // ✅ Kiểm tra xem từ có tồn tại không
    public bool Contains(string word)
    {
        // Just check if the word exists directly in InnerHashtable
        return base.InnerHashtable.Contains(word);
    }

    // ✅ Lấy định nghĩa của từ
    public string GetDefinition(string word)
    {
        if (base.InnerHashtable.Contains(word))  // Directly check if the word exists
        {
            return (string)base.InnerHashtable[word];
        }
        else
        {
            return "Không tìm thấy từ này";  // Return a message if the word is not found
        }
    }

    // ✅ Thêm từ vào danh sách yêu thích (Sử dụng InnerHashtable để lưu từ yêu thích)
    public void AddToFavorites(string word)
    {
        // Directly add the word as favorite by modifying its value in InnerHashtable
        base.InnerHashtable[word] = "Yêu thích: " + (string)base.InnerHashtable[word];
    }

    // ✅ Lấy danh sách các từ yêu thích (Lọc các từ có tiền tố "Yêu thích")
    public void GetFavorites()
    {
        Console.WriteLine("Danh sách từ yêu thích:");
        foreach (DictionaryEntry entry in base.InnerHashtable)
        {
            // Filter and print only words marked as favorites
            if (entry.Value.ToString().StartsWith("Yêu thích"))
            {
                Console.WriteLine($"{entry.Key}: {entry.Value}");
            }
        }
    }

    // ✅ In toàn bộ từ điển
    public void PrintAllWords()
    {
        Console.WriteLine("Danh sách từ điển:");
        foreach (DictionaryEntry entry in base.InnerHashtable)
        {
            Console.WriteLine($"{entry.Key}: {entry.Value}");
        }
    }
}
