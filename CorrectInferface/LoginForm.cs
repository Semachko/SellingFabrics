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
                string connectionFile = getConnectionFile();
                ConnectString.connectionString = getConnectionString(connectionFile);
                ConnectString.login = loginField.Text;

                ConnectString.connectionString = ConnectString.connectionString.Remove(0, ConnectString.connectionString.IndexOf(";", 0) + 1);

                ConnectString.connectionString = ConnectString.connectionString.Replace("User ID=sa", "User ID=" + loginField.Text);
                ConnectString.connectionString = ConnectString.connectionString.Replace("Password=12345", "Password=" + passField.Text);

                SqlConnection connection = new SqlConnection(ConnectString.connectionString);

                //connection.Open();
                Hide();
                ObjectsForm objectsformm = new ObjectsForm();
                objectsformm.Show();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Помилка входу", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public static string getConnectionFile()
        {
            return System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\DBConnectionString";
        }
        public static string getConnectionString(string connectionFile)
        {
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
