﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Blog.Models
{
    public class Article
    {
        public Article()
        {
            this.tags = new HashSet<Tag>();
        }

        public Article(string authorId, string title, string content, int categoryId)
        {
            this.AuthorId = authorId;
            this.Tittle = title;
            this.Content = content;
            this.CategoryId = categoryId;
            this.DateAdded = DateTime.Now;
            this.tags = new HashSet<Tag>();
        }


        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Tittle { get; set; }

        public string Content { get; set; }

        public DateTime DateAdded { get; set; }

        public virtual ApplicationUser Author { get; set; }

        [ForeignKey("Author")]
        public string AuthorId { get; set; }

        [ForeignKey("Category")]
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public bool isAuthor(string name)
        {
            return this.Author.UserName.Equals(name);
        }

        private ICollection<Tag> tags;

        public virtual ICollection<Tag> Tags
        {
            get { return this.tags; }
            set { this.tags = value; }
        }
    }
}