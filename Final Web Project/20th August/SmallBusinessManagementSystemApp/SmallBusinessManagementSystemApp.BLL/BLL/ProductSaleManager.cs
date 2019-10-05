using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmallBusinessManagementSystemApp.Models.Models;
using SmallBusinessManagementSystemApp.Repository.Repository;

namespace SmallBusinessManagementSystemApp.BLL.BLL
{
    public class ProductSaleManager
    {
        ProductSaleRepository _productSaleRepository = new ProductSaleRepository();

        public bool AddProductSale(ProductSale productSale)
        {
            return _productSaleRepository.AddProductSale(productSale);
        }

        public bool AddProductSale(List<ProductSale> productSales)
        {
            return _productSaleRepository.AddProductSale(productSales);
        }

        public bool DeleteProductSale(ProductSale productSale)
        {
            return _productSaleRepository.DeleteProductSale(productSale);
        }

        public bool UpdateProductSale(ProductSale productSale)
        {
            return _productSaleRepository.UpdateProductSale(productSale);
        }

        public ProductSale GetById(ProductSale productSale)
        {
            return _productSaleRepository.GetById(productSale);
        }

        public ProductSale GetByProductId(int id)
        {
            return _productSaleRepository.GetByProductId(id);
        }
        public List<ProductSale> GetByProduct(int productId)
        {
            return _productSaleRepository.GetByProduct(productId);
        }

        public List<ProductSale> GetByProductSaleId(int id)
        {
            return _productSaleRepository.GetByProductSaleId(id);
        }

        public List<ProductSale> GetAll()
        {
            return _productSaleRepository.GetAll();
        }
    }
}
