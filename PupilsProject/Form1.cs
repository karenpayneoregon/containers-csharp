using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PupilsProject
{
    public partial class Form1 : Form
    {
        private readonly BindingSource _bindingSource = new BindingSource();
        public Form1()
        {
            InitializeComponent();

            dgvPupil.AutoGenerateColumns = false;
            _bindingSource.DataSource = Mocked.Pupils();
            dgvPupil.DataSource = _bindingSource;

            foreach (DataGridViewColumn column in dgvPupil.Columns)
            {
                Console.WriteLine(
                    $"{column.Name}, {column.DataPropertyName}, {column.DefaultCellStyle.Format}");
            }
        }
    }

    class Pupil
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
    }

    class Mocked
    {
        public static List<Pupil> Pupils() =>
            new List<Pupil>
            {
                new Pupil()
                {
                    FirstName = "Jim", 
                    LastName = "Adams", 
                    BirthDate = new DateTime(1990, 1, 2)
                },
                new Pupil()
                {
                    FirstName = "Mary", 
                    LastName = "Jones", 
                    BirthDate = new DateTime(1980, 11, 4)
                },
                new Pupil()
                {
                    FirstName = "Mile", 
                    LastName = "White", 
                    BirthDate = new DateTime(1970,10,9)
                }
            };
    }

}
