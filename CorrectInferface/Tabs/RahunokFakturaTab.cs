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

        // 
        // Filling comboBox 'colirfact' with values due to selected index in 'venderFact'
        // 
        private void venderFact_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (venderFact.SelectedValue != null)
                FillCodes(colirFact, "color", "textile", $"SELECT color FROM textile WHERE textile.vender_code='{venderFact.Text}'");
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            BackToLoginForm();
        }
    }
}
