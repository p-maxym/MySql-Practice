namespace MySql_Practice
{
    public partial class Form1 : Form
    {
        static public string? loginActive;
        public Form1()
        {
            InitializeComponent();
            if (!DBConnection.ConnectionDB())
            {
                MessageBox.Show("Failed to connect to database. Application will close.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string login = UsernameBox.Text;
            string password = PasswordBox.Text;

            Autorization.AutorizationUser(login, password, DBConnection.msCommand);

            if (Autorization._Name != null)
            {
                MessageBox.Show($"Welcome, {Autorization._Name}!");
            }
        }
    }
}
