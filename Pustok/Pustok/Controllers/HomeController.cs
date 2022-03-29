using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pustok.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pustok.ViewModels.Home;

namespace Pustok.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(new HomeVm
            {
                Sliders = await _context.Sliders.ToListAsync(),
                UpPromotions = await _context.UpPromotions.ToListAsync(),
                Feature = await _context.Products.Include(p => p.Author).Include(p => p.Genre).Where(p => p.IsFeature).OrderByDescending(p => p.Id).Take(8).ToListAsync(),
                Arrival = await _context.Products.Include(p => p.Author).Include(p => p.Genre).Where(p => p.IsArrival).OrderByDescending(p => p.Id).Take(8).ToListAsync(),
                MostView = await _context.Products.Include(p => p.Author).Include(p => p.Genre).Where(p => p.IsMostView).OrderByDescending(p => p.Id).Take(8).ToListAsync()
            });
    
        }
    }
}
