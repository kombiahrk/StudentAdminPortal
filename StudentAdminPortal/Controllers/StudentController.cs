using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentAdminPortal.Data;

namespace StudentAdminPortal.Controllers
{
    // Controller responsible for handling student-related requests
    public class StudentController : Controller
    {
        private readonly ApplicationDbContext dbContext;

        // Constructor to inject the database context
        public StudentController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        // Action method that retrieves all students from the database and returns the default view
        [HttpPost]
        public async Task<IActionResult> Index()
        {
            // Fetch all students asynchronously from the database
            var allStudents = await dbContext.Students.ToListAsync();

            // Pass the list of students to the view
            return View(allStudents);
        }
    }
}
