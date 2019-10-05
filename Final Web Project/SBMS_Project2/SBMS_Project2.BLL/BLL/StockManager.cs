using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SBMS_Project2.Models.Models;
using SBMS_Project2.Repository.Repository;

namespace SBMS_Project2.BLL.BLL
{
    public class StockManager
    {
        StockRepository _stockRepository = new StockRepository();

        public List<Product> GetAll()
        {
            return _stockRepository.GetAll();
        }

        

        
    }
}
