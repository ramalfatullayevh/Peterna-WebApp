using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Peterna.DAL;
using System.Diagnostics;

namespace Peterna.Controllers
{
    public class HomeController : Controller
    {
        readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Services.ToListAsync());
        }

        
    }
}