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
    class StockRepository
    {
        //string connectionString = @"Server=MURSHEDULISLAM; Database=FirstDB; Integrated Security=True";
        DBconnection newConnection = new DBconnection();
        string connectionString => newConnection.connectionStr();
        SqlConnection sqlConnection;

        private string commandString;
        private SqlCommand sqlCommand;
        


        public DataTable DisplayGrid()
        {
            sqlConnection = new SqlConnection(connectionString);
            commandString = @"SELECT * FROM Category";
            sqlCommand = new SqlCommand(commandString, sqlConnection);

            sqlConnection.Open();

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);


            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);

            sqlConnection.Close();

            return dataTable;



        }

        public int InsertCategory(Category category)
            
        {
            sqlConnection = new SqlConnection(connectionString);
            commandString = @"INSERT INTO Category(Name) VALUES('" + category.Name + "')";
            sqlCommand = new SqlCommand(commandString, sqlConnection);

            sqlConnection.Open();

            int isExecuted = 0;
            isExecuted = sqlCommand.ExecuteNonQuery();

            

            sqlConnection.Close();
            return isExecuted;

        }

        public int UpdateCategory(Category category, int rowIndex)
        {
            sqlConnection = new SqlConnection(connectionString);
            commandString = @"UPDATE Category SET Name='" + category.Name + "' WHERE SL=" + rowIndex + "";
            sqlCommand = new SqlCommand(commandString, sqlConnection);

            sqlConnection.Open();

            int isExecuted = 0;
            isExecuted = sqlCommand.ExecuteNonQuery();

           

            sqlConnection.Close();

            return isExecuted;
        }

        public int Duplicate(Category category)
        {
            sqlConnection = new SqlConnection(connectionString);
            commandString = @"SELECT * FROM Category WHERE Name = '" + category.Name + "'";
            sqlCommand = new SqlCommand(commandString, sqlConnection);

            sqlConnection.Open();

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);


            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);

            int data = dataTable.Rows.Count;



            sqlConnection.Close();

            return data;
        }
    }


}
