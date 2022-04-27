using Microsoft.EntityFrameworkCore;
using Reports.Data;

namespace Reports.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ReportsContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<ReportsContext>>()))
            {
                if (context == null || context.Person == null)
                {
                    throw new ArgumentNullException("Null RazorPagesMovieContext");
                }

                // Look for any movies.
                if (context.Person.Any())
                {
                    return;   // DB has been seeded
                }

                context.Person.AddRange(
                    new Person
                    {
                        Login = "GenDirector",
                        ParentId = 1
                    },

                    new Person
                    {
                        Login = "ZamGenDirector1",
                        ParentId = 1
                    },

                    new Person
                    {
                        Login = "ZamGenDirector2",
                        ParentId = 1
                    },

                    new Person
                    {
                        Login = "Boy",
                        ParentId = 2
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
