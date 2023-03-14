using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KnowledgeHubPortal.Domain.Data;
using KnowledgeHubPortal.Domain.Entities;

namespace KnowledgeHubPortal.Data
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly KnowledgeHubDBContext db = new KnowledgeHubDBContext();
        public void Add(Category categoryToAdd)
        {
            db.Categories.Add(categoryToAdd);
            db.SaveChanges();
        }
        
        public void Delete(int categoryId)
        {
            db.Categories.Remove(db.Categories.Find(categoryId));
            db.SaveChanges();
        }

        public void Edit(Category categoryToEdit)
        {
            db.Entry(categoryToEdit).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }

        public List<Category> GetAll()
        {
            return db.Categories.ToList();
        }

        public Category GetCategoryById(int id)
        {
            return db.Categories.Find(id);
        }
    }
}
