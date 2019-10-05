using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using StockManagementSystemApp.Models;
using StockManagementSystemApp.Repository;

namespace StockManagementSystemApp.BLL
{
    class CompanyManager
    {
        CompanyRepository _companyRepository = new CompanyRepository();

        public DataTable DisplayGrid()
        {
            return _companyRepository.DisplayGrid();
        }

        public int InsertCompany(Company company)
        {
            return _companyRepository.InsertCompany(company);
        }

        public int UpdateCompany(Company company, int rowIndex)
        {
            return _companyRepository.UpdateCompany(company, rowIndex);
        }

        public int Duplicate(Company company)
        {
            return _companyRepository.Duplicate(company);
        }
    }
}
