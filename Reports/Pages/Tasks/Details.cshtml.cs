#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Reports.Data;
using Reports.Models;

namespace Reports.Pages.Tasks
{
    public class DetailsModel : PageModel
    {
        private readonly Reports.Data.ReportsContext _context;

        public DetailsModel(Reports.Data.ReportsContext context)
        {
            _context = context;
        }

        public Models.Task Task { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Task = await _context.Task.FirstOrDefaultAsync(m => m.TaskId == id);

            if (Task == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
