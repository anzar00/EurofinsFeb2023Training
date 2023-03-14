using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KnowledgeHubPortal.UI.Models
{
    public class ArticleSubmitViewModel
    {
        [Required(ErrorMessage = "Enter article title.")]
        [MinLength(10, ErrorMessage = "Title should be atleast 10 characters long.")]
        [MaxLength(100)]
        public string Title { get; set; }
        [Required(ErrorMessage = "Enter article url.")]
        [Url]
        public string Url { get; set; }
        [MaxLength(500)]
        public string Description { get; set; }
        public int CategoryId { get; set; }
    }
}