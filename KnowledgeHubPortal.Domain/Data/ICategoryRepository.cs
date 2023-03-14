using KnowledgeHubPortal.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnowledgeHubPortal.Domain.Data
{
    public interface ICategoryRepository
    {
        void Add(Category categoryToAdd);
        List<Category> GetAll();
        void Edit(Category categoryToEdit);
        void Delete(int categoryId);
    }
}
