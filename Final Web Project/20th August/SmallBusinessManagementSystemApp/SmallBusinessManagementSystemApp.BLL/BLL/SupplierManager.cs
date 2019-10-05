﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmallBusinessManagementSystemApp.Models.Models;
using SmallBusinessManagementSystemApp.Repository.Repository;

namespace SmallBusinessManagementSystemApp.BLL.BLL
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

        public List<Supplier> GetAll()
        {
            return _supplierRepository.GetAll();
        }
    }
}