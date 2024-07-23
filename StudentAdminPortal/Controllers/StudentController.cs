using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentAdminPortal.Data;
using StudentAdminPortal.Models.Entities;
using StudentAdminPortal.Models;

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
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            // Fetch all students asynchronously from the database
            var allStudents = await dbContext.Students.ToListAsync();

            // Pass the list of students to the view
            return View(allStudents);
        }

        // Action method to render the view for creating a new student
        [HttpGet]
        public IActionResult Create()
        {
            // Return the Create view
            return View();
        }

        // Action method to handle form submission for creating a new student
        [HttpPost]
        public async Task<IActionResult> Create(CreateStudentDto createStudent)
        {
            // Map the DTO to a Student entity
            var studentEntity = new Student()
            {
                Name = createStudent.Name,
                Email = createStudent.Email,
                Phone = createStudent.Phone,
                Subscribed = createStudent.Subscribed,
            };

            // Add the new student to the database context
            await dbContext.Students.AddAsync(studentEntity);

            // Save changes to the database
            await dbContext.SaveChangesAsync();

            // Redirect to the Index action after saving the new student
            return RedirectToAction("Index");
        }

        // Action method to render the view for updating a student by id
        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            // Find the student with the specified id in the database
            var student = await dbContext.Students.FindAsync(id);

            // If student is not found, return a 404 Not Found response
            if (student is null)
            {
                return NotFound();
            }

            // Pass the student object to the Update.cshtml view for editing
            return View(student);
        }

        // Action method to handle form submission for updating a student
        [HttpPost]
        public async Task<IActionResult> Update(Student updateStudent)
        {
            // Retrieve the student to update from the database based on updateStudent.Id
            var student = await dbContext.Students.FindAsync(updateStudent.Id);

            // If the student exists in the database, update its properties with values from updateStudent
            if (student is not null)
            {
                student.Name = updateStudent.Name;
                student.Email = updateStudent.Email;
                student.Phone = updateStudent.Phone;
                student.Subscribed = updateStudent.Subscribed;

                // Save changes to the database
                await dbContext.SaveChangesAsync();
            }

            // Redirect to the Index action after updating
            return RedirectToAction("Index");
        }

        // Action method to Redirect to the Index action after deleting a student by id
        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            // Find the student with the specified id in the database
            var student = await dbContext.Students.FindAsync(id);

            // If student is found, remove the student and update the database
            if (student is not null)
            {
                // Remove the student from the database context
                dbContext.Students.Remove(student);

                // Save changes to the database
                await dbContext.SaveChangesAsync();
            }

            // Redirect to the Index action after deleting
            return RedirectToAction("Index");
        }

        // Action method to handle form submission for delete a student
        [HttpPost]
        public async Task<IActionResult> Delete(Student deleteStudent)
        {
            // Retrieve the student to delete from the database based on deleteStudent.Id
            var student = await dbContext.Students.FindAsync(deleteStudent.Id);

            if (student is not null)
            {
                // Remove the student from the database context
                dbContext.Students.Remove(student);

                // Save changes to the database
                await dbContext.SaveChangesAsync();
            }

            // Redirect to the Index action after deleting
            return RedirectToAction("Index");
        }

    }
}
