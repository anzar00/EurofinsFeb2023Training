using KnowledgeHubPortal.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnowledgeHubPortal.Domain.Data
{
    public interface IArticlesRepository
    {
        void SubmitArticle(Article article);
        void ApproveArticle(List<int> articleIDs);
        void RejectArticle(List<int> articleIDs);
        List<Article> GetArticlesForReviewByCategory(int categoryID);
        List<Article> GetArticlesForBrowseByCategory(int categoryID);
        List<Article> GetArticlesForReview();
        List<Article> GetArticlesForBrowse();
    }
}
