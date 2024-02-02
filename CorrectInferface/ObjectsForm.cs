using Microsoft.Reporting.WinForms;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CorrectInferface
{
    public partial class ObjectsForm : Form
    {
        public ObjectsForm()
        {
            InitializeComponent();

            if (ConnectString.login == "StorageWorker")
            {
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
                tabControl1.TabPages[2].Enabled = false;
                tabControl1.TabPages[3].Enabled = false;
                tabControl1.TabPages[4].Enabled = false;
                FillCodesDirector();
            }
            if (ConnectString.login == "Accountant")
            {
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
        private void venderInv_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (venderInv.SelectedValue != null)
                FillCodes(colirInv, "color", "textile", $"SELECT color FROM textile WHERE textile.vender_code='{venderInv.SelectedValue.ToString()}'");
        }
        private void venderFact_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (venderFact.SelectedValue != null)
                FillCodes(colirFact, "color", "textile", $"SELECT color FROM textile WHERE textile.vender_code='{venderFact.Text}'");
        }



        private void Insert(string table, string[] dataFields, object[] appFields)
        {

            using (SqlConnection connection = new SqlConnection(ConnectString.connectionString))
            {
                string sql = $"INSERT INTO {table} ({string.Join(", ", dataFields)}) VALUES (@{string.Join(", @", dataFields)})";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    for (int i = 0; i < dataFields.Length; i++)
                    {
                        command.Parameters.AddWithValue($"@{dataFields[i]}", appFields[i]);
                    }
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }

        }
        private void CreateContract_Click_1(object sender, EventArgs e)
        {
            try
            {
                string[] dataFields = { "code_contract", "subject_contract", "price_contract", "validity", "code_object_P", "code_object_E" };
                object[] appFields = { codeContract.Text, predCon.Text, cina.Text, termin.Value, codePidp.Text, codeExp.Text };
                Insert("contract_sale", dataFields, appFields);
                MessageBox.Show("Новий контракт успішно створено.");
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        private void createVenderButton_Click_1(object sender, EventArgs e)
        {
            try
            {
                string[] dataFields = { "vender_code", "color", "country_manufacturer", "density", "composition", "amount_storage", "price_storage" };
                object[] appFields = { vender.Text, textileColor.Text, krainavyrob.Text, schilnist.Text, skladtkan.Text, 0, 0 };
                Insert("textile", dataFields, appFields);

                vender.Text = "";
                textileColor.Text = "";
                krainavyrob.Text = "";
                schilnist.Text = "";
                skladtkan.Text = "";
                MessageBox.Show("Нову тканину успішно додано.");
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        private void CreateInvoiceButton_Click_1(object sender, EventArgs e)
        {
            try
            {
                string[] dataFields = { "code_contract", "date_invoice" };
                object[] appFields = { codeContrInv.Text, dateInv.Value };
                Insert("invoice", dataFields, appFields);
                FillInvoiceRow();

                codeInv.Text = (int.Parse(codeInv.Text) + 1).ToString();
                MessageBox.Show("Новий інвойс успішно створено.");
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        private void CreateRowInvoiceButton_Click_1(object sender, EventArgs e)
        {
            try
            {
                int rows = 1;
                using (SqlConnection connection2 = new SqlConnection(ConnectString.connectionString))
                {
                    string query = $"SELECT MAX(row_invoice) FROM row_invoice WHERE code_invoice={codeInvRow.Text}";
                    SqlCommand command2 = new SqlCommand(query, connection2);
                    connection2.Open();

                    if (command2.ExecuteScalar().ToString() != "")
                        rows = 1 + (int)command2.ExecuteScalar();
                    connection2.Close();
                }
                string[] dataFields = { "code_invoice", "row_invoice", "UKTZED", "vender_code", "amount", "price", "color" };
                object[] appFields = { int.Parse(codeInvRow.Text), rows, uktzed.Text, venderInv.Text, int.Parse(kilkistInv.Text), float.Parse(cinainv.Text), colirInv.Text };
                Insert("row_invoice", dataFields, appFields);



                vender.Text = "";
                textileColor.Text = "";
                krainavyrob.Text = "";
                schilnist.Text = "";
                skladtkan.Text = "";
                MessageBox.Show("Новий рядок успішно додано.");
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        private void CreateFactureButton_Click_1(object sender, EventArgs e)
        {
            try
            {
                string[] dataFields = { "vender_code", "color", "amount_check", "code_object_K", "code_object_P" };
                object[] appFields = { venderFact.Text, colirFact.Text, kilkistFact.Text, codClient.Text, codePidp1.Text };
                Insert("check_facture", dataFields, appFields);

                venderFact.SelectedIndex = -1;
                colirFact.SelectedIndex = -1;
                kilkistFact.Text = "";
                MessageBox.Show("Новий рахунок-фактуру успішно створено.");
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }




        private void FillZvit(SqlCommand command, string reportPath)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectString.connectionString))
                {
                    command.Connection = connection;
                    SqlDataAdapter d = new SqlDataAdapter(command);
                    DataTable dt = new DataTable();
                    d.Fill(dt);
                    reportViewer1.LocalReport.DataSources.Clear();
                    ReportDataSource source = new ReportDataSource("DataSet1", dt);
                    reportViewer1.LocalReport.ReportPath = reportPath;
                    reportViewer1.LocalReport.DataSources.Add(source);
                    reportViewer1.RefreshReport();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void Exporters_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("select type_object, name_object,  code_object,  INN, bank_account, adress, сontact_information from object_ where type_object='factory' or type_object='exporter'");
            FillZvit(command, @"Report1.rdlc");
        }
        private void Contracts_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("select  code_contract, name_object, price_contract, validity, subject_contract from contract_sale, object_, exporter where contract_sale.code_object_E=exporter.code_object and exporter.code_object=object_.code_object");
            FillZvit(command, @"Report2.rdlc");
        }
        private void Invoices_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("select invoice.code_invoice, row_invoice,  UKTZED,  vender_code, color, amount, price, date_invoice from invoice,row_invoice where invoice.code_invoice=row_invoice.code_invoice");
            FillZvit(command, @"Report3.rdlc");
        }
        private void Textiles_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("select  vender_code, color, amount_storage, price_storage, density, composition, country_manufacturer from textile");
            FillZvit(command, @"Report4.rdlc");
        }
        private void Clients_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("select type_object, name_object,  code_object,  INN, bank_account, adress, сontact_information from object_ where type_object='factory' or type_object='client'");
            FillZvit(command, @"Report5.rdlc");
        }
        private void Factures_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("select date_check,code_check_facture,name_object,INN, vender_code,color,amount_check from check_facture, object_ where check_facture.code_object_K=object_.code_object");
            FillZvit(command, @"Report6.rdlc");
        }





        private void ObjectsForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
        private void AddNewExporter_Click_1(object sender, EventArgs e)
        {
            pageObjectAdding3.Show();
        }
        private void AddNewClient_Click_1(object sender, EventArgs e)
        {
            pageObjectAdding4.Show();
        }
        private void BackButton_Click_1(object sender, EventArgs e)
        {
            Hide();
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
        }
        private void pictureBox3_Click_1(object sender, EventArgs e)
        {
            Hide();
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
        }
        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            Hide();
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
        }
        private void pictureBox2_Click_1(object sender, EventArgs e)
        {
            Hide();
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
        }
        private void pictureBox4_Click_1(object sender, EventArgs e)
        {
            Hide();
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
        }
        private void ObjectsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex != 0)
                reportViewer1.Hide();
            else reportViewer1.Show();
        }

    }
}
