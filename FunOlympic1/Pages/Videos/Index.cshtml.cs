using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FunOlympic1;
using FunOlympic1.Data;

namespace FunOlympic1.Pages.Videos
{
    public class IndexModel : PageModel
    {
        private readonly FunOlympic1.Data.ApplicationDbContext _context;

        public IndexModel(FunOlympic1.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Video> Video { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Videos != null)
            {
                Video = await _context.Videos.ToListAsync();
            }
        }
    }
}
