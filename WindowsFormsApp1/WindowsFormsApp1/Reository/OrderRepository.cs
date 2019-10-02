using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using WindowsFormsApp1.Model;

namespace WindowsFormsApp1.Reository
{

    public class OrderRepository
    {

        public bool AddOrder(Order order)
        {
            bool isAdded = false;
            try
            {
                string connectionString = @"Server=FATEMA-PC\SQLEXPRESS; Database=CoffeeShop; Integrated Security=True";
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                string commandString = @"INSERT INTO Orders (CustomerId,ItemId, Quantity,TotalPrice) Values(" + order.CustomerId + "," + order.ItemId + ", " + order.Quantity + ", " + order.TotalPrice + ")";
                SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);
                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
                int isExecuted = sqlCommand.ExecuteNonQuery();
                if (isExecuted > 0)
                { 
                   isAdded = true;
                  
                  }
                
                sqlConnection.Close();

            }
            catch (Exception)
            {

            }

            return isAdded;

        }
        

        
       
        public DataTable Display()
        {

            string connectionString = @"Server=FATEMA-PC\SQLEXPRESS; Database=CoffeeShop; Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            string commandString = @"SELECT o.Id, c.CustomerName,i.ItemName,Quantity,i.Price,TotalPrice FROM Orders As o
            LEFT JOIN Customers As c ON c.Id = o.CustomerId 
            LEFT JOIN Items As i ON i.Id = o.ItemId ";
            SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);
            sqlConnection.Open();

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            sqlConnection.Close();
            return dataTable;

        }
        public DataTable ItemCombo()
        {
            string connectionString = @"Server=FATEMA-PC\SQLEXPRESS; Database=CoffeeShop; Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            string commandString = @"SELECT Id,ItemName FROM Items";
            SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);
            sqlConnection.Open();

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            sqlConnection.Close();
            return dataTable;
        }

        public DataTable CustomerCombo()
        {
            string connectionString = @"Server=FATEMA-PC\SQLEXPRESS; Database=CoffeeShop; Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            string commandString = @"SELECT Id,CustomerName FROM Customers";
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
