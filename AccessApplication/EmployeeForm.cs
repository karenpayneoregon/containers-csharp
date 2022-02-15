using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using AccessApplication.Classes;

namespace AccessApplication
{
    public partial class EmployeeForm : Form
    {
        private readonly BindingSource _employeesBindingSource = 
            new BindingSource();

        public EmployeeForm()
        {
            InitializeComponent();

            _employeesBindingSource.DataSource = EmployeesOperations.EmployeesList();
            EmployeesComboBox.DataSource = _employeesBindingSource;

            dataGridView1.DataSource = EmployeesOperations.EmptyDataTable();
        }

        private void GetSingleEmployeeButton_Click(object sender, EventArgs e)
        {
            int id = ((Employee)EmployeesComboBox.SelectedItem).Id;
            DataTable table = ((DataTable)dataGridView1.DataSource);
            
            DataRow result = table.AsEnumerable()
                .FirstOrDefault(row => row.Field<int>("EmployeeID") == id);

            // only add if not already in the data grid view
            if (result == null)
            {
                table.ImportRow(EmployeesOperations.SingleRow(id).Rows[0]);
            }
        }

        private async void ReadDatSetButton_Click(object sender, EventArgs e)
        {
            
            await Task.Run(async () =>
            {
                DataSet dataSet = await EmployeesOperations.GetDataSet();

                DataTable employeeTable = dataSet.Tables["EmployeeTable"];

                foreach (DataRow row in employeeTable.Rows)
                {
                    Debug.WriteLine($"{string.Join(",", row.ItemArray)}");
                }

            });
        }
    }
}
