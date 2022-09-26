using FunOlympic1.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FunOlympic1.Pages
{
    public class PlayVideoModel : PageModel
    {
        private readonly ILogger<PlayVideoModel> _logger;
        private readonly FunOlympic1.Data.ApplicationDbContext _context;


        public PlayVideoModel(ILogger<PlayVideoModel> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }
        public void OnGet()
        {
        }
    }
}
