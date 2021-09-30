using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ConsoleApp2.Serialization;
using VitrineApp_R.Data;

namespace VitrineApp_R.Pages.Vitrine
{
    public class DetailsModel : PageModel
    {
        private readonly VitrineApp_R.Data.VitrineApp_RContext _context;

        public DetailsModel(VitrineApp_R.Data.VitrineApp_RContext context)
        {
            _context = context;
        }

        public Item Item { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Item = await _context.Item.FirstOrDefaultAsync(m => m.id == id);

            if (Item == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
