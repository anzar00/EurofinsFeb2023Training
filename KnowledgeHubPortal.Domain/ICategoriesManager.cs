using KnowledgeHubPortal.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnowledgeHubPortal.Domain
{
    public interface ICategoriesManager
    {
        void AddCategory(Category category);
        List<Category> ListCategories();
        void EditCategory(Category categoryToEdit);
        void DeleteCategory(int categoryId);
    }
}
