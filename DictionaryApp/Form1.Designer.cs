namespace DictionaryApp
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.lblResult = new System.Windows.Forms.Label();
            this.btnAddToFavorites = new System.Windows.Forms.Button();
            this.btnShowFavorites = new System.Windows.Forms.Button();
            this.txtWord = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(125, 33);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(172, 25);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Từ điển Anh-Việt";
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(67, 91);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(519, 31);
            this.txtSearch.TabIndex = 1;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(659, 80);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(115, 66);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "Tìm kiếm";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // lblResult
            // 
            this.lblResult.AutoSize = true;
            this.lblResult.Location = new System.Drawing.Point(80, 177);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(30, 25);
            this.lblResult.TabIndex = 3;
            this.lblResult.Text = "...";
            // 
            // btnAddToFavorites
            // 
            this.btnAddToFavorites.AllowDrop = true;
            this.btnAddToFavorites.Location = new System.Drawing.Point(659, 152);
            this.btnAddToFavorites.Name = "btnAddToFavorites";
            this.btnAddToFavorites.Size = new System.Drawing.Size(115, 100);
            this.btnAddToFavorites.TabIndex = 4;
            this.btnAddToFavorites.Text = "Yêu thích";
            this.btnAddToFavorites.UseVisualStyleBackColor = true;
            // 
            // btnShowFavorites
            // 
            this.btnShowFavorites.Location = new System.Drawing.Point(376, 153);
            this.btnShowFavorites.Name = "btnShowFavorites";
            this.btnShowFavorites.Size = new System.Drawing.Size(264, 66);
            this.btnShowFavorites.TabIndex = 5;
            this.btnShowFavorites.Text = "Danh sách từ yêu thích";
            this.btnShowFavorites.UseVisualStyleBackColor = true;
            // 
            // txtWord
            // 
            this.txtWord.Location = new System.Drawing.Point(376, 239);
            this.txtWord.Name = "txtWord";
            this.txtWord.Size = new System.Drawing.Size(263, 31);
            this.txtWord.TabIndex = 6;
            this.txtWord.Text = "...";
          
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnRemoveFromFavorites);
            this.Controls.Add(this.txtWord);
            this.Controls.Add(this.btnShowFavorites);
            this.Controls.Add(this.btnAddToFavorites);
            this.Controls.Add(this.lblResult);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.lblTitle);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.Button btnAddToFavorites;
        private System.Windows.Forms.Button btnShowFavorites;
        private System.Windows.Forms.TextBox txtWord;
        private System.Windows.Forms.Button btnRemoveFromFavorites;
    }
}

