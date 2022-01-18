using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;

namespace AccessApplication.Classes
{
    public class EmployeesOperations
    {
        public static string ConnectionString =>
            "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=NorthWind.accdb";

        public static List<Employee> EmployeesList()
        {
            List<Employee> list = new List<Employee>();
            using var cn = new OleDbConnection { ConnectionString = ConnectionString };
            using var cmd = new OleDbCommand() { Connection = cn };

            cmd.CommandText = "SELECT EmployeeID, FirstName, LastName  FROM Employees";

            cn.Open();
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                list.Add(new Employee()
                {
                    Id = reader.GetInt32(0), 
                    FirstName = reader.GetString(1), 
                    LastName = reader.GetString(2)
                });
            }

            return list;
        }

        public static DataTable EmptyDataTable()
        {
            using var cn = new OleDbConnection { ConnectionString = ConnectionString };
            using var cmd = new OleDbCommand() { Connection = cn };

            cmd.CommandText = 
                "SELECT TOP 1 EmployeeID, FirstName, LastName FROM Employees";

            cn.Open();

            DataTable table = new DataTable();
            table.Load(cmd.ExecuteReader());
            table.Rows.Clear();

            return table;
        }
        public static DataTable SingleRow(int identifier)
        {
            using var cn = new OleDbConnection { ConnectionString = ConnectionString };
            using var cmd = new OleDbCommand() { Connection = cn };

            cmd.CommandText = 
                "SELECT TOP 1 EmployeeID, FirstName, LastName " +
                "FROM Employees WHERE EmployeeID = @Id";

            cmd.Parameters.Add("@Id", OleDbType.Integer).Value = identifier;
            cn.Open();

            DataTable table = new DataTable();
            table.Load(cmd.ExecuteReader());

            return table;
        }
    }

    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public override string ToString() => $"{FirstName} {LastName}";
    }
}
