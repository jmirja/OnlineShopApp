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
    public class SpecialTagController : Controller
    {
        private ApplicationDbContext _dbContext;

        public SpecialTagController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            return View(_dbContext.SpecialTags.ToList());
        }

        // Get Create Action Method
        public IActionResult Create()
        {
            return View();
        }

        // Post Create Action Method
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SpecialTag specialTag)
        {
            if (ModelState.IsValid)
            {
                _dbContext.SpecialTags.Add(specialTag);
                await _dbContext.SaveChangesAsync();
                TempData["Save"] = "Data Saved Successfully";
                return RedirectToAction(nameof(Index));
            }

            return View(specialTag);
        }

        // Get Edit Action Method
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var specialTag = _dbContext.SpecialTags.Find(id);
            if (specialTag == null)
            {
                return NotFound();
            }

            return View(specialTag);
        }
        // Post Edit Action Method
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(SpecialTag specialTag)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Update(specialTag);
                await _dbContext.SaveChangesAsync();
                TempData["Edit"] = "Data Updated Successfully";
                return RedirectToAction(nameof(Index));
            }

            return View(specialTag);
        }

        // Get Details Action Method
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var specialTag = _dbContext.SpecialTags.Find(id);
            if (specialTag == null)
            {
                return NotFound();
            }

            return View(specialTag);
        }
        // Post Details Action Method
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Details(SpecialTag specialTag)
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

            var specialTag = _dbContext.SpecialTags.Find(id);
            if (specialTag == null)
            {
                return NotFound();
            }

            return View(specialTag);
        }
        // Post Delete Action Method
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int? id, SpecialTag specialTag)
        {
            if (id == null)
            {
                return NotFound();
            }

            if (id != specialTag.ID)
            {
                return NotFound();
            }
            var specialT = _dbContext.SpecialTags.Find(id);

            if (specialT == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _dbContext.Remove(specialT);
                await _dbContext.SaveChangesAsync();
                TempData["Delete"] = "Data Deleted Successfully";
                return RedirectToAction(nameof(Index));
            }

            return View(specialTag);
        }
    }
}
