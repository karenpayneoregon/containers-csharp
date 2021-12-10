using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccessApplication.Models;

namespace AccessApplication.Classes
{
    public class Operations
    {
        public static string ConnectionString =>
            "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=NorthWind.accdb";

        public static (bool succcess, Exception exception) TestConnection()
        {
            using var cn = new OleDbConnection { ConnectionString = ConnectionString };
            try
            {
                cn.Open();
                return (true, null);
            }
            catch (Exception e)
            {
                return (false, e);
            }
        }

        public static DataTable CategoriesDataTable()
        {
            DataTable table = new ();

            using var cn = new OleDbConnection { ConnectionString = ConnectionString };
            using var cmd = new OleDbCommand() {Connection = cn};

            cmd.CommandText = "SELECT CategoryID, CategoryName FROM Categories;";

            cn.Open();

            table.Load(cmd.ExecuteReader());

            return table;
        }

        public static List<Category> CategoriesList()
        {
            List<Category> list = new() {new Category() {Id = -1, Name = "Select"}};
            
            using var cn = new OleDbConnection { ConnectionString = ConnectionString };
            using var cmd = new OleDbCommand() { Connection = cn };

            cmd.CommandText = "SELECT CategoryID, CategoryName FROM Categories;";

            cn.Open();

            var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                list.Add(new Category() {Id = reader.GetInt32(0), Name = reader.GetString(1)});
            }

            return list;
        }
    }
}
