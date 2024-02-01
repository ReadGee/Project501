using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DvorecKulturi
{
    internal class MainMenuCommand
    {
        #region Variables

        static int idFromUserEventDataGrid;

        static int idFromUserTicketsDataGrid;

        #endregion
        public static class Get
        {
            public static class V_Events
            {
                
            }
            public static int IdFromUserEventDataGrid()
            {
                return idFromUserEventDataGrid;
            }
            public static bool CheckidFromUserEventDataGrid()
            {
                if (idFromUserEventDataGrid != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            public static bool CheckidFromUserTicketsDataGrid()
            {
                if (idFromUserTicketsDataGrid != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            public static int IdFromUserTicketsDataGrid()
            {
                return idFromUserTicketsDataGrid;
            }
        }
        public static class Set
        {
            public static class PurchaseRequests
            {
                public static void AddNewRequests(string phone, string fullname)
                {
                    using (SqlConnection connection = new SqlConnection(Settings.SQLConnected.GetSQLConnect()))
                    {
                        connection.Open();

                        // Определение нового ID
                        string getIdQuery = "SELECT ISNULL(MAX(Id), 0) + 1 FROM [dbo].[PurchaseRequests]";
                        SqlCommand getIdCommand = new SqlCommand(getIdQuery, connection);
                        int newId = Convert.ToInt32(getIdCommand.ExecuteScalar());

                        // Вставка новой записи
                        string insertQuery = "INSERT INTO [dbo].[PurchaseRequests] (Id, Phone, Fullname, BuyTicket, Date) VALUES (@Id, @Phone, @Fullname, @BuyTicket, @Date)";
                        SqlCommand insertCommand = new SqlCommand(insertQuery, connection);
                        insertCommand.Parameters.AddWithValue("@Id", newId);
                        insertCommand.Parameters.AddWithValue("@Phone", phone);
                        insertCommand.Parameters.AddWithValue("@Fullname", fullname);
                        insertCommand.Parameters.AddWithValue("@BuyTicket", Convert.ToInt32(idFromUserTicketsDataGrid));
                        insertCommand.Parameters.AddWithValue("@Date", DateTime.Now);


                        insertCommand.ExecuteNonQuery();

                        // Обновление значения столбца Sales в таблице Tickets
                        string updateSalesQuery = "UPDATE [dbo].[Tickets] SET Sales = 1 WHERE Id = @TicketId";
                        SqlCommand updateSalesCommand = new SqlCommand(updateSalesQuery, connection);
                        updateSalesCommand.Parameters.AddWithValue("@TicketId", Convert.ToInt32(idFromUserTicketsDataGrid));

                        updateSalesCommand.ExecuteNonQuery();
                    }

                }

                
            }
            public static class V_Events
            {
                
            }

            public static void AddNewidFromUserEventDataGrid(string id)
            {
                try
                {
                    idFromUserEventDataGrid = int.Parse(id);
                }
                catch
                {
                    MessageBox.Show("Ошибка преобразования в int \nАдрес MainMenuCommand.cs/Set/AddNewidFromUserEventDataGrid \nidFromUserEventDataGrid = int.Parse(id);", "КРИТИЧЕСКАЯ ОШИБКА", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            public static void AddNewidFromUserEventDataGrid(int id)
            {
                try
                {
                    idFromUserEventDataGrid = id;
                }
                catch
                {
                    MessageBox.Show("Ошибка преобразования в int \nАдрес Menu.cs/Set/AddNewidFromUserEventDataGrid \nidFromUserEventDataGrid = int.Parse(id);", "КРИТИЧЕСКАЯ ОШИБКА", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            public static void AddNewIdFromUserTicketsDataGrid(string id)
            {
                try
                {
                    idFromUserTicketsDataGrid = Convert.ToInt32(id);
                }
                catch
                {
                    MessageBox.Show("Ошибка преобразования в int \nАдрес Menu.cs/Set/AddNewIdFromDataGrid \nidFromUserTicketsDataGrid = Convert.ToInt32(id);", "КРИТИЧЕСКАЯ ОШИБКА", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
