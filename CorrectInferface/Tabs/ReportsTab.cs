using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CorrectInferface
{
    public partial class MainWindow
    {
        //
        //
        // Filling Reports with data
        //
        // Using ReportViewer library
        //
        //

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
        private void pictureBox4_Click_1(object sender, EventArgs e)
        {
            BackToLoginForm();
        }
    }
}
