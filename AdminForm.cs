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
    public partial class AdminForm : Form
    {
        public AdminForm()
        {
            InitializeComponent();
        }

        private void AdminForm_Load(object sender, EventArgs e)
        {
            UpdateDataGrid1();
            UpdateDataGrid2();

        }
        private void UpdateDataGrid1()
        {
            using (SqlConnection connection = new SqlConnection(Settings.SQLConnected.GetSQLConnect()))
            {
                connection.Open();
                string sqlQuery = "SELECT Id as '№', Phone as 'Телефон', Fullname as 'ФИО', BuyTicket as 'Номер Билета', Date as 'Дата' FROM PurchaseRequests";
                using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        dataGridView1.DataSource = dataTable;
                    }
                }
            }

        }
        private void UpdateDataGrid2()
        {
            using (SqlConnection connection = new SqlConnection(Settings.SQLConnected.GetSQLConnect()))
            {
                connection.Open();
                string sqlQuery = $"SELECT * FROM V_Tickets";
                using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        dataGridView2.DataSource = dataTable;
                    }
                }
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int rowIndex = dataGridView1.SelectedCells[0].RowIndex;
                DataGridViewCell selectedCell = dataGridView1.Rows[rowIndex].Cells[0];
                if (selectedCell.Value.ToString() != null)
                {
                    MainMenuCommand.Set.PurchaseRequests.DeleteFromId(selectedCell.Value.ToString());
                    UpdateDataGrid1();
                }
                else
                {
                    MessageBox.Show("Заявка не выбрана.\nПопробуйте снова выбрать в окне", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch
            {
                MessageBox.Show("Заявка не выбрана.\nПопробуйте снова выбрать в окне", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
