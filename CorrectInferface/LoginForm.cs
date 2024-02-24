using System;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;

namespace CorrectInferface
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }
        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void connectButton_Click_1(object sender, EventArgs e)
        {
            try
            {
                // Connecting to database using string in Wizard`s file
                ConnectString.connectionString = getConnectionString();
                ConnectString.login = loginField.Text;

                ConnectString.connectionString = ConnectString.connectionString.Remove(0, ConnectString.connectionString.IndexOf(";", 0) + 1);

                // Inserting login and password values into connection string
                ConnectString.connectionString = ConnectString.connectionString.Replace("User ID=sa", "User ID=" + loginField.Text);
                ConnectString.connectionString = ConnectString.connectionString.Replace("Password=12345", "Password=" + passField.Text);

                SqlConnection connection = new SqlConnection(ConnectString.connectionString);

                //connection.Open();    // Uncomment if you have database
                Hide();
                MainWindow objectsformm = new MainWindow();
                objectsformm.Show();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Помилка входу", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        //
        // Getting connection string
        public static string getConnectionString()
        {
            // Reading database path from file
            string connectionFile = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\DBConnectionString";
            StreamReader rdr = new StreamReader(connectionFile);
            string connectionString = (rdr.ReadToEnd());
            rdr.Close();
            return connectionString;
        }

        private void LoginForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
