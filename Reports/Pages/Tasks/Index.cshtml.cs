#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Reports.Data;
using Reports.Models;

namespace Reports.Pages.Tasks
{
    public class IndexModel : PageModel
    {
        private readonly Reports.Data.ReportsContext _context;

        public IndexModel(Reports.Data.ReportsContext context)
        {
            _context = context;
        }

        public IList<Models.Task> Task { get;set; }
        [BindProperty(SupportsGet = true)]
        public int TaskId { get; set; }
        [BindProperty(SupportsGet = true)]
        public int ParentId { get; set; }
        [BindProperty(SupportsGet = true)]
        public DateTime TimeLastChange { get; set; }
        [BindProperty(SupportsGet = true)]
        public string PersonLogin { get; set; }
        public SelectList Status { get; set; }
        [BindProperty(SupportsGet = true)]
        public string TaskStatus { get; set; }

        public async System.Threading.Tasks.Task OnGetAsync()
        {
            IQueryable<string> statusQuery = from m in _context.Task
                                         orderby m.Status
                                         select m.Status;

            var tasks = from m in _context.Task
                        select m;
            var persons = from m in _context.Person
                          select m;
            if (TaskId != 0)
            {
                tasks = tasks.Where(s => s.TaskId == TaskId);
            }

            if(ParentId != 0)
            {
                var employees = persons.Where(x => x.ParentId == ParentId);
                tasks = tasks.Where(s => (employees.SingleOrDefault(x => x.PersonId == s.EmployeeId) != null));
            }

            if(TimeLastChange.ToBinary() != 0)
            {
                tasks = tasks.Where(s => (s.LastChange.Year == TimeLastChange.Year) && (s.LastChange.Month == TimeLastChange.Month) && (s.LastChange.Day == TimeLastChange.Day));
            }

            if(persons.SingleOrDefault(x => x.Login.Equals(PersonLogin))is not null)
            {
                tasks = tasks.Where(s => s.EmployeeId == persons.SingleOrDefault(x => x.Login.Equals(PersonLogin)).PersonId);
            }

            if (!string.IsNullOrEmpty(TaskStatus))
            {
                tasks = tasks.Where(x => x.Status.Equals(TaskStatus));
            }
            Status = new SelectList(await statusQuery.Distinct().ToListAsync());
            Task = await tasks.ToListAsync();
        }
    }
}
