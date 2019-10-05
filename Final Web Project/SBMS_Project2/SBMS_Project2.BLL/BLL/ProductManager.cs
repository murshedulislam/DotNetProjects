using SBMS_Project2.Models.Models;
using SBMS_Project2.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBMS_Project2.BLL.BLL
{
    public class ProductManager
    {
        ProductRepository _productRepository = new ProductRepository();
        StockRepository _stockRepository = new StockRepository();

        public bool Add(Product product)
        {
            return _productRepository.Add(product);
        }

        public bool Delete(Product product)
        {
            return _productRepository.Delete(product);
        }

        public bool Update(Product product)
        {
            return _productRepository.Update(product);
        }

        public List<Product> GetAll()
        {
            return _productRepository.GetAll();
        }

        public Product GetById(Product product)
        {
            return _productRepository.GetById(product);
        }
        public List<Product> GetProducts(Product product)
        {
            return _productRepository.GetProducts(product);
        }
        public Purchase PurchaseDetails(Product product)
        {
            return _stockRepository.PurchaseDetails(product);
        }
    }
}
