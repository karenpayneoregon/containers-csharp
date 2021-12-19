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
        private readonly BindingSource _productsBindingSource = new BindingSource();
        public Form1()
        {
            InitializeComponent();

            Shown += OnShown;
        }

        private void OnShown(object? sender, EventArgs e)
        {
            _productsBindingSource.DataSource = Operations.ProductsDataTable();
            ProductsDataGridView.DataSource = _productsBindingSource;
            foreach (DataGridViewColumn column in ProductsDataGridView.Columns)
            {
                column.HeaderText = column.HeaderText.SplitCamelCase();
            }

            ProductsDataGridView.ExpandColumns();
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

        private void CurrentProductButton_Click(object sender, EventArgs e)
        {
            if (_productsBindingSource.Current is not null)
            {
                var row = ((DataRowView)_productsBindingSource.Current).Row;
                MessageBox.Show($@"Current product identifier {row.Field<int>("ProductID")}");
            }
            else
            {
                MessageBox.Show(@"No current row");
            }

        }

    }
}
