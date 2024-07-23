﻿using Microsoft.AspNetCore.Mvc;
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
    }
}
