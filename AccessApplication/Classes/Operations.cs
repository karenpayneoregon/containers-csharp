﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
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

        public static Color GetSingleColor()
        {

            using (var cn = new OleDbConnection { ConnectionString = ConnectionString })
            {
                using (var cmd = new OleDbCommand() { Connection = cn })
                {
                    cmd.CommandText = "SELECT T.AccentColor1 FROM Table1 AS T WHERE Id = ? ";
                    cmd.Parameters.Add("@Id", OleDbType.Integer).Value = 1;

                    cn.Open();

                    var result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        return Color.FromName(result.ToString());
                    }
                    else
                    {
                        // decide on a default color here if failed to get color from database
                        return Color.Blue; 
                    }
                    
                }
            }
        }

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

        public static DataTable ProductsDataTable()
        {
            DataTable table = new();

            using var cn = new OleDbConnection { ConnectionString = ConnectionString };
            using var cmd = new OleDbCommand() { Connection = cn };

            cmd.CommandText =
                "SELECT P.ProductID, P.ProductName, P.CategoryID, C.CategoryName as Category, P.SupplierID, S.CompanyName " + 
                "FROM (Categories AS C INNER JOIN Products AS P ON C.CategoryID = P.CategoryID) " + 
                "INNER JOIN Suppliers AS S ON P.SupplierID = S.SupplierID;";

            cn.Open();

            table.Load(cmd.ExecuteReader());

            table.Columns["ProductID"].ColumnMapping = MappingType.Hidden;
            table.Columns["CategoryID"].ColumnMapping = MappingType.Hidden;
            table.Columns["SupplierID"].ColumnMapping = MappingType.Hidden;

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

        public static (int identifier, Exception exception) SampleInsert(string companyName, string contactName)
        {

            using var cn = new OleDbConnection { ConnectionString = ConnectionString };
            using var cmd = new OleDbCommand() { Connection = cn };

            cmd.CommandText =
                "INSERT INTO Customers (CompanyName,ContactName) " + 
                "Values (@CompanyName,@ContactName)";

            cmd.Parameters.Add("@CompanyName", 
                OleDbType.LongVarChar).Value = companyName;

            cmd.Parameters.Add("@ContactName", 
                OleDbType.LongVarChar).Value = contactName;

            try
            {
                cn.Open();

                cmd.ExecuteNonQuery();
                return ((int)cmd.ExecuteScalar(), null);
            }
            catch (Exception ex)
            {
                return (-1, ex);
            }

        }

        public static async Task<(bool success, Exception exception)> Insert(string entry, DateTime dateTime)
        {
            using (var cn = new OleDbConnection { ConnectionString = "Your connection string" })
            {
                using (var cmd = new OleDbCommand() { Connection = cn })
                {
                    cmd.CommandText = "INSERT INTO ProgressReports(Report,DateTime) VALUES(?,?)";
                    cmd.Parameters.Add("?", OleDbType.LongVarChar).Value = entry;
                    cmd.Parameters.Add("?", OleDbType.Date).Value = dateTime;

                    try
                    {
                        await cn.OpenAsync();
                        return (await cmd.ExecuteNonQueryAsync() == 1, null);
                    }
                    catch (Exception localException)
                    {
                        return (false, localException);
                    }
                }
            }
        }
    }
}
