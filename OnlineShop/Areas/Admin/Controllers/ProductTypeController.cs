using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Data;
using OnlineShop.Models;

namespace OnlineShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductTypeController : Controller
    {
        private ApplicationDbContext _dbContext;

        public ProductTypeController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            return View(_dbContext.productTypes.ToList());
        }

        // Get Create Action Method
        public IActionResult Create()
        {
            return View();
        }

        // Post Create Action Method
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductType productType)
        {
            if (ModelState.IsValid)
            {
                _dbContext.productTypes.Add(productType);
                await _dbContext.SaveChangesAsync();
                TempData["Save"] = "Data Saved Successfully";
                return RedirectToAction(nameof(Index));
            }

            return View(productType);
        }

        // Get Edit Action Method
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productType = _dbContext.productTypes.Find(id);
            if (productType == null)
            {
                return NotFound();
            }

            return View(productType);
        }
        // Post Edit Action Method
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ProductType productType)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Update(productType);
                await _dbContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(productType);
        }

        // Get Details Action Method
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productType = _dbContext.productTypes.Find(id);
            if (productType == null)
            {
                return NotFound();
            }

            return View(productType);
        }
        // Post Details Action Method
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Details(ProductType productType)
        {
            return RedirectToAction(nameof(Index));
        }


        // Get Delete Action Method
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productType = _dbContext.productTypes.Find(id);
            if (productType == null)
            {
                return NotFound();
            }

            return View(productType);
        }
        // Post Delete Action Method
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int? id, ProductType productType)
        {
            if (id==null)
            {
                return NotFound();
            }

            if (id != productType.ID)
            {
                return NotFound();
            }
            var productTyp = _dbContext.productTypes.Find(id);

            if (productTyp==null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _dbContext.Remove(productTyp);
                await _dbContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(productType);
        }
    }
}
