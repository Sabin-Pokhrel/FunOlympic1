using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using FunOlympic1;
using FunOlympic1.Data;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace FunOlympic1.Pages.Users
{
    public class CreateModel : PageModel
    {
        private readonly FunOlympic1.Data.ApplicationDbContext _context;


        public CreateModel(FunOlympic1.Data.ApplicationDbContext context)
        {
            _context = context;
        }
        [ValidateNever]
        public IEnumerable<SelectListItem> RoleList { get; set; }
        public IActionResult OnGetAsync()
        {



            return Page();

        }

        [BindProperty]
        public ApplicationUser Video { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.ApplicationUsers.Add(Video);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }


}
