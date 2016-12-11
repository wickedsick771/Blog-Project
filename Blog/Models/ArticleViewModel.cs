using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Blog.Models
{
    public class ArticleViewModel
    {
        public string Title { get; set; }

        public string Content { get; set; }

        [Required]
        [ForeignKey("Category")]
        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        [Required]
        public string AuthorId { get; set; }

        public  ICollection<Category> Categories { get; set; }

        public string Tags { get; set; }
    }
}