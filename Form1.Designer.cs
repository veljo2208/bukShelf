namespace bukShelf
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            addBook = new Button();
            addBookshelf = new Button();
            bookshelfNameText = new TextBox();
            bookshelfMaterialText = new TextBox();
            showBookshelfs = new Button();
            bookBookshelfText = new TextBox();
            bookWeightText = new TextBox();
            bookAuthorText = new TextBox();
            bookNameText = new TextBox();
            Logo = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)Logo).BeginInit();
            SuspendLayout();
            // 
            // addBook
            // 
            addBook.Location = new Point(759, 511);
            addBook.Margin = new Padding(3, 4, 3, 4);
            addBook.Name = "addBook";
            addBook.Size = new Size(142, 73);
            addBook.TabIndex = 0;
            addBook.Text = "Add Book";
            addBook.UseVisualStyleBackColor = true;
            addBook.Click += addBook_Click;
            // 
            // addBookshelf
            // 
            addBookshelf.Location = new Point(14, 411);
            addBookshelf.Margin = new Padding(3, 4, 3, 4);
            addBookshelf.Name = "addBookshelf";
            addBookshelf.Size = new Size(142, 73);
            addBookshelf.TabIndex = 1;
            addBookshelf.Text = "Add Bookshelf";
            addBookshelf.UseVisualStyleBackColor = true;
            addBookshelf.Click += addBookshelf_Click;
            // 
            // bookshelfNameText
            // 
            bookshelfNameText.Location = new Point(14, 287);
            bookshelfNameText.Margin = new Padding(3, 4, 3, 4);
            bookshelfNameText.Name = "bookshelfNameText";
            bookshelfNameText.Size = new Size(141, 27);
            bookshelfNameText.TabIndex = 5;
            bookshelfNameText.Text = "Name of bookshelf";
            bookshelfNameText.TextAlign = HorizontalAlignment.Center;
            // 
            // bookshelfMaterialText
            // 
            bookshelfMaterialText.Location = new Point(14, 339);
            bookshelfMaterialText.Margin = new Padding(3, 4, 3, 4);
            bookshelfMaterialText.Name = "bookshelfMaterialText";
            bookshelfMaterialText.Size = new Size(141, 27);
            bookshelfMaterialText.TabIndex = 6;
            bookshelfMaterialText.Text = "Material of bookshelf";
            bookshelfMaterialText.TextAlign = HorizontalAlignment.Center;
            // 
            // showBookshelfs
            // 
            showBookshelfs.Location = new Point(14, 511);
            showBookshelfs.Margin = new Padding(3, 4, 3, 4);
            showBookshelfs.Name = "showBookshelfs";
            showBookshelfs.Size = new Size(142, 73);
            showBookshelfs.TabIndex = 7;
            showBookshelfs.Text = "Show Bookshelfs";
            showBookshelfs.UseVisualStyleBackColor = true;
            // 
            // bookBookshelfText
            // 
            bookBookshelfText.Location = new Point(759, 453);
            bookBookshelfText.Margin = new Padding(3, 4, 3, 4);
            bookBookshelfText.Name = "bookBookshelfText";
            bookBookshelfText.Size = new Size(141, 27);
            bookBookshelfText.TabIndex = 8;
            bookBookshelfText.Text = "Enter bookshelf";
            bookBookshelfText.TextAlign = HorizontalAlignment.Center;
            // 
            // bookWeightText
            // 
            bookWeightText.Location = new Point(759, 396);
            bookWeightText.Margin = new Padding(3, 4, 3, 4);
            bookWeightText.Name = "bookWeightText";
            bookWeightText.Size = new Size(141, 27);
            bookWeightText.TabIndex = 9;
            bookWeightText.Text = "Weight of book";
            bookWeightText.TextAlign = HorizontalAlignment.Center;
            // 
            // bookAuthorText
            // 
            bookAuthorText.Location = new Point(759, 339);
            bookAuthorText.Margin = new Padding(3, 4, 3, 4);
            bookAuthorText.Name = "bookAuthorText";
            bookAuthorText.Size = new Size(141, 27);
            bookAuthorText.TabIndex = 10;
            bookAuthorText.Text = "Author of book";
            bookAuthorText.TextAlign = HorizontalAlignment.Center;
            // 
            // bookNameText
            // 
            bookNameText.Location = new Point(759, 287);
            bookNameText.Margin = new Padding(3, 4, 3, 4);
            bookNameText.Name = "bookNameText";
            bookNameText.Size = new Size(141, 27);
            bookNameText.TabIndex = 11;
            bookNameText.Text = "Name of book\r\n";
            bookNameText.TextAlign = HorizontalAlignment.Center;
            // 
            // Logo
            // 
            Logo.BackColor = Color.Transparent;
            Logo.Image = (Image)resources.GetObject("Logo.Image");
            Logo.Location = new Point(302, 12);
            Logo.Name = "Logo";
            Logo.Size = new Size(312, 147);
            Logo.SizeMode = PictureBoxSizeMode.StretchImage;
            Logo.TabIndex = 12;
            Logo.TabStop = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(914, 600);
            Controls.Add(Logo);
            Controls.Add(bookNameText);
            Controls.Add(bookAuthorText);
            Controls.Add(bookWeightText);
            Controls.Add(bookBookshelfText);
            Controls.Add(showBookshelfs);
            Controls.Add(bookshelfMaterialText);
            Controls.Add(bookshelfNameText);
            Controls.Add(addBookshelf);
            Controls.Add(addBook);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)Logo).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button addBook;
        private Button addBookshelf;
        private TextBox bookshelfNameText;
        private TextBox bookshelfMaterialText;
        private Button showBookshelfs;
        private TextBox bookBookshelfText;
        private TextBox bookWeightText;
        private TextBox bookAuthorText;
        private TextBox bookNameText;
        private PictureBox Logo;
    }
}
