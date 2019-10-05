﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SBMS_Project2.Models.Models;
using SBMS_Project2.Repository.Repository;

namespace SBMS_Project2.BLL.BLL
{
    public class CategoryManager
    {
        CategoryRepository _categoryRepository=new CategoryRepository();

        public bool Add(Category category)
        {
            return _categoryRepository.Add(category);
        }

        public bool Delete(Category category)
        {
            return _categoryRepository.Delete(category);
        }

        public bool Update(Category category)
        {
            return _categoryRepository.Update(category);
        }

        public List<Category> GetAll()
        {
            return _categoryRepository.GetAll();
        }

        public Category GetById(Category category)
        {
            return _categoryRepository.GetById(category);
        }
    }
}
