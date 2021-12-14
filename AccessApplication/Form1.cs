using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AccessApplication.Classes;
using AccessApplication.Models;

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
            var (success, exception) = Operations.TestConnection();
            if (success)
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

        private void GetCurrentButton_Click(object sender, EventArgs e)
        {
            if (CategoriesComboBox.DataSource is null) return;

            if (CategoriesComboBox.DataSource is List<Category> list)
            {
                var current = (Category)CategoriesComboBox.SelectedItem;
                MessageBox.Show(@$"{current.Id}");
            }
            else
            {
                var current = ((DataRowView)CategoriesComboBox.SelectedItem).Row;
                MessageBox.Show(@$"{current.Field<string>("CategoryName")}");
            }
        }
    }
}
