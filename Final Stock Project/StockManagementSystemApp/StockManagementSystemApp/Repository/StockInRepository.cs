using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using StockManagementSystemApp.Models;

namespace StockManagementSystemApp.Repository
{
    class StockInRepository
    {
        DBconnection newConnection = new DBconnection();
        string connectionString => newConnection.connectionStr();
        
        SqlConnection sqlConnection;
        
        private string commandString;
        private SqlCommand sqlCommand;

        List<string> categories = new List<string>();
        List<string> companies = new List<string>();
        List<string> items = new List<string>();

        public List<string> LoadCompany()
        {


            sqlConnection = new SqlConnection(connectionString);
            commandString = @"SELECT * FROM Company";
            sqlCommand = new SqlCommand(commandString, sqlConnection);
            SqlDataReader sqlDataReader;
            sqlConnection.Open();

            sqlDataReader = sqlCommand.ExecuteReader();
            while (sqlDataReader.Read())
            {
                string sName = sqlDataReader.GetString(1);
                companies.Add(sName);

            }
            sqlConnection.Close();

            return companies;
        }

        public List<string> LoadCategory(Company company)
        {

            categories.Clear();
            categories.TrimExcess();
            sqlConnection = new SqlConnection(connectionString);
            commandString = @"SELECT * FROM Category WHERE SL IN(SELECT DISTINCT CategorySL FROM Item WHERE CompanySL = " + company.SL + ")";

            sqlCommand = new SqlCommand(commandString, sqlConnection);
            SqlDataReader sqlDataReader;
            sqlConnection.Open();

            sqlDataReader = sqlCommand.ExecuteReader();
            while (sqlDataReader.Read())
            {
                string sName = sqlDataReader.GetString(1);
                categories.Add(sName);

            }

            sqlConnection.Close();

            return categories;
        }

        public int ReturnCategoryId(Category category)
        {
            sqlConnection = new SqlConnection(connectionString);
            commandString = @"SELECT SL FROM Category WHERE Name = '" + category.Name + "'";
            sqlCommand = new SqlCommand(commandString, sqlConnection);
            int id;
            sqlConnection.Open();

            id = Convert.ToInt32(sqlCommand.ExecuteScalar());



            sqlConnection.Close();
            return id;
        }

        public int ReturnCompanyId(Company company)
        {
            sqlConnection = new SqlConnection(connectionString);
            commandString = @"SELECT SL FROM Company WHERE Name = '" + company.Name + "'";
            sqlCommand = new SqlCommand(commandString, sqlConnection);
            int id;
            sqlConnection.Open();

            id = Convert.ToInt32(sqlCommand.ExecuteScalar());



            sqlConnection.Close();
            return id;
        }

        public List<string> LoadItem(Company company, Category category)
        {

            items.Clear();
            items.TrimExcess();
            sqlConnection = new SqlConnection(connectionString);
            commandString = @"SELECT * FROM Item WHERE CategorySL=" + category.SL + " AND CompanySL=" + company.SL + "";
            sqlCommand = new SqlCommand(commandString, sqlConnection);
            SqlDataReader sqlDataReader;
            sqlConnection.Open();

            sqlDataReader = sqlCommand.ExecuteReader();
            while (sqlDataReader.Read())
            {
                string sName = sqlDataReader.GetString(1);
                items.Add(sName);

            }

            sqlConnection.Close();

            return items;

        }

        public int GetItemId(Item item)
        {
            sqlConnection = new SqlConnection(connectionString);
            commandString = @"SELECT ID FROM Item WHERE Name = '" + item.Name + "'";
            sqlCommand = new SqlCommand(commandString, sqlConnection);

            sqlConnection.Open();

            int itemID = Convert.ToInt32(sqlCommand.ExecuteScalar());



            sqlConnection.Close();
            return itemID;
        }

        public int ReorderLevel(Item item)
        {
            sqlConnection = new SqlConnection(connectionString);
            commandString = @"SELECT ReorderLevel FROM Item WHERE Name = '" + item.Name + "'";
            sqlCommand = new SqlCommand(commandString, sqlConnection);
            int reorder;
            sqlConnection.Open();

            reorder = Convert.ToInt32(sqlCommand.ExecuteScalar());



            sqlConnection.Close();

            return reorder;
        }

        public int availableQuantity(Item item)
        {
            sqlConnection = new SqlConnection(connectionString);
            commandString = @"SELECT AvailableQuantity FROM Item WHERE Name = '" + item.Name + "'";
            sqlCommand = new SqlCommand(commandString, sqlConnection);

            sqlConnection.Open();
            
            

           
           
               int available = Convert.ToInt32(sqlCommand.ExecuteScalar());
            


            sqlConnection.Close();

            return available;
        }

        public DataTable ShowItems(Item item)
        {
            sqlConnection = new SqlConnection(connectionString);
            commandString = @"SELECT * FROM StocksInView WHERE Item ='" + item.Name + "' ORDER BY Date DESC";
            sqlCommand = new SqlCommand(commandString, sqlConnection);

            sqlConnection.Open();

            SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            //CreateSerialColumn();


            dataAdapter.Fill(dataTable);





            sqlConnection.Close();

            return dataTable;
        }

        public int insertIntoStockIn(StockIN stockIN)
        {
            sqlConnection = new SqlConnection(connectionString);
            commandString = @"INSERT INTO StockIN(DT, ItemID, Amount) VALUES('" + DateTime.Now + "', '" + stockIN.ItemID + "'," + stockIN.Amount + ")";
            sqlCommand = new SqlCommand(commandString, sqlConnection);
            sqlConnection.Open();
            int isExecuted = sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
            return isExecuted;
        }

        public string findQuantity(StockIN stockIN)
        {
            commandString = @"SELECT Amount FROM StocksInView WHERE ID =" + stockIN.ID + "";
            sqlCommand = new SqlCommand(commandString, sqlConnection);

            sqlConnection.Open();

            string quantity = sqlCommand.ExecuteScalar().ToString();

            sqlConnection.Close();

            return quantity;
        }

        public int updateStockInAmount(StockIN stockIN)
        {
            commandString = @"UPDATE StockIN SET Amount = " + stockIN.Amount + " WHERE ID=" + stockIN.ID + "";
            sqlCommand = new SqlCommand(commandString, sqlConnection);

            sqlConnection.Open();

            int isExecuted = sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
            return isExecuted;
        }

        public int updateItemAvailableQuantity(Item item)
        {
            
            commandString = @"UPDATE Item SET AvailableQuantity =" + item.AvailableQuantity + " WHERE Name = '" + item.Name + "'";
            sqlCommand = new SqlCommand(commandString, sqlConnection);

            sqlConnection.Open();
            int isExecuted = sqlCommand.ExecuteNonQuery();

            sqlConnection.Close();

            return isExecuted;

        }
    }
}
