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
    class ItemRepository
    {
        //string connectionString = @"Server=MURSHEDULISLAM; Database=FirstDB; Integrated Security=True";
        DBconnection newConnection = new DBconnection();
        string connectionString => newConnection.connectionStr();
        SqlConnection sqlConnection;

        private string commandString;
        private SqlCommand sqlCommand;

        public DataTable LoadCategory()
        {
            sqlConnection = new SqlConnection(connectionString);
            commandString = @"SELECT * FROM Category";
            sqlCommand = new SqlCommand(commandString, sqlConnection);

            sqlConnection.Open();

            SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);

            //if (dataTable.Rows.Count > 0)
            //    districtComboBox.DataSource = dataTable;


            sqlConnection.Close();


            return dataTable;

        }

        public DataTable LoadCompany()
        {
            sqlConnection = new SqlConnection(connectionString);
            commandString = @"SELECT * FROM Company";
            sqlCommand = new SqlCommand(commandString, sqlConnection);

            sqlConnection.Open();

            SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);

            //if (dataTable.Rows.Count > 0)
            //    districtComboBox.DataSource = dataTable;


            sqlConnection.Close();


            return dataTable;

        }

        public int Duplicate(Item item)
        {
            sqlConnection = new SqlConnection(connectionString);
            commandString = @"SELECT * FROM Item WHERE Name = '" + item.Name + "'";
            sqlCommand = new SqlCommand(commandString, sqlConnection);

            sqlConnection.Open();

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);


            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);

            int data = dataTable.Rows.Count;



            sqlConnection.Close();

            return data;
        }

        public int InsertItem(Item item)
        {
            sqlConnection = new SqlConnection(connectionString);
            commandString = @"INSERT INTO Item(Name, ReorderLevel, AvailableQuantity, CategorySL, CompanySL) VALUES('" + item.Name + "'," + item.ReorderLevel + ",0," + item.CategorySL + "," + item.CompanySL + ")";
            sqlCommand = new SqlCommand(commandString, sqlConnection);

            sqlConnection.Open();

            int isExecuted;

            isExecuted = sqlCommand.ExecuteNonQuery();


            sqlConnection.Close();

            return isExecuted;

        }

    }
}
