using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blog.Models
{
    public class HomeViewModel
    {

        public virtual ICollection<Article> Articles { get; set; }

        public virtual ICollection<Category> Categories { get; set; }
    }
}