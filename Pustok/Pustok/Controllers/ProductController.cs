using Microsoft.AspNetCore.Mvc;
using Pustok.DAL;
using Pustok.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Pustok.Controllers
{
    public class ProductController : Controller
    {
        public readonly AppDbContext _context;

        public ProductController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> GetDetail(int? id)
        {
            Product product = await _context.Products
                .Include(p => p.Author)
                .Include(p => p.Genre)
                .Include(p => p.ProductImages)
                .FirstOrDefaultAsync(p => p.Id == id);
            return PartialView("_ProductDetailPartial",product);
        }
    }
}
