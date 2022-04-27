#nullable disable
using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Reports.Data;
using Reports.Models;

namespace Reports.Pages.SpecialPages
{
    public class WeeklyTasksModel : PageModel
    {
        private readonly ReportsContext _context;

        public WeeklyTasksModel(ReportsContext context)
        {
            _context = context;
        }
        
        public IList<Models.Task> Task { get; set; }
        [BindProperty(SupportsGet = true)]
        public int PersonId { get; set; }
        public async System.Threading.Tasks.Task OnGetAsync()
        {
            IQueryable<Models.Task> tasks = from m in _context.Task
                        select m;
            if (PersonId != 0)
            {
                tasks = tasks.Where(x => x.EmployeeId == PersonId);
                //tasks = tasks.Where(x => (DateTime.Now - x.LastChange).Days <= 7);
            }

            Task = await tasks.ToListAsync();
        }
    }
}
