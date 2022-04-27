#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Reports.Data;
using Reports.Models;

namespace Reports.Pages.Posts
{
    public class IndexModel : PageModel
    {
        private readonly Reports.Data.ReportsContext _context;

        public IndexModel(Reports.Data.ReportsContext context)
        {
            _context = context;
        }

        public IList<Post> Post { get;set; }
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        public SelectList Genres { get; set; }
        [BindProperty(SupportsGet = true)]
        public int MovieGenre { get; set; }

        public async System.Threading.Tasks.Task OnGetAsync()
        {
            IQueryable<int> genreQuery = from m in _context.Post
                                            orderby m.CreatorId
                                            select m.CreatorId;

            var posts = from m in _context.Post
                         select m;
            if (!string.IsNullOrEmpty(SearchString))
            {
                posts = posts.Where(s => s.TextPost.Contains(SearchString));
            }

            if (MovieGenre != 0)
            {
                posts = posts.Where(x => x.CreatorId == MovieGenre);
            }
            Genres = new SelectList(await genreQuery.Distinct().ToListAsync());
            Post = await posts.ToListAsync();
        }
    }
}
