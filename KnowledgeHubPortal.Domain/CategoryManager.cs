using KnowledgeHubPortal.Domain.Data;
using KnowledgeHubPortal.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnowledgeHubPortal.Domain
{
    public class CategoryManager : ICategoriesManager
    {
        private ICategoryRepository repo = null;
        public CategoryManager(ICategoryRepository repo)
        {
            this.repo = repo;
        }
        public void AddCategory(Category category)
        {
            // Apply Bussiness Rules
            // Call Data Layer For Saving
            repo.Add(category);

        }

        public void DeleteCategory(int categoryId)
        {
            repo.Delete(categoryId);
        }

        public void EditCategory(Category categoryToEdit)
        {
            repo.Edit(categoryToEdit);
        }

        public Category GetCategoryById(int id)
        {
            return repo.GetCategoryById(id);
        }

        public List<Category> ListCategories()
        {
            return repo.GetAll();
        }
    }
}
