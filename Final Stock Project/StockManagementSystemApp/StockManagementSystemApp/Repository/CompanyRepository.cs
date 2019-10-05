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
    class CompanyRepository
    {
        // string connectionString = @"Server=MURSHEDULISLAM; Database=FirstDB; Integrated Security=True";
        DBconnection newConnection = new DBconnection();
        string connectionString => newConnection.connectionStr();
        SqlConnection sqlConnection;

        private string commandString;
        private SqlCommand sqlCommand;

        public DataTable DisplayGrid()
        {
            sqlConnection = new SqlConnection(connectionString);
            commandString = @"SELECT * FROM Company";
            sqlCommand = new SqlCommand(commandString, sqlConnection);

            sqlConnection.Open();

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);


            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);

            sqlConnection.Close();

            return dataTable;



        }

        public int InsertCompany(Company company)

        {
            sqlConnection = new SqlConnection(connectionString);
            commandString = @"INSERT INTO Company(Name) VALUES('" + company.Name + "')";
            sqlCommand = new SqlCommand(commandString, sqlConnection);

            sqlConnection.Open();

            int isExecuted = 0;
            isExecuted = sqlCommand.ExecuteNonQuery();



            sqlConnection.Close();
            return isExecuted;

        }

        public int UpdateCompany(Company company, int rowIndex)
        {
            sqlConnection = new SqlConnection(connectionString);
            commandString = @"UPDATE Company SET Name='" + company.Name + "' WHERE SL=" + rowIndex + "";
            sqlCommand = new SqlCommand(commandString, sqlConnection);

            sqlConnection.Open();

            int isExecuted = 0;
            isExecuted = sqlCommand.ExecuteNonQuery();



            sqlConnection.Close();

            return isExecuted;
        }

        public int Duplicate(Company company)
        {
            sqlConnection = new SqlConnection(connectionString);
            commandString = @"SELECT * FROM Company WHERE Name = '" + company.Name + "'";
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
