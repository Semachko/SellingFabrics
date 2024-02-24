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
        // Creating new vender
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
        private void venderInv_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            // Filling comboBox 'colirInv' due to selected vender
            if (venderInv.SelectedValue != null)
                FillCodes(colirInv, "color", "textile", $"SELECT color FROM textile WHERE textile.vender_code='{venderInv.SelectedValue.ToString()}'");
        }
        private void pictureBox2_Click_1(object sender, EventArgs e)
        {
            BackToLoginForm();
        }

    }
}
