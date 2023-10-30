using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ContosoUniversity;
using ContosoUniversity.Data;

namespace ContosoUniversity.Pages.Students
{
    public class IndexModel : PageModel
    {
        private readonly ContosoUniversity.Data.SchoolContext _context;

        public IndexModel(ContosoUniversity.Data.SchoolContext context)
        {
            _context = context;
        }

        public string FirstNameSort { get; set; }
        public string LastNameSort { get; set; }
        public string DateSort { get; set; }

        public IList<Student> Students { get; set; } = default!;

        public async Task OnGetAsync(string sortOrder)
        {
            LastNameSort = String.IsNullOrEmpty(sortOrder) ? "lastname_desc" : "";
            FirstNameSort = sortOrder == "FirstName" ? "firstname_desc" : "FirstName";
            DateSort = sortOrder == "Date" ? "date_desc" : "Date";

            IQueryable<Student> studentsIQ = from s in _context.Students
                                             select s;
            
            switch (sortOrder)
            {
                case "lastname_desc":
                    studentsIQ = studentsIQ.OrderByDescending(s => s.LastName);
                    break;
                case "FirstName":
                    studentsIQ = studentsIQ.OrderBy(s => s.FirstName);
                    break;
                case "firstname_desc":
                    studentsIQ = studentsIQ.OrderByDescending(s => s.FirstName);
                    break;
                case "Date":
                    studentsIQ = studentsIQ.OrderBy(s => s.EnrollmentDate);
                    break;
                case "date_desc":
                    studentsIQ = studentsIQ.OrderByDescending(s => s.EnrollmentDate);
                    break;
                default:
                    studentsIQ = studentsIQ.OrderBy(s => s.LastName);
                    break;
            }

            

            Students = await studentsIQ.AsNoTracking().ToListAsync();
        }
    }
}
