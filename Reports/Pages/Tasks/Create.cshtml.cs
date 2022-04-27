#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Reports.Data;
using Reports.Models;

namespace Reports.Pages.Tasks
{
    public class CreateModel : PageModel
    {
        private readonly Reports.Data.ReportsContext _context;

        public CreateModel(Reports.Data.ReportsContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Models.Task Task { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Task.LastChange = DateTime.Now;
            _context.Task.Add(Task);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
