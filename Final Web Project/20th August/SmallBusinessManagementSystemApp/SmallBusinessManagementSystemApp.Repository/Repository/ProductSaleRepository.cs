using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using SmallBusinessManagementSystemApp.Models.Models;
using SmallBusinessManagementSystemApp.DatabaseContext.DatabaseContext;

namespace SmallBusinessManagementSystemApp.Repository.Repository
{
    public class ProductSaleRepository
    {
        StockDbContext db = new StockDbContext();

        public bool AddProductSale(ProductSale productSale)
        {
            int isExecuted = 0;
            db.ProductSales.Add(productSale);
            isExecuted = db.SaveChanges();
            if (isExecuted > 0)
            {
                return true;
            }

            return false;
        }

        public bool AddProductSale(List<ProductSale> productSales)
        {
            int isExecuted = 0;
            db.ProductSales.AddRange(productSales);
            isExecuted = db.SaveChanges();
            if (isExecuted > 0)
            {
                return true;
            }

            return false;
        }

        public bool DeleteProductSale(ProductSale productSale)
        {
            int isExecuted = 0;

            ProductSale aProductSale = db.ProductSales.FirstOrDefault(c => c.ID == productSale.ID);
            db.ProductSales.Remove(aProductSale);
            isExecuted = db.SaveChanges();
            if (isExecuted > 0)
            {
                return true;
            }
            return false;

        }

        public bool UpdateProductSale(ProductSale productSale)
        {
            int isExecuted = 0;

            //ProductSale aProductSale = db.ProductSales.FirstOrDefault(c => c.Code == productSale.Code);
            //if (aProductSale != null)
            //{
            //    aProductSale.Name = productSale.Name;

            //}

            db.Entry(productSale).State = EntityState.Modified;
            isExecuted = db.SaveChanges();


            if (isExecuted > 0)
            {
                return true;
            }
            return false;
        }

        public ProductSale GetById(ProductSale productSale)
        {
            ProductSale aProductSale = db.ProductSales.FirstOrDefault(c => c.ID == productSale.ID);
            return aProductSale;

        }

        public ProductSale GetByProductId(int id)
        {
            ProductSale aProductSale = db.ProductSales.FirstOrDefault(c => c.ProductId == id);
            return aProductSale;

        }
        public List<ProductSale> GetByProductSaleId(int id)
        {
            List<ProductSale> aProductSale = db.ProductSales.Where(c => c.CustomerSaleId == id).ToList();

            return aProductSale;

        }

        public List<ProductSale> GetByProduct(int productId)
        {
            List<ProductSale> aProductSale = db.ProductSales.Where(c => c.ProductId == productId).ToList();

            return aProductSale;

        }

        public List<ProductSale> GetAll()
        {
            return db.ProductSales.ToList();
        }

    }
}
