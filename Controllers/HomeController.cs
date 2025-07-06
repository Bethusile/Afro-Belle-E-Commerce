using AB.Data;
using AB.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;

namespace AB.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            // Fetch products based on categories
            var bonnets = await _context.Products.Where(p => p.Category == "Bonnets").ToListAsync();
            var scrunchies = await _context.Products.Where(p => p.Category == "Scrunchies").ToListAsync();
            var pillowcases = await _context.Products.Where(p => p.Category == "Pillowcases").ToListAsync();
            var newArrivals = await _context.Products.OrderByDescending(p => p.Id).Take(4).ToListAsync();  // Latest 4 products

            ViewBag.Bonnets = bonnets;
            ViewBag.Scrunchies = scrunchies;
            ViewBag.Pillowcases = pillowcases;
            ViewBag.NewArrivals = newArrivals;

            return View();
        }

    }

}
