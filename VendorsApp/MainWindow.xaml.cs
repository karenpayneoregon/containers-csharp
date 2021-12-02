using System.Windows;
using ThirdPartyLibrary.Models;
using VendorsApp.Models;

namespace VendorsApp
{

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            VendorModel vm = new VendorModel();
            DataContext = vm;
        }

        private void SelectedVendorButton_Click(object sender, RoutedEventArgs e)
        {
            Vendor current = (Vendor)VendorsCombobox.SelectedItem;
            MessageBox.Show(current.Id == 0 ? 
                "Please make a selection" : 
                $"Current identifier {current.Id}\n{current.DisplayName}\n{current.AccountNumber}\n{current.CreditRating}");
        }
    }
}
