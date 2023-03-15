using KnowledgeHubPortal.Domain.Data;
using KnowledgeHubPortal.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnowledgeHubPortal.Data
{
    public class ArticlesRepository : IArticlesRepository
    {
        private readonly KnowledgeHubDBContext db = new KnowledgeHubDBContext();
        public void ApproveArticle(List<int> articleIDs)
        {
            foreach (var a in articleIDs)
            {
                var articleToApprove = db.Articles.Find(a);
                if(articleToApprove != null)
                {
                    articleToApprove.IsApproved = true;
                }
            }
            db.SaveChanges();
        }

        public List<Article> GetArticlesForBrowse()
        {
            return db.Articles.Where(a => a.IsApproved).ToList();
        }

        public async Task<List<Article>> GetArticlesForBrowseAsync()
        {
            return await db.Articles.Where(a => a.IsApproved).ToListAsync();
        }

        public List<Article> GetArticlesForBrowseByCategory(int categoryID)
        {
            return db.Articles.Where(a => a.IsApproved && a.CategoryId == categoryID).ToList();
        }

        public List<Article> GetArticlesForReview()
        {
            return db.Articles.Where(a => !a.IsApproved).ToList();
        }

        public List<Article> GetArticlesForReviewByCategory(int categoryID)
        {
            return db.Articles.Where(a => !a.IsApproved && a.CategoryId == categoryID).ToList();
        }

        public void RejectArticle(List<int> articleIDs)
        {
            foreach (var a in articleIDs)
            {
                var articleToReject = db.Articles.Find(a);
                db.Articles.Remove(articleToReject);
            }
            db.SaveChanges();
        }

        public void SubmitArticle(Article article)
        {
            db.Articles.Add(article);
            db.SaveChanges();
        }
    }
}
