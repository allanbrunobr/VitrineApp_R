
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ConsoleApp2.Serialization;

namespace VitrineApp_R.Pages.Vitrine
{
    public class IndexModel : PageModel
    {
        private readonly VitrineApp_R.Data.VitrineApp_RContext _context;

        public IndexModel(VitrineApp_R.Data.VitrineApp_RContext context)
        {
            _context = context;
        }

        public IList<Item> Item { get;set; }

        public async Task OnGetAsync()
        {
            Item = await _context.Item.ToListAsync();
        }
    }
}
