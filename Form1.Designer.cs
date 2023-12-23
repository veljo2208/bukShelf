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
            Logo = new PictureBox();
            lblCategory = new Label();
            textCategory = new TextBox();
            lblMaterial = new Label();
            textBoxBookCategory = new TextBox();
            lblBookCategory = new Label();
            textBoxBook = new TextBox();
            lblName = new Label();
            textBoxAuthor = new TextBox();
            lblAuthor = new Label();
            comboBoxMaterial = new ComboBox();
            btnAddShelf = new Button();
            btnRemove = new Button();
            btnClear = new Button();
            btnClearBook = new Button();
            btnRemoveBook = new Button();
            btnAddBook = new Button();
            dataGridView1 = new DataGridView();
            lblBookshelfNote = new Label();
            lblBookNote = new Label();
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            textBox1 = new TextBox();
            lblBookSearch = new Label();
            textBox2 = new TextBox();
            lblBookshelfSearch = new Label();
            ((System.ComponentModel.ISupportInitialize)Logo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // Logo
            // 
            Logo.BackColor = Color.Transparent;
            Logo.Image = (Image)resources.GetObject("Logo.Image");
            Logo.Location = new Point(466, 12);
            Logo.Name = "Logo";
            Logo.Size = new Size(312, 147);
            Logo.SizeMode = PictureBoxSizeMode.StretchImage;
            Logo.TabIndex = 12;
            Logo.TabStop = false;
            // 
            // lblCategory
            // 
            lblCategory.AutoSize = true;
            lblCategory.BackColor = Color.Transparent;
            lblCategory.Font = new Font("ISOCPEUR", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCategory.Location = new Point(66, 183);
            lblCategory.Name = "lblCategory";
            lblCategory.Size = new Size(91, 29);
            lblCategory.TabIndex = 13;
            lblCategory.Text = "Category";
            // 
            // textCategory
            // 
            textCategory.Font = new Font("ISOCPEUR", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textCategory.Location = new Point(163, 180);
            textCategory.Name = "textCategory";
            textCategory.Size = new Size(196, 36);
            textCategory.TabIndex = 14;
            // 
            // lblMaterial
            // 
            lblMaterial.AutoSize = true;
            lblMaterial.BackColor = Color.Transparent;
            lblMaterial.Font = new Font("ISOCPEUR", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblMaterial.Location = new Point(66, 242);
            lblMaterial.Name = "lblMaterial";
            lblMaterial.Size = new Size(84, 29);
            lblMaterial.TabIndex = 15;
            lblMaterial.Text = "Material";
            // 
            // textBoxBookCategory
            // 
            textBoxBookCategory.Font = new Font("ISOCPEUR", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBoxBookCategory.Location = new Point(1029, 302);
            textBoxBookCategory.Name = "textBoxBookCategory";
            textBoxBookCategory.Size = new Size(196, 36);
            textBoxBookCategory.TabIndex = 18;
            // 
            // lblBookCategory
            // 
            lblBookCategory.AutoSize = true;
            lblBookCategory.BackColor = Color.Transparent;
            lblBookCategory.Font = new Font("ISOCPEUR", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblBookCategory.Location = new Point(932, 305);
            lblBookCategory.Name = "lblBookCategory";
            lblBookCategory.Size = new Size(91, 29);
            lblBookCategory.TabIndex = 17;
            lblBookCategory.Text = "Category";
            // 
            // textBoxBook
            // 
            textBoxBook.Font = new Font("ISOCPEUR", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBoxBook.Location = new Point(1029, 180);
            textBoxBook.Name = "textBoxBook";
            textBoxBook.Size = new Size(196, 36);
            textBoxBook.TabIndex = 20;
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.BackColor = Color.Transparent;
            lblName.Font = new Font("ISOCPEUR", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblName.Location = new Point(917, 183);
            lblName.Name = "lblName";
            lblName.Size = new Size(106, 29);
            lblName.TabIndex = 19;
            lblName.Text = "Book name";
            // 
            // textBoxAuthor
            // 
            textBoxAuthor.Font = new Font("ISOCPEUR", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBoxAuthor.Location = new Point(1029, 240);
            textBoxAuthor.Name = "textBoxAuthor";
            textBoxAuthor.Size = new Size(196, 36);
            textBoxAuthor.TabIndex = 22;
            // 
            // lblAuthor
            // 
            lblAuthor.AutoSize = true;
            lblAuthor.BackColor = Color.Transparent;
            lblAuthor.Font = new Font("ISOCPEUR", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblAuthor.Location = new Point(897, 243);
            lblAuthor.Name = "lblAuthor";
            lblAuthor.Size = new Size(126, 29);
            lblAuthor.TabIndex = 21;
            lblAuthor.Text = "Author name";
            // 
            // comboBoxMaterial
            // 
            comboBoxMaterial.Font = new Font("ISOCPEUR", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comboBoxMaterial.FormattingEnabled = true;
            comboBoxMaterial.Items.AddRange(new object[] { "wooden bookshelf", "metal bookshelf" });
            comboBoxMaterial.Location = new Point(163, 242);
            comboBoxMaterial.Name = "comboBoxMaterial";
            comboBoxMaterial.Size = new Size(196, 37);
            comboBoxMaterial.TabIndex = 23;
            // 
            // btnAddShelf
            // 
            btnAddShelf.BackColor = Color.OliveDrab;
            btnAddShelf.Font = new Font("ISOCPEUR", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAddShelf.ForeColor = Color.White;
            btnAddShelf.Location = new Point(41, 312);
            btnAddShelf.Name = "btnAddShelf";
            btnAddShelf.Size = new Size(105, 50);
            btnAddShelf.TabIndex = 24;
            btnAddShelf.Text = "Add";
            btnAddShelf.UseVisualStyleBackColor = false;
            // 
            // btnRemove
            // 
            btnRemove.BackColor = Color.Firebrick;
            btnRemove.Font = new Font("ISOCPEUR", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnRemove.ForeColor = Color.White;
            btnRemove.Location = new Point(165, 312);
            btnRemove.Name = "btnRemove";
            btnRemove.Size = new Size(105, 50);
            btnRemove.TabIndex = 25;
            btnRemove.Text = "Remove";
            btnRemove.UseVisualStyleBackColor = false;
            // 
            // btnClear
            // 
            btnClear.BackColor = Color.DarkGoldenrod;
            btnClear.Font = new Font("ISOCPEUR", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnClear.ForeColor = Color.White;
            btnClear.Location = new Point(287, 312);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(105, 50);
            btnClear.TabIndex = 26;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = false;
            // 
            // btnClearBook
            // 
            btnClearBook.BackColor = Color.DarkGoldenrod;
            btnClearBook.Font = new Font("ISOCPEUR", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnClearBook.ForeColor = Color.White;
            btnClearBook.Location = new Point(1143, 370);
            btnClearBook.Name = "btnClearBook";
            btnClearBook.Size = new Size(105, 50);
            btnClearBook.TabIndex = 29;
            btnClearBook.Text = "Clear";
            btnClearBook.UseVisualStyleBackColor = false;
            // 
            // btnRemoveBook
            // 
            btnRemoveBook.BackColor = Color.Firebrick;
            btnRemoveBook.Font = new Font("ISOCPEUR", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnRemoveBook.ForeColor = Color.White;
            btnRemoveBook.Location = new Point(1021, 370);
            btnRemoveBook.Name = "btnRemoveBook";
            btnRemoveBook.Size = new Size(105, 50);
            btnRemoveBook.TabIndex = 28;
            btnRemoveBook.Text = "Remove";
            btnRemoveBook.UseVisualStyleBackColor = false;
            // 
            // btnAddBook
            // 
            btnAddBook.BackColor = Color.OliveDrab;
            btnAddBook.Font = new Font("ISOCPEUR", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAddBook.ForeColor = Color.White;
            btnAddBook.Location = new Point(897, 370);
            btnAddBook.Name = "btnAddBook";
            btnAddBook.Size = new Size(105, 50);
            btnAddBook.TabIndex = 27;
            btnAddBook.Text = "Add";
            btnAddBook.UseVisualStyleBackColor = false;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(475, 451);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(853, 347);
            dataGridView1.TabIndex = 30;
            // 
            // lblBookshelfNote
            // 
            lblBookshelfNote.AutoSize = true;
            lblBookshelfNote.BackColor = Color.Transparent;
            lblBookshelfNote.Font = new Font("ISOCPEUR", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblBookshelfNote.Location = new Point(84, 83);
            lblBookshelfNote.Name = "lblBookshelfNote";
            lblBookshelfNote.Size = new Size(279, 76);
            lblBookshelfNote.TabIndex = 31;
            lblBookshelfNote.Text = "Here you can make \r\na new bookshelfs";
            // 
            // lblBookNote
            // 
            lblBookNote.AutoSize = true;
            lblBookNote.BackColor = Color.Transparent;
            lblBookNote.Font = new Font("ISOCPEUR", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblBookNote.Location = new Point(875, 83);
            lblBookNote.Name = "lblBookNote";
            lblBookNote.Size = new Size(397, 76);
            lblBookNote.TabIndex = 32;
            lblBookNote.Text = "Here you can add new books\r\nto your bookshelfs";
            lblBookNote.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(1297, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(48, 48);
            pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBox1.TabIndex = 33;
            pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(1224, 12);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(48, 48);
            pictureBox2.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBox2.TabIndex = 34;
            pictureBox2.TabStop = false;
            // 
            // textBox1
            // 
            textBox1.Font = new Font("ISOCPEUR", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox1.Location = new Point(41, 702);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(400, 36);
            textBox1.TabIndex = 38;
            // 
            // lblBookSearch
            // 
            lblBookSearch.AutoSize = true;
            lblBookSearch.BackColor = Color.Transparent;
            lblBookSearch.Font = new Font("ISOCPEUR", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblBookSearch.Location = new Point(174, 652);
            lblBookSearch.Name = "lblBookSearch";
            lblBookSearch.Size = new Size(131, 29);
            lblBookSearch.TabIndex = 37;
            lblBookSearch.Text = "Books search";
            // 
            // textBox2
            // 
            textBox2.Font = new Font("ISOCPEUR", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox2.Location = new Point(41, 551);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(400, 36);
            textBox2.TabIndex = 36;
            // 
            // lblBookshelfSearch
            // 
            lblBookshelfSearch.AutoSize = true;
            lblBookshelfSearch.BackColor = Color.Transparent;
            lblBookshelfSearch.Font = new Font("ISOCPEUR", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblBookshelfSearch.Location = new Point(163, 505);
            lblBookshelfSearch.Name = "lblBookshelfSearch";
            lblBookshelfSearch.Size = new Size(166, 29);
            lblBookshelfSearch.TabIndex = 35;
            lblBookshelfSearch.Text = "Bookshelf search";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1357, 821);
            Controls.Add(textBox1);
            Controls.Add(lblBookSearch);
            Controls.Add(textBox2);
            Controls.Add(lblBookshelfSearch);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox1);
            Controls.Add(lblBookNote);
            Controls.Add(lblBookshelfNote);
            Controls.Add(dataGridView1);
            Controls.Add(btnClearBook);
            Controls.Add(btnRemoveBook);
            Controls.Add(btnAddBook);
            Controls.Add(btnClear);
            Controls.Add(btnRemove);
            Controls.Add(btnAddShelf);
            Controls.Add(comboBoxMaterial);
            Controls.Add(textBoxAuthor);
            Controls.Add(lblAuthor);
            Controls.Add(textBoxBook);
            Controls.Add(lblName);
            Controls.Add(textBoxBookCategory);
            Controls.Add(lblBookCategory);
            Controls.Add(lblMaterial);
            Controls.Add(textCategory);
            Controls.Add(lblCategory);
            Controls.Add(Logo);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 4, 3, 4);
            Name = "Form1";
            Text = "Book club";
            ((System.ComponentModel.ISupportInitialize)Logo).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private PictureBox Logo;
        private Label lblCategory;
        private TextBox textCategory;
        private Label lblMaterial;
        private TextBox textBoxBookCategory;
        private Label lblBookCategory;
        private TextBox textBoxBook;
        private Label lblName;
        private TextBox textBoxAuthor;
        private Label lblAuthor;
        private ComboBox comboBoxMaterial;
        private Button btnAddShelf;
        private Button btnRemove;
        private Button btnClear;
        private Button btnClearBook;
        private Button btnRemoveBook;
        private Button btnAddBook;
        private DataGridView dataGridView1;
        private Label lblBookshelfNote;
        private Label lblBookNote;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private TextBox textBox1;
        private Label lblBookSearch;
        private TextBox textBox2;
        private Label lblBookshelfSearch;
    }
}
