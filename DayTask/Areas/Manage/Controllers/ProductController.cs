using DayTask.DAL;
using DayTask.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DayTask.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class ProductController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _ev;

        public ProductController(AppDbContext context, IWebHostEnvironment ev)
        {
            _context = context;
            _ev = ev;
        }
        public IActionResult Index()
        {

            return View(_context.Products.Include(x => x.Category).ToList());
        }
        public IActionResult Create()
        {
            ViewBag.Cat = new SelectList(_context.Categories, nameof(Category.Id), nameof(Category.CatName));
            return View();
        }
        [HttpPost]
        public IActionResult Create(Product product)
        {
            ViewBag.Cat = new SelectList(_context.Categories, nameof(Category.Id), nameof(Category.CatName));
            string fileName = Guid.NewGuid().ToString() + product.Photo.FileName;
            string path = Path.Combine(_ev.WebRootPath, "assets", "imgs", "portfolio");

            using (FileStream stream = new FileStream(Path.Combine(path, fileName), FileMode.Create))
            {
                product.Photo.CopyTo(stream);
            }
            Product product1 = new Product()
            {
                Title = product.Title,
                Des = product.Des,
                Link = product.Link,
                CategoryId = product.CategoryId,
                Image = fileName

            };
            
            _context.Products.Add(product);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Edit()
        {
            return View();
        }
        public IActionResult Delete(int id)
        {
            Product product = _context.Products.Find(id);  
            if(product == null) return NotFound();
            _context.Products.Remove(product);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
