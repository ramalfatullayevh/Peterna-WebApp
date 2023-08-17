using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Peterna.DAL;
using Peterna.Models;
using Peterna.ViewModels;

namespace Peterna.Areas.Manage.Controllers
{
    [Area("Manage")]
    [Authorize]
    public class SettingController : Controller
    {
        readonly AppDbContext _context;

        public SettingController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(int page = 1)
        {
            ICollection<Setting> settings = await _context.Settings.Skip((page - 1) * 2).Take(2).ToListAsync();
            PaginationVM<Setting> vm = new PaginationVM<Setting>
            {
                MaxPageCount = (int)Math.Ceiling((decimal)_context.Services.Count() / 3),
                CurrentPage = page,
                Items = settings,
            };
            return View(vm);
        }

        public async Task<IActionResult> Update(int?id)
        {
            if (id is null) return BadRequest();
            Setting setting = await  _context.Settings.FindAsync(id);
            if (setting is null) return NotFound();
            UpdateSettingVM settingVM = new UpdateSettingVM
            {
                Value = setting.Value,

            };
            return View(settingVM);
        }

        [HttpPost]
        public async Task<IActionResult> Update(int? id, UpdateSettingVM settingVM)
        {
            if (!ModelState.IsValid) return View(settingVM);
            if (settingVM is null) return BadRequest();
            Setting setting = _context.Settings.Find(id);
            if (setting is null) return NotFound();
            setting.Value = settingVM.Value;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }
    }
}
