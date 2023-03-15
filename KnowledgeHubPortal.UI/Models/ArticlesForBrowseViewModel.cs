using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KnowledgeHubPortal.UI.Models
{
    public class ArticlesForBrowseViewModel
    {
        public string Title { get; set; }
        public string Url { get; set; }
        public string Description { get; set; }
        [Display(Name = "Category Name")]
        public string CategoryName { get; set; }
        public string Submiter { get; set; }
        [Display(Name = "Submitted")]
        public string CreatedOn { get; set; }
    }
}