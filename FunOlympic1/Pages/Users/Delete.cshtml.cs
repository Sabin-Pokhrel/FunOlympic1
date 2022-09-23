using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FunOlympic1;
using FunOlympic1.Data;

namespace FunOlympic1.Pages.User

{
    public class DeleteModel : PageModel
    {
        private readonly FunOlympic1.Data.ApplicationDbContext _context;

        public DeleteModel(FunOlympic1.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
      public ApplicationUser Video { get; set; }

        public async Task<IActionResult> OnGetAsync(String? id)
        {
            if (id == null || _context.ApplicationUsers == null)
            {
                return NotFound();
            }

            var video = await _context.ApplicationUsers.FirstOrDefaultAsync(m => m.Id == id);

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

        public async Task<IActionResult> OnPostAsync(string? id)
        {
            if (id == null || _context.ApplicationUsers == null)
            {
                return NotFound();
            }
            var video = await _context.ApplicationUsers.FindAsync(id);

            if (video != null)
            {
                Video = video;
                _context.Users.Remove(Video);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
