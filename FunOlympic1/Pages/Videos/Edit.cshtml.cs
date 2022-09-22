using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FunOlympic1;
using FunOlympic1.Data;

namespace FunOlympic1.Pages.Videos
{
    public class EditModel : PageModel
    {
        private readonly FunOlympic1.Data.ApplicationDbContext _context;

        public EditModel(FunOlympic1.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Video Video { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Videos == null)
            {
                return NotFound();
            }

            var video =  await _context.Videos.FirstOrDefaultAsync(m => m.VideoID == id);
            if (video == null)
            {
                return NotFound();
            }
            Video = video;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Video).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VideoExists(Video.VideoID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool VideoExists(int id)
        {
          return _context.Videos.Any(e => e.VideoID == id);
        }
    }
}
