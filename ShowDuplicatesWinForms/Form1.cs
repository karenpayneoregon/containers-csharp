using System;
using System.Linq;
using System.Windows.Forms;

namespace ShowDuplicatesWinForms
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
            var duplicates = MockedData()
                .Select((text, index) => new IndexItem { Index = index, Text = text })
                .GroupBy(g => g.Text)
                .Where(g => g.Count() > 1).ToList();

            foreach (var duplicate in duplicates)
            {
                foreach (var item in duplicate)
                {
                    listBox1.Items.Add(item);
                }
            }
        }

        private string[] MockedData()
        {
            string[] lines = {
                "This is a test",
                "This is a apple",
                "This is a orange",
                "This is a test",
                "This is a orange",
                "This is a test"
            };

            return lines;
        }
    }

    public class IndexItem
    {
        public int Index { get; set; }
        public string Text { get; set; }

        public override string ToString() => $"{Index,3:D2} {Text}";
    }

}
