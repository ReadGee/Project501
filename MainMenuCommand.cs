using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static DvorecKulturi.MainMenuCommand.Set;

namespace DvorecKulturi
{
    internal class MainMenuCommand
    {
        #region Variables

        static int idFromUserEventDataGrid;

        static int idFromUserTicketsDataGrid;

        static int idFromAdminTicketDataGrid;

        static int idFromAdminEventsDataGrid;

        static int idFromAdminPlaceTypeDataGrid;

        static int idFromAdminHallDataGrid;

        #endregion
        public static class Get
        {
            public static class V_Events
            {
                
            }
            public static int IdFromAdminPlaceTypeDataGrid()
            {
                return idFromAdminPlaceTypeDataGrid;
            }

            public static int IdFromAdminEventsDataGrid()
            {
                return idFromAdminEventsDataGrid;
            }
            public static int IdFromAdminTicketDataGrid()
            {
                return idFromAdminTicketDataGrid;
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

                public static void DeleteFromId(string id)
                {
                    using (SqlConnection connection = new SqlConnection(Settings.SQLConnected.GetSQLConnect()))
                    {
                        connection.Open();

                        // Запрос на удаление записи по Id
                        string deleteQuery = "DELETE FROM [dbo].[PurchaseRequests] WHERE Id = @Id";
                        SqlCommand deleteCommand = new SqlCommand(deleteQuery, connection);
                        deleteCommand.Parameters.AddWithValue("@Id", Convert.ToInt32(id));

                        // Выполнение запроса
                        deleteCommand.ExecuteNonQuery();

                    }
                }
                
            }
            public static class Tickets
            {
                public static void UpdateData(string id_Events, string id_PlaceType, string cost, bool sale)
                {
                    using (SqlConnection connection = new SqlConnection(Settings.SQLConnected.GetSQLConnect()))
                    {
                        connection.Open();

                        // SQL-запрос на обновление данных в таблице Tickets
                        string updateQuery = "UPDATE [dbo].[Tickets] SET id_Event = @id_Event, id_PlaceType = @id_PlaceType, Cost = @Cost, Sales = @Sales WHERE Id = @TicketId";
                        SqlCommand updateCommand = new SqlCommand(updateQuery, connection);

                        
                        updateCommand.Parameters.AddWithValue("@id_Event", Convert.ToInt32(id_Events));
                        updateCommand.Parameters.AddWithValue("@id_PlaceType", Convert.ToInt32(id_PlaceType));
                        updateCommand.Parameters.AddWithValue("@Cost", Convert.ToDecimal(cost));
                        updateCommand.Parameters.AddWithValue("@Sales", sale);
                        updateCommand.Parameters.AddWithValue("@TicketId", idFromAdminTicketDataGrid);

                        // Выполнение запроса
                        updateCommand.ExecuteNonQuery();
                    }
                }
                public static void DeleteFromId(string id)
                {
                    using (SqlConnection connection = new SqlConnection(Settings.SQLConnected.GetSQLConnect()))
                    {
                        connection.Open();

                        // Запрос на удаление записи по Id
                        string deleteQuery = "DELETE FROM [dbo].[Tickets] WHERE Id = @TicketId";
                        SqlCommand deleteCommand = new SqlCommand(deleteQuery, connection);
                        deleteCommand.Parameters.AddWithValue("@TicketId", id);

                        // Выполнение запроса
                        deleteCommand.ExecuteNonQuery();
                    }
                }
                public static void DeleteFromId()
                {
                    using (SqlConnection connection = new SqlConnection(Settings.SQLConnected.GetSQLConnect()))
                    {
                        connection.Open();

                        // Запрос на удаление записи по Id
                        string deleteQuery = "DELETE FROM [dbo].[Tickets] WHERE Id = @TicketId";
                        SqlCommand deleteCommand = new SqlCommand(deleteQuery, connection);
                        deleteCommand.Parameters.AddWithValue("@TicketId", idFromAdminTicketDataGrid);

                        // Выполнение запроса
                        deleteCommand.ExecuteNonQuery();
                    }
                }
                public static void CreateNew(string id_Events, string id_PlaceType, string cost, bool sale)
                {
                    using (SqlConnection connection = new SqlConnection(Settings.SQLConnected.GetSQLConnect()))
                    {
                        connection.Open();
                        // Определение нового ID
                        string getIdQuery = "SELECT ISNULL(MAX(Id), 0) + 1 FROM [dbo].[Tickets]";
                        SqlCommand getIdCommand = new SqlCommand(getIdQuery, connection);
                        int newId = Convert.ToInt32(getIdCommand.ExecuteScalar());

                        string insertQuery = "INSERT INTO [dbo].[Tickets] (Id, id_Event, id_PlaceType, Cost, Sales) VALUES (@Id, @id_Event, @id_PlaceType, @Cost, @Sales)";
                        SqlCommand insertCommand = new SqlCommand(insertQuery, connection);

                        
                        insertCommand.Parameters.AddWithValue("@Id", newId);
                        insertCommand.Parameters.AddWithValue("@id_Event", Convert.ToInt32(id_Events));
                        insertCommand.Parameters.AddWithValue("@id_PlaceType", Convert.ToInt32(id_PlaceType));
                        insertCommand.Parameters.AddWithValue("@Cost", Convert.ToDecimal(cost));
                        insertCommand.Parameters.AddWithValue("@Sales", sale);

                        // Выполнение запроса
                        insertCommand.ExecuteNonQuery();
                    }
                }
            }            
            public static class Events
            {
                public static void CreateNew(string id_Hall, string Name, string Date, string Time, string Cost)
                {
                    using (SqlConnection connection = new SqlConnection(Settings.SQLConnected.GetSQLConnect()))
                    {
                        connection.Open();
                        // Определение нового ID
                        string getIdQuery = "SELECT ISNULL(MAX(Id), 0) + 1 FROM [dbo].[Events]";
                        SqlCommand getIdCommand = new SqlCommand(getIdQuery, connection);
                        int newId = Convert.ToInt32(getIdCommand.ExecuteScalar());

                        string insertQuery = "INSERT INTO [dbo].[Events] (Id, id_Hall, Name, Date, Time, Cost) VALUES (@Id, @id_Hall, @Name, @Date, @Time, @Cost)";
                        SqlCommand insertCommand = new SqlCommand(insertQuery, connection);


                        insertCommand.Parameters.AddWithValue("@id_Hall", Convert.ToInt32(id_Hall));
                        insertCommand.Parameters.AddWithValue("@Name", Name);
                        insertCommand.Parameters.AddWithValue("@Date", DateTime.ParseExact(Date, "dd.MM.yyyy HH:mm:ss", CultureInfo.InvariantCulture));
                        insertCommand.Parameters.AddWithValue("@Time", TimeSpan.ParseExact(Time, "hh\\:mm", CultureInfo.InvariantCulture));
                        insertCommand.Parameters.AddWithValue("@Cost", Cost);
                        insertCommand.Parameters.AddWithValue("@Id", newId);
                        // Выполнение запроса
                        insertCommand.ExecuteNonQuery();
                    }
                }
                public static void UpdateData(string id_Hall, string Name, string Date, string Time, string Cost)
                {
                    using (SqlConnection connection = new SqlConnection(Settings.SQLConnected.GetSQLConnect()))
                    {
                        connection.Open();

                        // SQL-запрос на обновление данных в таблице Events
                        string updateQuery = "UPDATE [dbo].[Events] SET id_Hall = @id_Hall, Name = @Name, Date = @Date, Time = @Time, Cost = @Cost WHERE Id = @EventId";
                        SqlCommand updateCommand = new SqlCommand(updateQuery, connection);

                        // Параметры для предотвращения SQL-инъекций
                        updateCommand.Parameters.AddWithValue("@id_Hall", Convert.ToInt32(id_Hall));
                        updateCommand.Parameters.AddWithValue("@Name", Name);
                        updateCommand.Parameters.AddWithValue("@Date", DateTime.ParseExact(Date, "dd.MM.yyyy HH:mm:ss", CultureInfo.InvariantCulture));
                        updateCommand.Parameters.AddWithValue("@Time", TimeSpan.ParseExact(Time, "hh\\:mm", CultureInfo.InvariantCulture));
                        updateCommand.Parameters.AddWithValue("@Cost", Cost);
                        updateCommand.Parameters.AddWithValue("@EventId", idFromAdminEventsDataGrid);

                        // Выполнение запроса
                        updateCommand.ExecuteNonQuery();
                    }
                }
                public static void DeleteFromId(string id)
                {
                    using (SqlConnection connection = new SqlConnection(Settings.SQLConnected.GetSQLConnect()))
                    {
                        connection.Open();

                        // Запрос на удаление записи по Id
                        string deleteQuery = "DELETE FROM [dbo].[Events] WHERE Id = @Id";
                        SqlCommand deleteCommand = new SqlCommand(deleteQuery, connection);
                        deleteCommand.Parameters.AddWithValue("@Id", id);

                        // Выполнение запроса
                        deleteCommand.ExecuteNonQuery();
                    }
                }
                public static void DeleteFromId()
                {
                    using (SqlConnection connection = new SqlConnection(Settings.SQLConnected.GetSQLConnect()))
                    {
                        connection.Open();

                        // Запрос на удаление записи по Id
                        string deleteQuery = "DELETE FROM [dbo].[Events] WHERE Id = @Id";
                        SqlCommand deleteCommand = new SqlCommand(deleteQuery, connection);
                        deleteCommand.Parameters.AddWithValue("@Id", idFromAdminEventsDataGrid);

                        // Выполнение запроса
                        deleteCommand.ExecuteNonQuery();
                    }
                }
            }
            public static class PlaceType
            {
                public static void CreateNew(string Name, string Description, string NumberOfSeats)
                {
                    using (SqlConnection connection = new SqlConnection(Settings.SQLConnected.GetSQLConnect()))
                    {
                        connection.Open();
                        // Определение нового ID
                        string getIdQuery = "SELECT ISNULL(MAX(Id), 0) + 1 FROM [dbo].[PlaceType]";
                        SqlCommand getIdCommand = new SqlCommand(getIdQuery, connection);
                        int newId = Convert.ToInt32(getIdCommand.ExecuteScalar());

                        string insertQuery = "INSERT INTO [dbo].[PlaceType] (Id, Name, Description, NumberOfSeats) VALUES (@Id, @Name, @Description, @NumberOfSeats)";
                        SqlCommand insertCommand = new SqlCommand(insertQuery, connection);

                        
                        insertCommand.Parameters.AddWithValue("@Name", Name);
                        insertCommand.Parameters.AddWithValue("@Description", Description);
                        insertCommand.Parameters.AddWithValue("@NumberOfSeats", NumberOfSeats);
                        insertCommand.Parameters.AddWithValue("@Id", newId);
                        // Выполнение запроса
                        insertCommand.ExecuteNonQuery();
                    }
                }
                public static void UpdateData(string Name, string Description, string NumberOfSeats)
                {
                    using (SqlConnection connection = new SqlConnection(Settings.SQLConnected.GetSQLConnect()))
                    {
                        connection.Open();

                        // SQL-запрос на обновление данных в таблице Events
                        string updateQuery = "UPDATE [dbo].[PlaceType] SET Name = @Name, Description = @Description, NumberOfSeats = @NumberOfSeats WHERE Id = @Id";
                        SqlCommand updateCommand = new SqlCommand(updateQuery, connection);

                        // Параметры для предотвращения SQL-инъекций
                        updateCommand.Parameters.AddWithValue("@Name", Name);
                        updateCommand.Parameters.AddWithValue("@Description", Description);
                        updateCommand.Parameters.AddWithValue("@NumberOfSeats", NumberOfSeats);
                        updateCommand.Parameters.AddWithValue("@Id", idFromAdminPlaceTypeDataGrid);

                        // Выполнение запроса
                        updateCommand.ExecuteNonQuery();
                    }
                }
                public static void DeleteFromId()
                {
                    using (SqlConnection connection = new SqlConnection(Settings.SQLConnected.GetSQLConnect()))
                    {
                        connection.Open();

                        // Запрос на удаление записи по Id
                        string deleteQuery = "DELETE FROM [dbo].[PlaceType] WHERE Id = @Id";
                        SqlCommand deleteCommand = new SqlCommand(deleteQuery, connection);
                        deleteCommand.Parameters.AddWithValue("@Id", idFromAdminPlaceTypeDataGrid);

                        // Выполнение запроса
                        deleteCommand.ExecuteNonQuery();
                    }
                }
            }

            public static class Hall
            {
                public static void CreateNew(string Name, string Description)
                {
                    using (SqlConnection connection = new SqlConnection(Settings.SQLConnected.GetSQLConnect()))
                    {
                        connection.Open();
                        // Определение нового ID
                        string getIdQuery = "SELECT ISNULL(MAX(Id), 0) + 1 FROM [dbo].[Hall]";
                        SqlCommand getIdCommand = new SqlCommand(getIdQuery, connection);
                        int newId = Convert.ToInt32(getIdCommand.ExecuteScalar());

                        string insertQuery = "INSERT INTO [dbo].[Hall] (Id, Name, Description) VALUES (@Id, @Name, @Description)";
                        SqlCommand insertCommand = new SqlCommand(insertQuery, connection);


                        insertCommand.Parameters.AddWithValue("@Name", Name);
                        insertCommand.Parameters.AddWithValue("@Description", Description);
                        insertCommand.Parameters.AddWithValue("@Id", newId);
                        // Выполнение запроса
                        insertCommand.ExecuteNonQuery();
                    }
                }
                public static void UpdateData(string Name, string Description)
                {
                    using (SqlConnection connection = new SqlConnection(Settings.SQLConnected.GetSQLConnect()))
                    {
                        connection.Open();

                        // SQL-запрос на обновление данных в таблице Events
                        string updateQuery = "UPDATE [dbo].[Hall] SET Name = @Name, Description = @Description WHERE Id = @Id";
                        SqlCommand updateCommand = new SqlCommand(updateQuery, connection);

                        // Параметры для предотвращения SQL-инъекций
                        updateCommand.Parameters.AddWithValue("@Name", Name);
                        updateCommand.Parameters.AddWithValue("@Description", Description);
                        updateCommand.Parameters.AddWithValue("@Id", idFromAdminHallDataGrid);

                        // Выполнение запроса
                        updateCommand.ExecuteNonQuery();
                    }
                }
                public static void DeleteFromId()
                {
                    using (SqlConnection connection = new SqlConnection(Settings.SQLConnected.GetSQLConnect()))
                    {
                        connection.Open();

                        // Запрос на удаление записи по Id
                        string deleteQuery = "DELETE FROM [dbo].[Hall] WHERE Id = @Id";
                        SqlCommand deleteCommand = new SqlCommand(deleteQuery, connection);
                        deleteCommand.Parameters.AddWithValue("@Id", idFromAdminHallDataGrid);

                        // Выполнение запроса
                        deleteCommand.ExecuteNonQuery();
                    }
                }
            }

            public static void AddNewidFromAdminHallDataGrid(string id)
            {
                try
                {
                    idFromAdminHallDataGrid = int.Parse(id);
                }
                catch
                {
                    MessageBox.Show("Ошибка преобразования в int", "КРИТИЧЕСКАЯ ОШИБКА", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            public static void AddNewidFromAdminPlaceTypeDataGrid(string id)
            {
                try
                {
                    idFromAdminPlaceTypeDataGrid = int.Parse(id);
                }
                catch
                {
                    MessageBox.Show("Ошибка преобразования в int", "КРИТИЧЕСКАЯ ОШИБКА", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            public static void AddNewidFromAdminEventsDataGrid(string id)
            {
                try
                {
                    idFromAdminEventsDataGrid = int.Parse(id);
                }
                catch
                {
                    MessageBox.Show("Ошибка преобразования в int", "КРИТИЧЕСКАЯ ОШИБКА", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            public static void AddNewidFromAdminTicketDataGrid(string id)
            {
                try
                {
                    idFromAdminTicketDataGrid = int.Parse(id);
                }
                catch
                {
                    MessageBox.Show("Ошибка преобразования в int", "КРИТИЧЕСКАЯ ОШИБКА", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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
