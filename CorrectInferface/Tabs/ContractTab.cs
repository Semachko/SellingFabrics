using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CorrectInferface
{
    public partial class MainWindow
    {
        //
        // Creating contract
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
        private void AddNewExporter_Click_1(object sender, EventArgs e)
        {
            pageObjectAdding3.Show();
        }
        private void AddNewClient_Click_1(object sender, EventArgs e)
        {
            pageObjectAdding4.Show();
        }


    }
}
