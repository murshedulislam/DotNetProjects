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
    public class ProductRepository
    {
        SBMSDbContext db = new SBMSDbContext();

        public bool Add(Product product)
        {
            db.Products.Add(product);
            
            bool isSaved = db.SaveChanges() > 0;
            if (isSaved)
            {
                return true;
            }

            return false;
        }

        public bool Delete(Product product)
        {
            Product item = db.Products.FirstOrDefault(p => p.ID == product.ID);
            db.Products.Remove(item);
            bool isDelete = db.SaveChanges() > 0;
            if (isDelete)
            {
                return true;
            }

            return false;
        }

        public bool Update(Product product)
        {
            //Method 1
            //Product item = db.Products.FirstOrDefault(p => p.ID == product.ID);
            //if (item != null)
            //{
            //    item.Name = product.Name;
            //    item.Description = product.Description;
            //    bool isUpdated = db.SaveChanges() > 0;
            //    if (isUpdated)
            //    {
            //        return true;
            //    }
            //}

            //Method-2
            db.Entry(product).State = EntityState.Modified;
            bool isUpdated = db.SaveChanges() > 0;
            if (isUpdated)
            {
                return true;
            }

            return false;
        }

        public List<Product> GetAll()
        {
            return db.Products.Include(p=>p.Category).ToList();
        }

        public Product GetById(Product product)
        {
            Product item = db.Products.FirstOrDefault(p => p.ID == product.ID);
            return item;
        }
        public List<Product> GetProducts(Product product)
        {
            var products = db.Products.Include(c => c.Category).Where(c => c.Category.Name.ToLower().Contains(product.CategoryName.ToLower()) || c.Name.ToLower().Contains(product.Name.ToLower())).ToList();
            return products;
        }
    }
}
