using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace CorrectInferface
{
    public partial class PageObjectAdding : UserControl
    {
        //
        //
        // Window to add new Exporter/Client
        //
        //
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

        //
        // Adding new Exporter/Client to database
        private void button2_Click(object sender, EventArgs e)
        {
            try {
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
            //
            // Refreshing comboBoxes in MainWindow
            if (ConnectString.login == "Director")
            {
                MainWindow objectsForm = (MainWindow)Application.OpenForms["ObjectsForm"];
                objectsForm.FillCodesDirector();
            }
            if (ConnectString.login == "Accountant")
            {
                MainWindow objectsForm = (MainWindow)Application.OpenForms["ObjectsForm"];
                objectsForm.FillCodesAccountant();
            }
            if (ConnectString.login == "sa")
            {
                MainWindow objectsForm = (MainWindow)Application.OpenForms["ObjectsForm"];
                objectsForm.FillCodesAccountant();
                objectsForm.FillCodesDirector();
            }
        }
    }
}
