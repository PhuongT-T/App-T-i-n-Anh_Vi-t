using System;
using System.Collections;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace DictionaryApp
{
    public class DictionaryBaseManager : DictionaryBase
    {
        public void Add(string name, string meaning)
        {
            base.InnerHashtable[name] = meaning;
        }

        public string Item(string name)
        {
            return base.InnerHashtable.ContainsKey(name) ? base.InnerHashtable[name].ToString() : "Không tìm thấy!";
        }

        public void Remove(string name)
        {
            base.InnerHashtable.Remove(name);
        }
    }

    public partial class Form1 : Form
    {
        private DictionaryBaseManager dictionaryManager;

        public Form1()
        {
            InitializeComponent();
            dictionaryManager = new DictionaryBaseManager();

            string filePath = @"C:\\Users\\Phuong\\Documents\\anhviet.txt";
            if (File.Exists(filePath))
            {
                LoadFromFile(filePath);
            }
            else
            {
                MessageBox.Show("File từ điển không tồn tại! Vui lòng kiểm tra lại.",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            SetBackgroundImage();
        }

        private void LoadFromFile(string filePath)
        {
            foreach (var line in File.ReadAllLines(filePath))
            {
                var parts = line.Split(',');
                if (parts.Length == 4)
                {
                    string english = parts[0].Trim();
                    string vietnamese = parts[1].Trim();
                    string partOfSpeech = parts[2].Trim();
                    string pronunciation = parts[3].Trim();

                    string fullMeaning = $"{vietnamese} ({partOfSpeech}) [{pronunciation}]";
                    dictionaryManager.Add(english.ToLower(), fullMeaning);

                    Console.WriteLine($"Đã thêm: {english} - {fullMeaning}");
                }
            }
        }

        private void SetBackgroundImage()
        {
            string backgroundPath = @"C:\\Users\\Phuong\\Documents\\logo.png";
            if (File.Exists(backgroundPath))
            {
                this.BackgroundImage = Image.FromFile(backgroundPath);
                this.BackgroundImageLayout = ImageLayout.Stretch;
            }
            else
            {
                MessageBox.Show("Không tìm thấy hình nền!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string word = txtSearch.Text.Trim().ToLower();
            if (string.IsNullOrEmpty(word))
            {
                lblResult.Text = "Vui lòng nhập từ cần tra cứu!";
                return;
            }

            string meaning = dictionaryManager.Item(word);
            lblResult.Text = meaning;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            lblResult.Text = "";
        }
    }
}
