using KnowledgeHubPortal.Domain.Data;
using KnowledgeHubPortal.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnowledgeHubPortal.Domain
{
    public class ArticlesManager : IArticlesManager
    {
        private IArticlesRepository repo = null;

        public ArticlesManager(IArticlesRepository repo)
        {
            this.repo=repo;
        }

        public void ApproveArticle(List<int> articleIDs)
        {
            repo.ApproveArticle(articleIDs);
        }

        public List<Article> GetArticlesForBrowse()
        {
            return repo.GetArticlesForBrowse();
        }

        public List<Article> GetArticlesForBrowseByCategory(int categoryID)
        {
            return repo.GetArticlesForBrowseByCategory(categoryID);
        }

        public List<Article> GetArticlesForReview()
        {
            return repo.GetArticlesForReview();
        }

        public List<Article> GetArticlesForReviewByCategory(int categoryID)
        {
            return repo.GetArticlesForReviewByCategory(categoryID);
        }

        public void RejectArticle(List<int> articleIDs)
        {
            repo.RejectArticle(articleIDs);
        }

        public void SubmitArticle(Article article)
        {
            repo.SubmitArticle(article);
        }
    }
}
