using mvc.DB;
using mvc.Entities;
using System;
using System.IO;
using System.Linq;

namespace mvc.Models
{
    public class CategoryRepository
    {
        private readonly RockfestDB _rockfestDB;

        public CategoryRepository(RockfestDB rockfestDB)
        {
            _rockfestDB = rockfestDB;
        }
        public IQueryable<Categories> allCategories
        {
            get
            {
                return _rockfestDB.Categories.OrderBy(x => x.Id);
            }
        }

        public bool AddNewCategory(Categories category)
        {
            _rockfestDB.Categories.Add(category);
            if (this.SaveChanges() == 1)
            {
                return true;
            }
            return false;
        }        

        public bool UpdateCategoryCountByCatId(int id)
        {
            var category = _rockfestDB.Categories.FirstOrDefault(x => x.Id == id);
            category.CategoryCount++; 
            if (this.SaveChanges() == 1)
            {
                return true;
            }
            return false;
        }

        public Categories GetCategoryByName(string categoryName)
        {
            return _rockfestDB.Categories.First(x => x.CategoryName == categoryName);
        }
        public int SaveChanges()
        {
            return _rockfestDB.SaveChanges();
        }

    }
}
