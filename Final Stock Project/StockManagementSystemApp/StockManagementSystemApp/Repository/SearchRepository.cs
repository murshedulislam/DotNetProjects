using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Data;
using StockManagementSystemApp.Models;
using System.Text;
using System.Threading.Tasks;

namespace StockManagementSystemApp.Repository
{
    class SearchRepository
    {
        //string connectionString = @"Server=MURSHEDULISLAM; Database=FirstDB; Integrated Security=True";
        DBconnection newConnection = new DBconnection();
        string connectionString => newConnection.connectionStr();
        SqlConnection sqlConnection;

        private string commandString;
        private SqlCommand sqlCommand;

        List<string> categories = new List<string>();
        List<string> companies = new List<string>();

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

        public List<string> LoadCategory()
        {

            categories.Clear();
            categories.TrimExcess();
            sqlConnection = new SqlConnection(connectionString);
            commandString = @"SELECT * FROM Category";

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

        public DataTable DisplayGrid(Company company, Category category)
        {
            sqlConnection = new SqlConnection(connectionString);
            commandString = @"SELECT * FROM SearchView WHERE Company = '"+company.Name+"' AND Category = '"+category.Name+"'";
            sqlCommand = new SqlCommand(commandString, sqlConnection);

            sqlConnection.Open();

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);


            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);

            sqlConnection.Close();

            return dataTable;



        }

        public DataTable DisplayCompanyGrid(Company company)
        {
            sqlConnection = new SqlConnection(connectionString);
            commandString = @"SELECT * FROM SearchView WHERE Company = '" + company.Name + "'";
            sqlCommand = new SqlCommand(commandString, sqlConnection);

            sqlConnection.Open();

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);


            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);

            sqlConnection.Close();

            return dataTable;



        }

        public DataTable DisplayCategoryGrid(Category category)
        {
            sqlConnection = new SqlConnection(connectionString);
            commandString = @"SELECT * FROM SearchView WHERE Category = '" + category.Name + "'";
            sqlCommand = new SqlCommand(commandString, sqlConnection);

            sqlConnection.Open();

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);


            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);

            sqlConnection.Close();

            return dataTable;



        }
    }
}
