using SBMS_Project2.Models.Models;
using SBMS_Project2.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBMS_Project2.BLL.BLL
{
    public class SupplierManager
    {
        SupplierRepository _supplierRepository = new SupplierRepository();

        public bool AddSupplier(Supplier supplier)
        {
            return _supplierRepository.AddSupplier(supplier);
        }

        public bool DeleteSupplier(Supplier supplier)
        {
            return _supplierRepository.DeleteSupplier(supplier);
        }

        public bool UpdateSupplier(Supplier supplier)
        {
            return _supplierRepository.UpdateSupplier(supplier);
        }

        public Supplier GetById(Supplier supplier)
        {
            return _supplierRepository.GetById(supplier);
        }

        public Supplier GetDuplicate(Supplier supplier)
        {
            return _supplierRepository.GetDuplicate(supplier);
        }

        public List<Supplier> GetAll()
        {
            return _supplierRepository.GetAll();
        }
    }
}
