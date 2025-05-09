using System;
using System.IO;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace DictionaryApp
{
    public partial class Form1 : Form
    {
        private DictionaryManager dictionary; // Dùng để sử lí thủ công
        private HashSet<string> favoriteWords;
        private readonly string dictionaryPath = @"C:\Users\Phuong\Documents\anhviet.txt";
        private readonly string backgroundPath = @"C:\Users\Phuong\Documents\logo.png";

        public Form1()
        {
            InitializeComponent();
            dictionary = new DictionaryManager(); // 👈 Khởi tạo bảng băm thủ công
            favoriteWords = new HashSet<string>();

            LoadDictionary();
            SetBackgroundImage();

            btnShowFavorites.Click += new EventHandler(btnShowFavorites_Click);
            btnAddToFavorites.Click += new EventHandler(btnAddToFavorites_Click);
        }

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

                        if (!dictionary.Contains(english)) // 👈 Dùng phương thức Contains của bảng băm
                        {
                            var entry = new WordEntry(english, vietnamese, pronunciation, partOfSpeech);
                            dictionary.AddWord(english, entry); // 👈 Thêm từ
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải từ điển: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetBackgroundImage()
        {
            if (File.Exists(backgroundPath))
            {
                this.BackgroundImage = Image.FromFile(backgroundPath);
                this.BackgroundImageLayout = ImageLayout.Stretch;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string word = txtSearch.Text.Trim();

            if (string.IsNullOrEmpty(word))
            {
                lblResult.Text = "Vui lòng nhập từ cần tra cứu!";
                return;
            }

            if (dictionary.Contains(word)) // 👈 Kiểm tra tồn tại
            {
                WordEntry entry = dictionary.GetDefinition(word); // 👈 Lấy định nghĩa
                lblResult.Text = $"Nghĩa: {entry.Meaning}\nLoại từ: {entry.Type}\nPhiên âm: {entry.Pronunciation}";
            }
            else
            {
                lblResult.Text = "Không tìm thấy từ này!";
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            lblResult.Text = "";
        }

        private void btnAddToFavorites_Click(object sender, EventArgs e)
        {
            string word = txtSearch.Text.Trim();

            if (!string.IsNullOrEmpty(word) && dictionary.Contains(word)) // 👈 Dùng dictionary.Contains
            {
                if (favoriteWords.Add(word)) // giữ nguyên
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

        private void btnShowFavorites_Click(object sender, EventArgs e)
        {
            txtWord.Text = favoriteWords.Count > 0 ? string.Join(", ", favoriteWords) : "Chưa có từ yêu thích nào!";
        }
    }
}
