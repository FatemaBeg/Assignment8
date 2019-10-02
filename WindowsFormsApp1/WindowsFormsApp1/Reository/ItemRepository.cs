using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using WindowsFormsApp1.Model;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Repository
{
    public class ItemRepository
    {
        public bool Add(Item item)
        {
            bool isAdded = false;
            try
            {
                string connectionString = @"Server=FATEMA-PC\SQLEXPRESS; Database=CoffeeShop; Integrated Security=True";
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                string commandString = @"INSERT INTO Items (ItemName , Price) Values ('" + item.ItemName + "', " + item.Price + " )";
                SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);
                sqlConnection.Open();

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
        public bool ItemIsNameExists(string name)
        {
            bool exists = false;
            try
            {
                string connectionString = @"Server=FATEMA-PC\SQLEXPRESS; Database=CoffeeShop; Integrated Security=True";
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                string commandString = @"SELECT * FROM Items WHERE ItemName='" + name + "'";
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
        public bool UpdateItem(string name,  double price, int id)
        {

            try
            {
                string connectionString = @"Server=FATEMA-PC\SQLEXPRESS; Database=CoffeeShop; Integrated Security=True";
                SqlConnection sqlConnection = new SqlConnection(connectionString);

                sqlConnection.Open();
                string commandString = @"UPDATE Items SET ItemName =  '" + name + "' ,  Price =  " + price + " WHERE Id = " + id + "";
                SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);
                //
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

        public bool DeleteItem(int id)
        {
            try
            {

                string connectionString = @"Server=FATEMA-PC\SQLEXPRESS; Database=CoffeeShop; Integrated Security=True";
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                string commandString = @"DELETE FROM Items WHERE Id = " + id + "";
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
        public DataTable SearchItem(string name)
        {

            string connectionString = @"Server=FATEMA-PC\SQLEXPRESS; Database=CoffeeShop; Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            string commandString = @"SELECT * FROM Items  WHERE ItemName='" + name + "'";
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

            string commandString = @"SELECT * FROM Items";
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
