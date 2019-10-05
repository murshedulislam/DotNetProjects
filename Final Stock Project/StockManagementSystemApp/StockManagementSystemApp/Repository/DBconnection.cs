using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagementSystemApp.Repository
{
    class DBconnection
    {
        public string ConnectionString { get; set; }

        public DBconnection()
        {
            ConnectionString = @"Server=MURSHEDULISLAM; Database=StockDB; Integrated Security=True";
        }

        public string connectionStr()
        {
            return ConnectionString;
        }
    }
}
