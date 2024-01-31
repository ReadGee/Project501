using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DvorecKulturi
{
    internal class MainMenuCommand
    {
        static int idFromUserEvent;
        public static class Get
        {
            public static class V_Events
            {
                public static int Newid()
                {
                     return idFromUserEvent;
                }
                public static bool CheckNewId()
                {
                    if(idFromUserEvent != null)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
        }
        public static class Set
        {
            public static class V_Events
            {
                public static void AddNewId(string id)
                {
                    try
                    {
                        idFromUserEvent = int.Parse(id);
                    }
                    catch
                    {
                        MessageBox.Show("Ошибка преобразования в int \nАдрес Menu.cs/Set/V_Tickets/V_Events \nidFromUserEvent = int.Parse(id);", "КРИТИЧЕСКАЯ ОШИБКА", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                public static void AddNewId(int id)
                {
                    try
                    {
                        idFromUserEvent = id;
                    }
                    catch
                    {
                        MessageBox.Show("Ошибка преобразования в int \nАдрес Menu.cs/Set/V_Tickets/V_Events \nidFromUserEvent = int.Parse(id);", "КРИТИЧЕСКАЯ ОШИБКА", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

        }
    }
}
