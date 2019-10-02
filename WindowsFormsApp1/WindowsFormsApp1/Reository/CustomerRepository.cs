using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using WindowsFormsApp1.Model;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Reository
{
    public class CustomerRepository
    {
        public bool AddCustomer(Customer customer)
        {
            bool customerIsAdded = false;
            try
            {               
                string connectionString = @"Server=FATEMA-PC\SQLEXPRESS; Database=CoffeeShop; Integrated Security=True";
                SqlConnection sqlConnection = new SqlConnection(connectionString);            
                string commandString = @"INSERT INTO Customers (CustomerName, Address,Contact) Values ('" + customer.CustomerName + "', '" + customer.Address + "', '" + customer.Contact + "')";
                SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);             
                sqlConnection.Open();
              
                int isExecuted = sqlCommand.ExecuteNonQuery();
                if (isExecuted > 0)
                {
                    customerIsAdded = true;
                }
                sqlConnection.Close();

            }
            catch (Exception)
            {
                
            }

            return customerIsAdded;

        }
        public bool CustomerIsNameExists(string name)
        {
            bool exists = false;
            try
            {              
                string connectionString = @"Server=FATEMA-PC\SQLEXPRESS; Database=CoffeeShop; Integrated Security=True";
                SqlConnection sqlConnection = new SqlConnection(connectionString);            
                string commandString = @"SELECT * FROM Customers WHERE CustomerName='" + name + "'";
                SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);                
                sqlConnection.Open();          
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                if (dataTable.Rows.Count > 0)
                {
                    exists = true;
                }
             
                sqlConnection.Close();

            }
            catch (Exception)
            {
              
            }

            return exists;
        }
        public bool UpdateCustomer(string name, string address, string contact,int id)
        {
            try
            {               
                string connectionString = @"Server=FATEMA-PC\SQLEXPRESS; Database=CoffeeShop; Integrated Security=True";
                SqlConnection sqlConnection = new SqlConnection(connectionString);

                
                string commandString = @"UPDATE Customers SET CustomerName =  '" + name + "' ,  Address =  '" + address + "' ,  Contact =  '" + contact + "' WHERE CustomerId = " + id + "";
                SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);              
                sqlConnection.Open();                
                int isExecuted = sqlCommand.ExecuteNonQuery();
                if (isExecuted > 0)
                {
                    return true;
                }
            
                sqlConnection.Close();
            }
            catch (Exception)
            {
               
            }

            return false;
        }

        public bool DeleteCustomer(int id)
        {
            try
            {
                
                string connectionString = @"Server=FATEMA-PC\SQLEXPRESS; Database=CoffeeShop; Integrated Security=True";
                SqlConnection sqlConnection = new SqlConnection(connectionString);                
                string commandString = @"DELETE FROM Customers WHERE CustomerId = " + id + "";
                SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);            
                sqlConnection.Open();
                int isExecuted = sqlCommand.ExecuteNonQuery();
                if (isExecuted > 0)
                {
                    return true;
                }
                sqlConnection.Close();
            }
            catch (Exception)
            {
                
            }
            return false;
        }
        public DataTable SearchCustomer(string name)
        {

            string connectionString = @"Server=FATEMA-PC\SQLEXPRESS; Database=CoffeeShop; Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            string commandString = @"SELECT * FROM Customers  WHERE CustomerName='" + name + "'";
            SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);
            sqlConnection.Open();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();

            sqlDataAdapter.Fill(dataTable);
            sqlConnection.Close();

            return dataTable;
        }
        public DataTable Display()
        {

            string connectionString = @"Server=FATEMA-PC\SQLEXPRESS; Database=CoffeeShop; Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            string commandString = @"SELECT * FROM Customers";
            SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);
            sqlConnection.Open();

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            sqlConnection.Close();
            return dataTable;

        }
    }
}
