using OfficeOpenXml;
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
            UpdateDataGrid3();
            UpdateDataGrid4();
            UpdateDataGrid5();

        }
        private void AdminForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }


        #region UpdateDataGrid's
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
        private void UpdateDataGrid3()
        {
            using (SqlConnection connection = new SqlConnection(Settings.SQLConnected.GetSQLConnect()))
            {
                connection.Open();
                string sqlQuery = "SELECT * FROM V_Events";
                using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        dataGridView3.DataSource = dataTable;
                    }
                }
            }
        }
        private void UpdateDataGrid4()
        {
            using (SqlConnection connection = new SqlConnection(Settings.SQLConnected.GetSQLConnect()))
            {
                connection.Open();
                string sqlQuery = "SELECT Id as '№', Name as 'Название места', NumberOfSeats as 'Количество мест', Description as 'Описание' FROM PlaceType";
                using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        dataGridView4.DataSource = dataTable;
                    }
                }
            }
        }

        private void UpdateDataGrid5()
        {
            using (SqlConnection connection = new SqlConnection(Settings.SQLConnected.GetSQLConnect()))
            {
                connection.Open();
                string sqlQuery = "SELECT Id as '№', Name as 'Название зала', Description as 'Описание' FROM Hall";
                using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        dataGridView5.DataSource = dataTable;
                    }
                }
            }
        }
        #endregion


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


        #region Page-2
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

        #endregion


        #region Page-3
        private void button7_Click(object sender, EventArgs e)
        {
            MainMenuCommand.Set.Events.DeleteFromId();
            UpdateDataGrid3();
        }

        private void dataGridView3_SelectionChanged(object sender, EventArgs e)
        {
            
            if (dataGridView3.SelectedCells.Count > 0)
            {
                int rowIndex = dataGridView3.SelectedCells[0].RowIndex;
                DataGridViewCell selectedCell = dataGridView3.Rows[rowIndex].Cells[0];

                // Проверяем, что значение ячейки не равно null
                if (selectedCell.Value != null)
                {
                    MainMenuCommand.Set.AddNewidFromAdminEventsDataGrid(selectedCell.Value.ToString());
                }

            }
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            MainMenuCommand.Set.Events.UpdateData(comboBox4.SelectedValue.ToString(), textBox1.Text, dateTimePicker1.Value.ToString(), maskedTextBox1.Text, "от " + maskedTextBox2.Text + " рублей");
            UpdateDataGrid3();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MainMenuCommand.Set.Events.CreateNew(comboBox4.SelectedValue.ToString(), textBox1.Text, dateTimePicker1.Value.ToString(), maskedTextBox1.Text, "от " + maskedTextBox2.Text + " рублей");
            UpdateDataGrid3();
        }


        #endregion


        #region Page-4
        private void dataGridView4_SelectionChanged(object sender, EventArgs e)
        {

            if (dataGridView4.SelectedCells.Count > 0)
            {
                int rowIndex = dataGridView4.SelectedCells[0].RowIndex;
                DataGridViewCell selectedCell = dataGridView4.Rows[rowIndex].Cells[0];

                // Проверяем, что значение ячейки не равно null
                if (selectedCell.Value != null)
                {
                    MainMenuCommand.Set.AddNewidFromAdminPlaceTypeDataGrid(selectedCell.Value.ToString());
                }

            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            MainMenuCommand.Set.PlaceType.DeleteFromId();
            UpdateDataGrid4();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            MainMenuCommand.Set.PlaceType.UpdateData(textBox3.Text, textBox4.Text, maskedTextBox3.Text);
            UpdateDataGrid4();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            MainMenuCommand.Set.PlaceType.CreateNew(textBox3.Text, textBox4.Text, maskedTextBox3.Text);
            UpdateDataGrid4();
        }


        #endregion


        #region Page-5
        private void button13_Click(object sender, EventArgs e)
        {
            MainMenuCommand.Set.Hall.DeleteFromId();
            UpdateDataGrid5();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            MainMenuCommand.Set.Hall.UpdateData(textBox6.Text, textBox5.Text);
            UpdateDataGrid5();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            MainMenuCommand.Set.Hall.CreateNew(textBox6.Text, textBox5.Text);
            UpdateDataGrid5();
        }

        private void dataGridView5_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView5.SelectedCells.Count > 0)
            {
                int rowIndex = dataGridView5.SelectedCells[0].RowIndex;
                DataGridViewCell selectedCell = dataGridView5.Rows[rowIndex].Cells[0];

                // Проверяем, что значение ячейки не равно null
                if (selectedCell.Value != null)
                {
                    MainMenuCommand.Set.AddNewidFromAdminHallDataGrid(selectedCell.Value.ToString());
                }

            }
        }
        #endregion 

        public static void ExportTicketsToExcel(int selectedEventId)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(Settings.SQLConnected.GetSQLConnect()))
                {
                    connection.Open();

                    // SQL-запрос для получения данных о купленных билетах для выбранного мероприятия
                    string query = "SELECT * FROM V_Tickets WHERE id_Event = @selectedEventId AND Sales = 1";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@selectedEventId", selectedEventId);

                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);

                            // Создание нового ExcelPackage
                            using (ExcelPackage excelPackage = new ExcelPackage())
                            {
                                // Добавление листа в ExcelPackage
                                ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets.Add("Tickets");

                                // Заполнение листа данными из DataTable
                                worksheet.Cells.LoadFromDataTable(dataTable, true);

                                // Сохранение файла Excel
                                string fileName = $"TicketReport_Event_{selectedEventId}.xlsx";
                                excelPackage.SaveAs(new System.IO.FileInfo(fileName));

                                MessageBox.Show($"Отчет сохранен в файл: {fileName}", "Успешно", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonExportToExcel_Click(object sender, EventArgs e)
        {
            if (comboBox2.SelectedValue != null && int.TryParse(comboBox2.SelectedValue.ToString(), out int selectedEventId))
            {
                ExportTicketsToExcel(selectedEventId);
            }
            else
            {
                MessageBox.Show("Выберите мероприятие из списка", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
