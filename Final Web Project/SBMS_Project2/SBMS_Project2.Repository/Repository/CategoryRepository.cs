using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SBMS_Project2.DatabaseContext.DatabaseContext;
using SBMS_Project2.Models.Models;
using System.Data.Entity;

namespace SBMS_Project2.Repository.Repository
{
    public class CategoryRepository
    {
        SBMSDbContext db=new SBMSDbContext();


        public bool Add(Category category)
        {
            db.Categories.Add(category);
            bool isSaved = db.SaveChanges() > 0;
            if (isSaved)
            {
                return true;
            }

            return false;
        }

        public bool Delete(Category category)
        {
            Category aCategory = db.Categories.FirstOrDefault(c => c.ID == category.ID);
            db.Categories.Remove(aCategory);
            bool isDelete = db.SaveChanges() > 0;
            if (isDelete)
            {
                return true;
            }

            return false;
        }

        public bool Update(Category category)
        {
            db.Entry(category).State = EntityState.Modified;
            bool isUpdated = db.SaveChanges() > 0;
            if (isUpdated)
            {
                return true;
            }

            return false;
        }

        public List<Category> GetAll()
        {
            return db.Categories.Include(c=>c.Products).ToList();
        }

        public Category GetById(Category category)
        {
            Category item = db.Categories.FirstOrDefault(c => c.ID == category.ID);
            return item;
        }
        
    }
}
