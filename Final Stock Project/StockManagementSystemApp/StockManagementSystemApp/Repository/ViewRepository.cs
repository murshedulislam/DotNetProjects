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
    class ViewRepository
    {
        //string connectionString = @"Server=MURSHEDULISLAM; Database=FirstDB; Integrated Security=True";
        DBconnection newConnection = new DBconnection();
        string connectionString => newConnection.connectionStr();
        SqlConnection sqlConnection;

        private string commandString;
        private SqlCommand sqlCommand;

        public DataTable ShowItems(string fromDate, string toDate, StockOUT stockOUT)
        {
            sqlConnection = new SqlConnection(connectionString);
            commandString = @"SELECT * FROM StockOutView WHERE Date BETWEEN '"+fromDate+"' AND '"+toDate+"' AND StockCondition = '"+stockOUT.StockCondition+"'";
            sqlCommand = new SqlCommand(commandString, sqlConnection);

            sqlConnection.Open();

            SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            //CreateSerialColumn();


            dataAdapter.Fill(dataTable);
            sqlConnection.Close();

            return dataTable;

        }

        public int DateDifference(string fromDate, string toDate)
        {
            sqlConnection = new SqlConnection(connectionString);
            commandString = @"SELECT DATEDIFF(day, '"+fromDate+"','"+toDate+"') AS DateDiff";
            sqlCommand = new SqlCommand(commandString, sqlConnection);

            sqlConnection.Open();
            int diff =Convert.ToInt32(sqlCommand.ExecuteScalar());
            sqlConnection.Close();

            return diff;

        }
    }
}
