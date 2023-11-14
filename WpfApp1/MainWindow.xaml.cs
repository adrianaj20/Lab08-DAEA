using System.Collections.Generic;
using System.Windows;
using Business; 
using Entity;

namespace WpfApp1
{
    public partial class MainWindow : Window
    {
        private BCustomer bCustomer = new BCustomer();

        public MainWindow()
        {
            InitializeComponent();
            LoadCustomerList();
        }

        private void LoadCustomerList()
        {
            List<Customer> customers = bCustomer.GetAllCustomers(); 
            lvCustomers.ItemsSource = customers; 
        }

        private void FilterButton_Click(object sender, RoutedEventArgs e)
        {
            string filterName = txtFilter.Text.Trim();
            if (!string.IsNullOrEmpty(filterName))
            {
                List<Customer> filteredCustomers = bCustomer.SearchCustomersByName(filterName); 
                lvCustomers.ItemsSource = filteredCustomers; 
            }
            else
            {
                LoadCustomerList(); 
            }
        }
    }
}
