using System;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EnumDescriptionExample.Classes;
using EnumDescriptionExample.Extensions;

namespace EnumDescriptionExample
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            Shown += OnShown;
        }

        private void OnShown(object sender, EventArgs e)
        {
            CategoriesComboBox.DisplayMember = "Description";
            CategoriesComboBox.ValueMember = "Value";
            CategoriesComboBox.DataSource = Operations.CategoryItems();
        }

        private void CurrentButton_Click(object sender, EventArgs e)
        {
            var (text, category) = CategoriesComboBox.CurrentCategory();
            MessageBox.Show($"{text}\n{category}");
        }
    }
}
