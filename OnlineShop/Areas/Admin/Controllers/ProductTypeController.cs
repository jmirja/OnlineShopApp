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

        // Create Get Action Method
        public IActionResult Create()
        {
            return View();
        }

        // Create Post Action Method
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductType productType)
        {
            if (ModelState.IsValid)
            {
                _dbContext.productTypes.Add(productType);
                await _dbContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(productType);
        }
    }
}
