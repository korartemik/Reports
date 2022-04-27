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

namespace Reports.Pages.SpecialPages
{
    public class KPIEmployeesModel : PageModel
    {
        private readonly Reports.Data.ReportsContext _context;

        public KPIEmployeesModel(Reports.Data.ReportsContext context)
        {
            _context = context;
        }

        public IList<Person> PersonDoneReport { get; set; }
        public IList<Person> PersonNoDoneReport { get; set; }
        [BindProperty(SupportsGet = true)]
        public int PersonId { get; set; }

        public async System.Threading.Tasks.Task OnGetAsync()
        {
            if (PersonId != 0)
            {
                var allPersons = from m in _context.Person
                                 select m;
                var posts = from m in _context.Post
                            select m;
                var persons = allPersons.Where(x => x.ParentId == PersonId);
                PersonDoneReport = await persons.Where(x => posts.SingleOrDefault(t => t.CreatorId == x.PersonId) != null).ToListAsync();
                PersonNoDoneReport = await persons.Where(x => posts.SingleOrDefault(t => t.CreatorId == x.PersonId) == null).ToListAsync();
            }
            else
            {
                var allPersons = from m in _context.Person
                                 select m;
                allPersons = allPersons.Where(x => false);
                PersonDoneReport = await allPersons.ToListAsync();
                PersonNoDoneReport = await allPersons.ToListAsync();
            }
        }
    }
}
