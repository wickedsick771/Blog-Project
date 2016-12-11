using Blog.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Blog.Controllers.Admin
{
    public class CategoryController : Controller
    {
        // GET: Category
        public ActionResult Index()
        {
            return RedirectToAction("List");
        }

        public ActionResult ListArticles(int? id)
        {
            using(var db = new BlogDbContext())
            {
                var articles = db.Categories
                    .Include(t => t.Articles.Select(a => a.Tags))
                    .Include(c => c.Articles.Select(a => a.Author))
                    .FirstOrDefault(c => c.Id == id)
                    .Articles
                    .ToList();

                return View(articles);
            }
        }

        //GET: Category/List
        public ActionResult List()
        {
            using (var database = new BlogDbContext())
            {
                var categories = database.Categories
                    .ToList();

                return View(categories);
            }
        }

        //GET: Category/Create
        public ActionResult Create()
        {
            return View();
        }

        //POST: Category/Create
        [HttpPost]
        public ActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
                using(var database = new BlogDbContext())
                {
                    database.Categories.Add(category);
                    database.SaveChanges();

                    return RedirectToAction("Index");
                }
            }

            return View(category);
        }

        //GET: Category/Edit
        public ActionResult Edit(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            using(var database = new BlogDbContext())
            {
                var category = database.Categories
                    .FirstOrDefault(c => c.Id == id);

                if(category == null)
                {
                    return HttpNotFound();
                }

                return View(category);
            }
        }
        
        //POST: Category/Edit
        [HttpPost]
        public ActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                using (var database = new BlogDbContext())
                {
                    database.Entry(category).State = EntityState.Modified;
                    database.SaveChanges();

                    return RedirectToAction("Index");
                }
            }

            return View(category);
        }

        //GET: Category/Delete
        public ActionResult Delete(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            
            using(var database = new BlogDbContext())
            {
                var category = database.Categories
                    .FirstOrDefault(c => c.Id == id);

                if(category == null)
                {
                    return HttpNotFound();
                }

                return View(category);
            }
        }

        //POST: Category/Delete
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(int? id)
        {
                using(var database = new BlogDbContext())
                {
                    var category = database.Categories
                         .FirstOrDefault(c => c.Id == id);

                    var categoriesArticles = category.Articles
                        .ToList();

                    foreach(var article in categoriesArticles)
                    {
                        database.Articles.Remove(article);
                    }

                    database.Categories.Remove(category);
                    database.SaveChanges();

                    return RedirectToAction("Index");
                }
            
        }
    }
}