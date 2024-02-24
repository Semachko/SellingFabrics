using Microsoft.Reporting.WinForms;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CorrectInferface
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();

            // Access to tabs according to user rights
            if (ConnectString.login == "StorageWorker")
            {
                // Access to Fabric tab only
                tabControl1.TabPages[1].Enabled = false;
                tabControl1.TabPages[2].Enabled = false;
                tabControl1.TabPages[3].Enabled = false;
                Exporters.Enabled = false;
                Contracts.Enabled = false;
                Invoices.Enabled = false;
                Clients.Enabled = false;
            }
            if (ConnectString.login == "Director")
            {
                // Access to all Reports and only to Contracts tab
                tabControl1.TabPages[2].Enabled = false;
                tabControl1.TabPages[3].Enabled = false;
                tabControl1.TabPages[4].Enabled = false;
                FillCodesDirector();
            }
            if (ConnectString.login == "Accountant")
            {
                // Access to Invoice tabs
                tabControl1.TabPages[1].Enabled = false;
                tabControl1.TabPages[4].Enabled = false;
                Exporters.Enabled = false;
                Contracts.Enabled = false;
                FillCodesAccountant();
            }
            if (ConnectString.login == "sa")
            {
                FillCodesDirector();
                FillCodesAccountant();
            }
        }

        //
        // Filling comboBoxes with relevant data
        public void FillCodes(ComboBox comboBox, string poleName, string tableName, string query = "")
        {
            if (query == "") query = $"SELECT {poleName} FROM {tableName}";
            using (SqlConnection connection = new SqlConnection(ConnectString.connectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                comboBox.DisplayMember = poleName;
                comboBox.ValueMember = poleName;
                comboBox.DataSource = dataTable;
            }
        }
        public void FillCodesDirector()
        {
            FillCodes(codeExp, "code_object", "exporter");
            FillCodes(codePidp, "code_object", "factory");
        }
        public void FillCodesAccountant()
        {
            FillCodes(codClient, "code_object", "client");
            FillCodes(codePidp1, "code_object", "factory");
            FillCodes(codeContrInv, "code_contract", "contract_sale");
            FillCodes(venderInv, "vender_code", "textile", "SELECT DISTINCT vender_code FROM textile");
            FillCodes(venderFact, "vender_code", "textile", "SELECT DISTINCT vender_code FROM textile");
            FillCodes(colirFact, "color", "textile", $"SELECT color FROM textile WHERE vender_code='{venderFact.Text}'");
            using (SqlConnection connection = new SqlConnection(ConnectString.connectionString))
            {
                //
                // Counting invoices
                //
                string query = "SELECT MAX(code_invoice) FROM invoice";
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                if (command.ExecuteScalar().ToString() == "")
                    codeInv.Text = "1";
                else codeInv.Text = Convert.ToString(int.Parse(command.ExecuteScalar().ToString()) + 1);
                connection.Close();
            }
            FillInvoiceRow();
        }
        public void FillInvoiceRow()
        {
            FillCodes(venderInv, "vender_code", "textile", "SELECT DISTINCT vender_code FROM textile");
            FillCodes(codeInvRow, "code_invoice", "invoice");
            codeInvRow.SelectedIndex = -1;
            venderInv.SelectedIndex = -1;
            colirInv.SelectedIndex = -1;
            venderFact.SelectedIndex = -1;
            colirFact.SelectedIndex = -1;
        }
        
        //
        // Inserting data in database
        private void Insert(string table, string[] dataFields, object[] appFields)
        {
            using (SqlConnection connection = new SqlConnection(ConnectString.connectionString)) {
                string sql = $"INSERT INTO {table} ({string.Join(", ", dataFields)}) VALUES (@{string.Join(", @", dataFields)})";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    for (int i = 0; i < dataFields.Length; i++)
                        command.Parameters.AddWithValue($"@{dataFields[i]}", appFields[i]);
                    
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        //
        // Hiding reportViewer when moving from the first tab
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex != 0)
                reportViewer1.Hide();
            else reportViewer1.Show();
        }
        private void ObjectsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }


        //Button to go back to LoginForm
        private void BackButton_Click_1(object sender, EventArgs e)
        {
            BackToLoginForm();
        }
        private void BackToLoginForm()
        {
            Hide();
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
        }



    }
}
