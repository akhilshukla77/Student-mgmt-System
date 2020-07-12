using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StudentMgmtServices.Interfaces;

namespace StudentMgmtServices.Controllers
{
    public class StudentsController : Controller
    {
        private readonly IStudents _students;
        public StudentsController(IStudents students)
        {
            _students = students;
        }

        [HttpGet]
        [Route("/api/Students/GetAllStudents")]
        public IActionResult GetAllStudents()
        {
            return Ok(_students.GetAllStudents());
        }

        [HttpGet]
       //[Route("{id}")]
        [Route("/api/Students/GetAllStudents/{id}")]
        public IActionResult GetStudentById(int id)
        {
            var student = _students.GetAllStudents().Where(x => x.DistrictId == id);
            if (student == null)
                return NotFound();
            return Ok(student);
        }

        [HttpGet]
        [Route("/api/Students/GetAllStudentServices")]
        public IActionResult GetAllStudentServices()
        {
            return Ok(_students.GetAllStudentServices());
        }

        
        [HttpGet]        
        [Route("/api/Students/GetAllStudentServices/{id}")]
        public IActionResult GetStudentServiceById(int id)
        {
            var student = _students.GetAllStudentServices().Where(x => x.SchoolYear == id).ToList();
            if (student == null)
                return NotFound();
            return Ok(student);
        }

        [HttpGet]
        [Route("/api/Students/GetAllStudentEnrolledList")]
        public IActionResult GetAllStudentEnrolledList()
        {
            return Ok(_students.GetAllStudentEnrolledList());
        }

        [HttpGet]
        [Route("/api/Students/GetAllStudentEnrolledList/{id}")]
        public IActionResult GetStudentEnrolledByYear(int id)
        {
            var student = _students.GetAllStudentEnrolledList().Where(x => x.SchoolYear == id).ToList();
            if (student == null)
                return NotFound();
            return Ok(student);
        }

    }
}