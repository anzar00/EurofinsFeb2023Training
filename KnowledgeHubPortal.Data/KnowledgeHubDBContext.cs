using KnowledgeHubPortal.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnowledgeHubPortal.Data
{
    internal class KnowledgeHubDBContext :DbContext
    {
        public KnowledgeHubDBContext():base("name=DefaultConnection") { }
        public DbSet<Category> Categories{ get; set; }
        public DbSet<Article> Articles { get; set; }
    }
}
