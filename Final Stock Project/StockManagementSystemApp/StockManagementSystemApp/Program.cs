using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StockManagementSystemApp
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new CategorySetup());
            //Application.Run(new CompanySetup());
            // Application.Run(new ItemSetup());
            //Application.Run(new StockOut());
            //Application.Run(new SearchSummary());
            //Application.Run(new SearchView());
            //Application.Run(new StockIn());
            Application.Run(new Home());
        }
    }
}
