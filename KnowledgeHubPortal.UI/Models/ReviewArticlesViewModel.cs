using KnowledgeHubPortal.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KnowledgeHubPortal.UI.Models
{
    public class ReviewArticlesViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public string Category { get; set; }
        public string Submiter { get; set; }
        [Display(Name = "Submitted")]
        public string WhenSubmitted { get; set; }
    }
}