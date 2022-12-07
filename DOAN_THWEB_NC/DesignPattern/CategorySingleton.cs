using DOAN_THWEB_NC.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web.ModelBinding;

namespace DOAN_THWEB_NC.DesignPattern
{
    internal class CategorySingleton
    {
        private DB_Shop2Entities3 db = new DB_Shop2Entities3();
        
        public static volatile CategorySingleton Instance;

        private static readonly object lockObject = new object();

        public CategorySingleton()
        {

        }

        public static CategorySingleton GetInstance()
        {
            if(Instance == null)
            {
                lock (lockObject)
                    if(Instance == null)
                    {
                        Instance = new CategorySingleton();
                    }
            }
            return Instance;
        }

        public void AddCategoryProducts(Category category)
        {
            db.Categories.Add(category);
            db.SaveChanges();
        }

        public void RemoveCategoryProducts(int id)
        {
            Category category = db.Categories.Find(id);
            db.Categories.Remove(category);
            db.SaveChanges();
        }

        public void EditCateroryProducts(Category category)
        {
            db.Entry(category).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }
    }
}