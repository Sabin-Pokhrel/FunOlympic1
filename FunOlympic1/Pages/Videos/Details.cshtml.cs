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
    public class DetailsModel : PageModel
    {
        private readonly FunOlympic1.Data.ApplicationDbContext _context;

        public DetailsModel(FunOlympic1.Data.ApplicationDbContext context)
        {
            _context = context;
        }

      public Video Video { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Videos == null)
            {
                return NotFound();
            }

            var video = await _context.Videos.FirstOrDefaultAsync(m => m.VideoID == id);
            if (video == null)
            {
                return NotFound();
            }
            else 
            {
                Video = video;
            }
            return Page();
        }
    }
}
