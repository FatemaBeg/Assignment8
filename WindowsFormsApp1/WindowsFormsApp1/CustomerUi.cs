using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.BLL;
using WindowsFormsApp1.Model;

namespace WindowsFormsApp1
{
    public partial class CustomerUi : Form
       
    {
        CustomerManager _customerRepository = new CustomerManager();
        Customer _customer = new Customer();
        public CustomerUi()
        {
            InitializeComponent();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            if (_customerRepository.CustomerIsNameExists(customerNameTextBox.Text))
            {
                MessageBox.Show(customerNameTextBox.Text + "Already Exists!");
                return;
            }

            if (String.IsNullOrEmpty(customerAddressTextBox.Text))
            {
                MessageBox.Show("Address Can not be Empty!!!");
                return;
            }
           
            if (String.IsNullOrEmpty(customerContactTextBox.Text))
            {
                MessageBox.Show("Contact Can not be Empty!!!");
                return;
            }
            _customer.CustomerName=customerNameTextBox.Text;
            _customer.Address = customerAddressTextBox.Text;
            _customer.Contact = customerContactTextBox.Text;

            //bool customerisAdded = _customerRepository.AddCustomer(_customer.Name, _customer.Address, _customer.Contact);
            bool customerisAdded = _customerRepository.AddCustomer(_customer);
            if (customerisAdded)
            {
                MessageBox.Show("Saved");
            }
            else
            {
                MessageBox.Show("Not Saved");
            }

            showDataGridView.DataSource = _customerRepository.Display();

        }

        private void showBhutton_Click(object sender, EventArgs e)
        {
            showDataGridView.DataSource = _customerRepository.Display();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(customerIdTextBox.Text))
            {
                MessageBox.Show("Id Can not be Empty!!!");
                return;
            }

            if (_customerRepository.DeleteCustomer(Convert.ToInt32(customerIdTextBox.Text)))
            {
                MessageBox.Show("Deleted");
            }
            else
            {
                MessageBox.Show("Not Deleted");
            }

            showDataGridView.DataSource = _customerRepository.Display();
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(customerIdTextBox.Text))
            {
                MessageBox.Show("Id Can not be Empty!!!");
                return;
            }

            if (String.IsNullOrEmpty(customerNameTextBox.Text))
            {
                MessageBox.Show("Name Can not be Empty!!!");
                return;
            }
            if (String.IsNullOrEmpty(customerAddressTextBox.Text))
            {
                MessageBox.Show("Address Can not be Empty!!!");
                return;
            }
            if (String.IsNullOrEmpty(customerContactTextBox.Text))
            {
                MessageBox.Show("Contact Can not be Empty!!!");
                return;
            }

            if (_customerRepository.UpdateCustomer(customerNameTextBox.Text, customerAddressTextBox.Text,customerContactTextBox.Text,Convert.ToInt32(customerIdTextBox.Text)))
            {
                MessageBox.Show("Updated");

                showDataGridView.DataSource = _customerRepository.Display();
            }
            else
            {
                MessageBox.Show("Not Updated");
            }

        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(customerNameTextBox.Text))
            {
                MessageBox.Show("Name Can not be Empty!!!");
                return;
            }
            DataTable dataTable = new DataTable();
            dataTable = _customerRepository.SearchCustomer(customerNameTextBox.Text);
            if (dataTable.Rows.Count > 0)
            {
                showDataGridView.DataSource = dataTable;
                MessageBox.Show(customerNameTextBox.Text + " Customer  found");
                return;
            }
            else
            {
                MessageBox.Show("Customer not found");
            }
        }
    }
}
