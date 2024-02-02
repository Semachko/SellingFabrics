using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace CorrectInferface
{
    public partial class PageObjectAdding : UserControl
    {
        public PageObjectAdding()
        {
            InitializeComponent();
            Scale(new SizeF(1, 1));
            if (ConnectString.login == "Director")
                typeObject.Text = "exporter";
            if (ConnectString.login == "Accountant")
                typeObject.Text = "client";
            Hide();
        }

        private void BackButton_Click_1(object sender, EventArgs e)
        {
            Hide();
            BringToFront();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectString.connectionString))
                {
                    string sql = $"INSERT INTO object_ (INN,name_object,bank_account,adress,сontact_information,type_object) VALUES (@INN,@name_object,@bank_account,@adress,@сontact_information,@type_object)";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {

                        command.Parameters.AddWithValue("@INN", inn.Text);
                        command.Parameters.AddWithValue("@name_object", nazvaObject.Text);
                        command.Parameters.AddWithValue("@bank_account", bankAcc.Text);
                        command.Parameters.AddWithValue("@adress", adresa.Text);
                        command.Parameters.AddWithValue("@сontact_information", contactInfo.Text);
                        command.Parameters.AddWithValue("@type_object", typeObject.Text);


                        connection.Open();
                        command.ExecuteNonQuery();
                        MessageBox.Show("Новий об'єкт успішно додано.");
                    }

                }

            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            if (ConnectString.login == "Director")
            {
                ObjectsForm objectsForm = (ObjectsForm)Application.OpenForms["ObjectsForm"];
                objectsForm.FillCodesDirector();
            }
            if (ConnectString.login == "Accountant")
            {
                ObjectsForm objectsForm = (ObjectsForm)Application.OpenForms["ObjectsForm"];
                objectsForm.FillCodesAccountant();
            }
            if (ConnectString.login == "sa")
            {
                ObjectsForm objectsForm = (ObjectsForm)Application.OpenForms["ObjectsForm"];
                objectsForm.FillCodesAccountant();
                objectsForm.FillCodesDirector();
            }

        }

    }
}
