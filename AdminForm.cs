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
        bool checkOnAlfabet = false;

        private void AdminForm_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "mainDatabaseDataSet1.PlaceType". При необходимости она может быть перемещена или удалена.
            this.placeTypeTableAdapter.Fill(this.mainDatabaseDataSet1.PlaceType);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "mainDatabaseDataSet1.Hall". При необходимости она может быть перемещена или удалена.
            this.hallTableAdapter.Fill(this.mainDatabaseDataSet1.Hall);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "mainDatabaseDataSet1.Tickets". При необходимости она может быть перемещена или удалена.
            this.ticketsTableAdapter.Fill(this.mainDatabaseDataSet1.Tickets);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "mainDatabaseDataSet1.Events". При необходимости она может быть перемещена или удалена.
            this.eventsTableAdapter.Fill(this.mainDatabaseDataSet1.Events);
          
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
                string sqlQuery = "SELECT * FROM V_Tickets_2";
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

        #region Page-1
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

        #endregion


        
        private void button2_Click(object sender, EventArgs e)
        {
            MainMenuCommand.Set.Tickets.DeleteFromId();
            UpdateDataGrid2();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MainMenuCommand.Set.Tickets.UpdateData(comboBox1.SelectedValue.ToString(), comboBox3.SelectedValue.ToString(), textBox2.Text, checkBox1.Checked);
            UpdateDataGrid2();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            MainMenuCommand.Set.Tickets.CreateNew(comboBox1.SelectedValue.ToString(), comboBox3.SelectedValue.ToString(), textBox2.Text, checkBox1.Checked);
            UpdateDataGrid2();
        }
        private void dataGridView2_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedCells.Count > 0)
            {
                int rowIndex = dataGridView2.SelectedCells[0].RowIndex;
                DataGridViewCell selectedCell = dataGridView2.Rows[rowIndex].Cells[0];

                // Проверяем, что значение ячейки не равно null
                if (selectedCell.Value != null)
                {
                    MainMenuCommand.Set.AddNewidFromAdminTicketDataGrid(selectedCell.Value.ToString());
                }

            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(textBox2.Text, "^[0-9]+$") && !checkOnAlfabet)
            {
                checkOnAlfabet = true;
                MessageBox.Show("Пожалуйста, введите только цифры.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox2.Text = null; // Очистить текстовое поле, если введены буквы                
            }
            checkOnAlfabet = false;
        }
    }
}
