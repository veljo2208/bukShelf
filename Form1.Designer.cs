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
            addBook = new Button();
            addBookshelf = new Button();
            bookshelfNameText = new TextBox();
            bookshelfMaterialText = new TextBox();
            showBookshelfs = new Button();
            bookBookshelfText = new TextBox();
            bookWeightText = new TextBox();
            bookAuthorText = new TextBox();
            bookNameText = new TextBox();
            SuspendLayout();
            // 
            // addBook
            // 
            addBook.Location = new Point(664, 383);
            addBook.Name = "addBook";
            addBook.Size = new Size(124, 55);
            addBook.TabIndex = 0;
            addBook.Text = "Add Book";
            addBook.UseVisualStyleBackColor = true;
            addBook.Click += addBook_Click;
            // 
            // addBookshelf
            // 
            addBookshelf.Location = new Point(12, 308);
            addBookshelf.Name = "addBookshelf";
            addBookshelf.Size = new Size(124, 55);
            addBookshelf.TabIndex = 1;
            addBookshelf.Text = "Add Bookshelf";
            addBookshelf.UseVisualStyleBackColor = true;
            addBookshelf.Click += addBookshelf_Click;
            // 
            // bookshelfNameText
            // 
            bookshelfNameText.Location = new Point(12, 215);
            bookshelfNameText.Name = "bookshelfNameText";
            bookshelfNameText.Size = new Size(124, 23);
            bookshelfNameText.TabIndex = 5;
            bookshelfNameText.Text = "Name of bookshelf";
            bookshelfNameText.TextAlign = HorizontalAlignment.Center;
            // 
            // bookshelfMaterialText
            // 
            bookshelfMaterialText.Location = new Point(12, 254);
            bookshelfMaterialText.Name = "bookshelfMaterialText";
            bookshelfMaterialText.Size = new Size(124, 23);
            bookshelfMaterialText.TabIndex = 6;
            bookshelfMaterialText.Text = "Material of bookshelf";
            bookshelfMaterialText.TextAlign = HorizontalAlignment.Center;
            // 
            // showBookshelfs
            // 
            showBookshelfs.Location = new Point(12, 383);
            showBookshelfs.Name = "showBookshelfs";
            showBookshelfs.Size = new Size(124, 55);
            showBookshelfs.TabIndex = 7;
            showBookshelfs.Text = "Show Bookshelfs";
            showBookshelfs.UseVisualStyleBackColor = true;
            // 
            // bookBookshelfText
            // 
            bookBookshelfText.Location = new Point(664, 340);
            bookBookshelfText.Name = "bookBookshelfText";
            bookBookshelfText.Size = new Size(124, 23);
            bookBookshelfText.TabIndex = 8;
            bookBookshelfText.Text = "Enter bookshelf";
            bookBookshelfText.TextAlign = HorizontalAlignment.Center;
            // 
            // bookWeightText
            // 
            bookWeightText.Location = new Point(664, 297);
            bookWeightText.Name = "bookWeightText";
            bookWeightText.Size = new Size(124, 23);
            bookWeightText.TabIndex = 9;
            bookWeightText.Text = "Weight of book";
            bookWeightText.TextAlign = HorizontalAlignment.Center;
            // 
            // bookAuthorText
            // 
            bookAuthorText.Location = new Point(664, 254);
            bookAuthorText.Name = "bookAuthorText";
            bookAuthorText.Size = new Size(124, 23);
            bookAuthorText.TabIndex = 10;
            bookAuthorText.Text = "Author of book";
            bookAuthorText.TextAlign = HorizontalAlignment.Center;
            // 
            // bookNameText
            // 
            bookNameText.Location = new Point(664, 215);
            bookNameText.Name = "bookNameText";
            bookNameText.Size = new Size(124, 23);
            bookNameText.TabIndex = 11;
            bookNameText.Text = "Name of book\r\n";
            bookNameText.TextAlign = HorizontalAlignment.Center;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(bookNameText);
            Controls.Add(bookAuthorText);
            Controls.Add(bookWeightText);
            Controls.Add(bookBookshelfText);
            Controls.Add(showBookshelfs);
            Controls.Add(bookshelfMaterialText);
            Controls.Add(bookshelfNameText);
            Controls.Add(addBookshelf);
            Controls.Add(addBook);
            Name = "Form1";
            Text = "Form1";
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
    }
}
