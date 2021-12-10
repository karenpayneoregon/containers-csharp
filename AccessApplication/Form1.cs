using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AccessApplication.Classes;

namespace AccessApplication
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void ConnectButton_Click(object sender, EventArgs e)
        {
            var (succcess, exception) = Operations.TestConnection();
            if (succcess)
            {
                MessageBox.Show("Good to go");
            }
            else
            {
                MessageBox.Show($"{exception.Message}");
            }
        }

        private void TableButton_Click(object sender, EventArgs e)
        {
            CategoriesComboBox.DataSource = null;
            var table = Operations.CategoriesDataTable();
            CategoriesComboBox.DataSource = table;
            CategoriesComboBox.DisplayMember = "CategoryName";
        }

        private void ListButton_Click(object sender, EventArgs e)
        {
            CategoriesComboBox.DataSource = null;
            CategoriesComboBox.DataSource = Operations.CategoriesList();
        }
    }
}
