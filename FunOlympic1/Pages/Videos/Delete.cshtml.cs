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
    public class DeleteModel : PageModel
    {
        private readonly FunOlympic1.Data.ApplicationDbContext _context;

        public DeleteModel(FunOlympic1.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Videos == null)
            {
                return NotFound();
            }
            var video = await _context.Videos.FindAsync(id);

            if (video != null)
            {
                Video = video;
                _context.Videos.Remove(Video);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
