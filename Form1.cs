namespace bukShelf
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void addBookshelf_Click(object sender, EventArgs e)
        {
            string name = bookshelfNameText.Text.ToString();
            string material = bookshelfMaterialText.Text.ToString();

            MessageBox.Show(name, material);
        }

        private void addBook_Click(object sender, EventArgs e)
        {
            string name = bookNameText.Text.ToString();
            string author = bookAuthorText.Text.ToString();

            MessageBox.Show(name, author);

        }
    }
}
