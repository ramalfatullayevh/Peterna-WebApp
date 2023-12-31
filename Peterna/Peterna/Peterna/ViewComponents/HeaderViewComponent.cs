﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Peterna.DAL;

namespace Peterna.ViewComponents
{
    public class HeaderViewComponent:ViewComponent
    {
        readonly AppDbContext _context;

        public HeaderViewComponent(AppDbContext context)
        {
            _context = context;
        }


        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(await _context.Settings.ToDictionaryAsync(s=>s.Key, s=>s.Value));
        }
    }
}
