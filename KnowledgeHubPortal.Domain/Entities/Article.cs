using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnowledgeHubPortal.Domain.Entities
{
    public class Article
    {
        public int Id { get; set; }
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
        public virtual Category Category { get; set; }
        public string Submiter { get; set; }
        public bool IsApproved { get; set; }
        public DateTime DateSubmitted { get; set; }
    }
}
