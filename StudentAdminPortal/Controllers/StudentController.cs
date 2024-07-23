using Microsoft.AspNetCore.Mvc;

namespace StudentAdminPortal.Controllers
{
    // Controller responsible for handling student-related requests
    public class StudentController : Controller
    {
        // Action method that returns the default view for students
        public IActionResult Index()
        {
            return View();
        }
    }
}
