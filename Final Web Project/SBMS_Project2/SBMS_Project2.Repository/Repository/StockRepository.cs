using SBMS_Project2.DatabaseContext.DatabaseContext;
using SBMS_Project2.Models.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBMS_Project2.Repository.Repository
{
    public class StockRepository
    {
        SBMSDbContext db = new SBMSDbContext();



        public List<Product> GetAll()
        {
            return db.Products.Include(p => p.Categories).ToList();
        }

        
        public Purchase PurchaseDetails(Product product)
        {
            var aProduct = db.Purchases.Include(c => c.Product).Where(c => c.Product.Name.ToLower() == product.ProductName.ToLower()).FirstOrDefault();
            return aProduct;
        }
        
    }
}
