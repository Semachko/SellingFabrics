using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CorrectInferface
{
    public partial class MainWindow
    {
        private void CreateRowInvoiceButton_Click_1(object sender, EventArgs e)
        {
            try
            {
                int rows = 1;
                using (SqlConnection connection2 = new SqlConnection(ConnectString.connectionString))
                {
                    //
                    // Counting rows in specific invoice
                    //
                    string query = $"SELECT MAX(row_invoice) FROM row_invoice WHERE code_invoice={codeInvRow.Text}";
                    SqlCommand command2 = new SqlCommand(query, connection2);
                    connection2.Open();

                    if (command2.ExecuteScalar().ToString() != "")
                        rows = 1 + (int)command2.ExecuteScalar();
                    connection2.Close();
                }
                //
                // Creating new row in invoice
                //
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


        //
        // Creating invoice
        //
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

        private void pictureBox3_Click_1(object sender, EventArgs e)
        {
            BackToLoginForm();
        }
    }

}
