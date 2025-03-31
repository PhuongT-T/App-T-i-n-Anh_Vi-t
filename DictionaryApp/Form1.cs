using System;
using System.IO;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace DictionaryApp
{
    public partial class Form1 : Form
    {
        private Dictionary<string, WordEntry> dictionary;
        private HashSet<string> favoriteWords;
        private readonly string dictionaryPath = @"C:\Users\Phuong\Documents\anhviet.txt";
        private readonly string backgroundPath = @"C:\Users\Phuong\Documents\logo.png";

        public Form1()
        {
            InitializeComponent();
            dictionary = new Dictionary<string, WordEntry>();
            favoriteWords = new HashSet<string>();

            LoadDictionary();
            SetBackgroundImage();

            // 🔗 Liên kết sự kiện nút yêu thích
            btnShowFavorites.Click += new EventHandler(btnShowFavorites_Click);
            btnAddToFavorites.Click += new EventHandler(btnAddToFavorites_Click);
        }

        // ✅ Load từ điển từ file
        private void LoadDictionary()
        {
            if (!File.Exists(dictionaryPath))
            {
                MessageBox.Show("File từ điển không tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                foreach (var line in File.ReadAllLines(dictionaryPath))
                {
                    var parts = line.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                    if (parts.Length == 4)
                    {
                        string english = parts[0].Trim();
                        string vietnamese = parts[1].Trim();
                        string partOfSpeech = parts[2].Trim();
                        string pronunciation = parts[3].Trim();

                        if (!dictionary.ContainsKey(english))
                        {
                            dictionary.Add(english, new WordEntry(english, vietnamese, pronunciation, partOfSpeech));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải từ điển: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ✅ Kiểm tra và tải hình nền
        private void SetBackgroundImage()
        {
            if (File.Exists(backgroundPath))
            {
                this.BackgroundImage = Image.FromFile(backgroundPath);
                this.BackgroundImageLayout = ImageLayout.Stretch;
            }
        }

        // ✅ Xử lý tìm kiếm
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string word = txtSearch.Text.Trim();

            if (string.IsNullOrEmpty(word))
            {
                lblResult.Text = "Vui lòng nhập từ cần tra cứu!";
                return;
            }

            if (dictionary.TryGetValue(word, out WordEntry entry))
            {
                lblResult.Text = $"Nghĩa: {entry.Meaning}\nLoại từ: {entry.Type}\nPhiên âm: {entry.Pronunciation}";
            }
            else
            {
                lblResult.Text = "Không tìm thấy từ này!";
            }
        }

        // ✅ Xóa kết quả khi nhập từ mới
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            lblResult.Text = "";
        }

        // ✅ Thêm từ vào danh sách yêu thích
        private void btnAddToFavorites_Click(object sender, EventArgs e)
        {
            string word = txtSearch.Text.Trim();

            if (!string.IsNullOrEmpty(word) && dictionary.ContainsKey(word))
            {
                if (favoriteWords.Add(word)) // Tránh thêm trùng
                {
                    MessageBox.Show($"'{word}' đã được thêm vào danh sách yêu thích!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show($"'{word}' đã có trong danh sách yêu thích!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập từ hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // ✅ Hiển thị danh sách từ yêu thích
        private void btnShowFavorites_Click(object sender, EventArgs e)
        {
            txtWord.Text = favoriteWords.Count > 0 ? string.Join(", ", favoriteWords) : "Chưa có từ yêu thích nào!";
        }
    }

    // ✅ Lớp WordEntry đại diện cho một từ trong từ điển
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
}
