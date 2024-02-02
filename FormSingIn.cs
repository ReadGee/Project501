using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DvorecKulturi
{
    public partial class FormSingIn : Form
    {
        public FormSingIn()
        {
            InitializeComponent();
        }


        private void Button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string password = textBox2.Text;

            if (CheckCredentials(username, password))
            {
                // Вход успешен
                AdminForm adminForm = new AdminForm();
                adminForm.Show();
                this.DialogResult = DialogResult.Yes;
                this.Close();
            }
            else
            {
                MessageBox.Show("Неверные учетные данные", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            // Закрытие текущей формы и отправка DialogResult.No
            this.DialogResult = DialogResult.No;
            this.Close();
        }

        private bool CheckCredentials(string username, string password)
        {
            // Проверка учетных данных в базе данных
            using (SqlConnection connection = new SqlConnection(Settings.SQLConnected.GetSQLConnect()))
            {
                connection.Open();

                string query = "SELECT COUNT(*) FROM Admins WHERE Username = @Username AND Password = @Password";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Username", username);
                    command.Parameters.AddWithValue("@Password", password);

                    int count = Convert.ToInt32(command.ExecuteScalar());

                    return count > 0;
                }
            }
        }
    }
}
