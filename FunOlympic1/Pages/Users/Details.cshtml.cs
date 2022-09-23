using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FunOlympic1;
using FunOlympic1.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace FunOlympic1.Pages.Users

{
    public class DetailsModel : PageModel
    {
        private readonly FunOlympic1.Data.ApplicationDbContext _context;

        public DetailsModel(FunOlympic1.Data.ApplicationDbContext context)
        {
            _context = context;
        }

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
    }
}
