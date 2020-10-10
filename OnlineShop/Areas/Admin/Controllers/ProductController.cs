using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Data;
using OnlineShop.Models;

namespace OnlineShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private ApplicationDbContext _dbContext;
        private IWebHostEnvironment _webHostEnvironment;

        public ProductController(ApplicationDbContext dbContext, IWebHostEnvironment webHostEnvironment)
        {
            _dbContext = dbContext;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            return View(_dbContext.Products.Include(c => c.ProductType).Include(c => c.SpecialTag).ToList());
        }

        // Get Create Action Method
        public IActionResult Create()
        {
            ViewData["ProductTypeID"] = new SelectList(_dbContext.ProductTypes.ToList(), "ID", "ProductTypeName");
            ViewData["TagID"] = new SelectList(_dbContext.SpecialTags.ToList(), "ID", "SpecialTagName");
            return View();
        }

        // Post Create Action Method
        [HttpPost]
        public async Task<IActionResult> Create(Product product, IFormFile imageFile)
        {
            var errors = ModelState.Values.SelectMany(v => v.Errors);
            if (ModelState.IsValid)
            {
                if (imageFile != null)
                {
                    var fullPathName = Path.Combine(_webHostEnvironment.WebRootPath + "/images", Path.GetFileName(imageFile.FileName));
                    await imageFile.CopyToAsync(new FileStream(fullPathName, FileMode.Create));
                    product.Image = "images/" + imageFile.FileName;
                }
                else
                {
                    product.Image = "images/NoImageFound.PNG";
                }
                _dbContext.Products.Add(product);
                await _dbContext.SaveChangesAsync();
                TempData["Save"] = "Data Saved Successfully";
                return RedirectToAction(nameof(Index));
            }



            return View(product);
        }

        // GET Edit Action Method

        public IActionResult Edit(int? id)
        {

            ViewData["ProductTypeID"] = new SelectList(_dbContext.ProductTypes.ToList(), "ID", "ProductTypeName");
            ViewData["TagID"] = new SelectList(_dbContext.SpecialTags.ToList(), "ID", "SpecialTagName");

            if (id == null)
            {
                return NotFound();
            }
            //var product = _dbContext.Products.Find(id);
            var product = _dbContext.Products.Include(c => c.ProductType).Include(c => c.SpecialTag).FirstOrDefault(c => c.ID == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // Post Edit Action Method
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Product product, IFormFile imageFile)
        {
            if (ModelState.IsValid)
            {
                if (imageFile != null)
                {
                    var fullPathName = Path.Combine(_webHostEnvironment.WebRootPath + "/images", Path.GetFileName(imageFile.FileName));
                    await imageFile.CopyToAsync(new FileStream(fullPathName, FileMode.Create));
                    product.Image = "images/" + imageFile.FileName;
                }
                else
                {
                    product.Image = "images/NoImageFound.PNG";
                }
                _dbContext.Products.Update(product);
                await _dbContext.SaveChangesAsync();
                TempData["Save"] = "Data Saved Successfully";
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        // Get Details Action Method
        public IActionResult Details(int? id)
        {
            ViewData["ProductTypeID"] = new SelectList(_dbContext.ProductTypes.ToList(), "ID", "ProductTypeName");
            ViewData["TagID"] = new SelectList(_dbContext.SpecialTags.ToList(), "ID", "SpecialTagName");

            if (id == null)
            {
                return NotFound();
            }

            var product = _dbContext.Products.Find(id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        //// Post Details Action Method
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult Details(Product product)
        //{
        //    return RedirectToAction(nameof(Index));
        //}

        // Get Delete Action Method
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = _dbContext.Products.Include(c => c.ProductType).Include(c => c.SpecialTag).Where(c => c.ID == id).FirstOrDefault();
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // Post Delete Action Method
        [HttpPost]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirm(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = _dbContext.Products.FirstOrDefault(c => c.ID == id);

            if (product == null)
            {
                return NotFound();
            }

            _dbContext.Remove(product);
            await _dbContext.SaveChangesAsync();
            TempData["Delete"] = "Data Deleted Successfully";
            return RedirectToAction(nameof(Index));


        }

    }
}
