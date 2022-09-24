using FunOlympic1.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace FunOlympic1.Pages
{
    public class IndexModel : PageModel
    {


        private readonly ILogger<IndexModel> _logger;
        private readonly FunOlympic1.Data.ApplicationDbContext _context;


        public IndexModel(ILogger<IndexModel> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IList<Video> Video { get; set; } = default!;
        public void OnGet()
        {
            // IEnumerable<Video> videoList = _context.Videos.ToList();
            if (_context.Videos != null)
            {
                Video =  _context.Videos.ToList();
            }

        }
    }
}