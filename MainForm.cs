using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DvorecKulturi
{
    public partial class MainForm : Form
    {
        #region UserPage-1
        public MainForm()
        {
            InitializeComponent();
            UpdateUserEvent_dataGrid();
        }

        private void ClearSearch_btn_Click(object sender, EventArgs e) //Очищение поля поиска
        {
            Search_textbox.Text = "";
            Search_textbox.Text = null;
            Search_btn_event(sender, e);
        }

        private void UpdateUserEvent_dataGrid()
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
                        UserEvent_dataGrid.DataSource = dataTable;
                    }
                }
            }

            /*int totalWidth = UserEvent_dataGrid.Width;

            UserEvent_dataGrid.Columns["№"].Width = totalWidth / 12;
            UserEvent_dataGrid.Columns["Зал"].Width = totalWidth / 5;
            UserEvent_dataGrid.Columns["Название мероприятия"].Width = totalWidth / 4;
            UserEvent_dataGrid.Columns["Дата"].Width = totalWidth / 6;
            UserEvent_dataGrid.Columns["Время"].Width = totalWidth / 8;
            UserEvent_dataGrid.Columns["Стоимость"].Width = totalWidth / 7;*/

        }

        private void Search_btn_event(object sender, EventArgs e)
        {
            string searchText = Search_textbox.Text.ToLower();
            if (searchText != null)
            {
                UserEvent_dataGrid.CurrentCell = null;
                foreach (DataGridViewRow row in UserEvent_dataGrid.Rows)
                {
                    if (row.Cells[1].Value != null && row.Cells[1].Value.ToString().ToLower().Contains(searchText))
                    {
                        row.Visible = true;
                    }
                    else
                    {
                        row.Visible = false;
                    }
                }
            }
            else
            {
                foreach (DataGridViewRow row in UserEvent_dataGrid.Rows)
                {
                    row.Visible = true;
                }
            }
        }

        private void BuyOnEvent_btn_Click(object sender, EventArgs e)
        {
            int rowIndex = UserEvent_dataGrid.SelectedCells[0].RowIndex;
            DataGridViewCell selectedCell = UserEvent_dataGrid.Rows[rowIndex].Cells[0];
            object cellValue = selectedCell.Value;
            MainMenuCommand.Set.V_Events.AddNewId(cellValue.ToString());
            if (MainMenuCommand.Get.V_Events.CheckNewId())
            {
                tabControl1.SelectTab(tabPage2);
                LoadDataByEventId();
            }
            else
            {
                MessageBox.Show("Мероприятие не выбрано.\nПопробуйте снова выбрать в окне", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        #endregion

        #region UserPage-2

        public void LoadDataByEventId()
        {
            using (SqlConnection connection = new SqlConnection(Settings.SQLConnected.GetSQLConnect()))
            {
                connection.Open();
                string query = $"SELECT * FROM V_Tickets WHERE id_Event = {MainMenuCommand.Get.V_Events.Newid()} AND Sales = 0";                

                using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                {
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    UserTickets_datagrid.DataSource = dataTable;
                }                
            }
            
            UserTickets_datagrid.CurrentCell = null;
            UserTickets_datagrid.Columns["id_Event"].Visible = false;
            UserTickets_datagrid.Columns["Sales"].Visible = false;
        }


        #endregion

        
    }
}
