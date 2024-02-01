using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
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
            try
            {
                int rowIndex = UserEvent_dataGrid.SelectedCells[0].RowIndex;
                DataGridViewCell selectedCell = UserEvent_dataGrid.Rows[rowIndex].Cells[0];
                if (selectedCell.Value.ToString() != null)
                {
                    MainMenuCommand.Set.AddNewidFromUserEventDataGrid(selectedCell.Value.ToString());
                    if (MainMenuCommand.Get.CheckidFromUserEventDataGrid())
                    {
                        tabControl1.SelectTab(tabPage2);
                        LoadDataByEventId();

                    }
                }
                else
                {
                    MessageBox.Show("Мероприятие не выбрано.\nПопробуйте снова выбрать в окне", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch
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
                string query = $"SELECT * FROM V_Tickets WHERE id_Event = {MainMenuCommand.Get.IdFromUserEventDataGrid()} AND Sales = 0";                

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
        private void BuyTickets_btn_Click(object sender, EventArgs e)
        {
            try
            {


                int rowIndex = UserTickets_datagrid.SelectedCells[0].RowIndex;
                DataGridViewCell selectedCell = UserTickets_datagrid.Rows[rowIndex].Cells[0];

                if (selectedCell.Value.ToString() != null)
                {
                    MainMenuCommand.Set.AddNewIdFromUserTicketsDataGrid(selectedCell.Value.ToString());
                    if (MainMenuCommand.Get.CheckidFromUserEventDataGrid())
                    {
                        MainMenuCommand.Set.PurchaseRequests.AddNewRequests(Phone_textbox.Text, FioOnNew_textbox.Text);
                        tabControl1.SelectTab(tabPage3);
                    }
                }
                else
                {
                    MessageBox.Show("Билет не выбран.\nПопробуйте снова выбрать в окне", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch
            {
                MessageBox.Show("Билет не выбран.\nПопробуйте снова выбрать в окне", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }



        #endregion

        private void label3_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(tabPage1);
        }

        private void SingIn_btn_Click(object sender, EventArgs e)
        {
            AdminForm adminForm = new AdminForm();
            adminForm.Show();
        }
    }
}
