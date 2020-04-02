using System;
using APBDcw4.Services;
using APBDcw4.Models;
using Microsoft.AspNetCore.Mvc;

namespace APBDcw4.Controllers
{
    [ApiController]
    [Route("api/students")]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService _studentService;

        
        public StudentsController(IStudentService studentService)
        {
            _studentService = studentService;
        }


        [HttpGet]
        public IActionResult GetStudents(string orderBy)
        {
            return Ok(_studentService.GetStudents());
        }
        
        [HttpGet("{index}")]
        public IActionResult GetStudent(string index)
        {
            return Ok(_studentService.GetStudentEnrollment(index));
        }
    }
}