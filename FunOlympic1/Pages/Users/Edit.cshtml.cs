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
using Microsoft.AspNetCore.Identity;

namespace FunOlympic1.Pages.User
{
    public class EditModel : PageModel
    {
        private readonly FunOlympic1.Data.ApplicationDbContext _context;
        private readonly UserManager<IdentityUser>_userManager;

        public EditModel(FunOlympic1.Data.ApplicationDbContext context ,UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [BindProperty]
        public ApplicationUser Video { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(String? id)
        {
            if (id == null || _context.ApplicationUsers == null)
            {
                return NotFound();
            }

            var video =  await _context.ApplicationUsers.FirstOrDefaultAsync(m => m.Id== id);
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

            //_context.Attach(Video).State = EntityState.Modified;
            ApplicationUser user = await _context.ApplicationUsers.FindAsync(Video.Id);
            user.Email = Video.Email;   
            user.PhoneNumber= Video.PhoneNumber;
            user.UserName= Video.UserName;  
            user.Name= Video.Name;
            user.Country   = Video.Country;
            user.EmailConfirmed = Video.EmailConfirmed;
            try

            {
                IdentityResult result = await _userManager.UpdateAsync(user);
                //await _context.SaveChangesAsync();
               

            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(Video.Id))
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

        private bool UserExists(string id)
        {
          return _context.ApplicationUsers.Any(e => e.Id == id);
        }
    }
}
