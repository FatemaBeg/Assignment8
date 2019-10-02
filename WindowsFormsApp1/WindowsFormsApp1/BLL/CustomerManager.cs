using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using WindowsFormsApp1.Reository;
using WindowsFormsApp1.Model;

namespace WindowsFormsApp1.BLL
{
    public class CustomerManager
    {
        CustomerRepository _customerRepository = new CustomerRepository();
        public bool AddCustomer(Customer customer)
        {
            return _customerRepository.AddCustomer(customer);
        }
        public bool CustomerIsNameExists(string name)
        {
            return _customerRepository.CustomerIsNameExists(name);
        }
        public bool UpdateCustomer(string name, string address, string contact, int id)
        {
            return _customerRepository.UpdateCustomer(name, address, contact, id);
        }
        public bool DeleteCustomer(int id)
        {
            return _customerRepository.DeleteCustomer(id);
        }
        public DataTable SearchCustomer(string name)
        {
            return _customerRepository.SearchCustomer(name);
        }
        public DataTable Display()
        {
            return _customerRepository.Display();
        }
    }
}
