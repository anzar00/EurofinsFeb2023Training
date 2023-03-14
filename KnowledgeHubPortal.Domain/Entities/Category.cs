using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace KnowledgeHubPortal.Domain.Entities
{
    public class Category
    {
        public int CategoryId { get; set; }
        [Required(ErrorMessage = "Enter caregory name.")]
        [MinLength(5,ErrorMessage = "Name should be atleast 5 characters long.")]
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(500)]
        public string Description { get; set; }
    }
}
