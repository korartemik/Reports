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

namespace Reports.Pages.Persons
{
    public class IndexModel : PageModel
    {
        private readonly Reports.Data.ReportsContext _context;

        public IndexModel(Reports.Data.ReportsContext context)
        {
            _context = context;
        }

        public IList<Person> Person { get;set; }
        [BindProperty(SupportsGet = true)]
        public int PersonId { get; set; }

        public async System.Threading.Tasks.Task OnGetAsync()
        {
            var persons = from m in _context.Person
                          select m;
            if (PersonId != 0)
            {
                persons = persons.Where(s => s.PersonId == PersonId);
            }
            Person = await persons.ToListAsync();
        }
    }
}
