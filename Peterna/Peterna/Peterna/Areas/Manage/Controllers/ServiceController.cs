using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Peterna.DAL;
using Peterna.Models;
using Peterna.ViewModels;
using Peterna.ViewModels;

namespace Peterna.Areas.Manage.Controllers
{
    [Area("Manage")]
    [Authorize]
    public class ServiceController : Controller
    {
        readonly AppDbContext _context;

        public ServiceController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(int page=1)
        {
            ICollection<Service> services = await _context.Services.Skip((page-1)*2).Take(2).ToListAsync();
            PaginationVM<Service> vm = new PaginationVM<Service>
            {
                MaxPageCount= (int)Math.Ceiling((decimal)_context.Services.Count() / 2),
                CurrentPage =page,
                Items= services,
            }; 
            return View(vm);
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateServiceVM serviceVM)
        {
            if(!ModelState.IsValid) return View(serviceVM);
            if (serviceVM is null) return BadRequest();
            Service service = new Service
            {
                Name = serviceVM.Name,
                PrimaryDescription = serviceVM.PrimaryDescription,
                SecondaryDescription = serviceVM.SecondaryDescription,
                IconUrl = serviceVM.IconUrl,
            };
            await _context.Services.AddAsync(service);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Update(int?id)
        {
            if (id is null) return BadRequest();
            Service service = _context.Services.Find(id);
            if (service is null) return NotFound();
            UpdateServiceVM serviceVM = new UpdateServiceVM
            {
                Name = service.Name,
                PrimaryDescription = service.PrimaryDescription,
                SecondaryDescription = service.SecondaryDescription,
                IconUrl = service.IconUrl,

            };
            return View(serviceVM);
        }

        [HttpPost]
        public async Task<IActionResult> Update(int? id, UpdateServiceVM serviceVM) 
        {
            if (!ModelState.IsValid) return View(serviceVM);
            if (serviceVM is null) return BadRequest();
            Service service = _context.Services.Find(id);
            if (service is null) return NotFound();
            service.Name = serviceVM.Name;
            service.PrimaryDescription = serviceVM.PrimaryDescription;
            service.SecondaryDescription = serviceVM.PrimaryDescription;
            service.IconUrl = serviceVM.IconUrl;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }

        public IActionResult Delete(int? id)
        {
            if (id is null) return BadRequest();
            Service service = _context.Services.Find(id);
            if (service is null) return NotFound();
             _context.Services.Remove(service);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

    }
}
