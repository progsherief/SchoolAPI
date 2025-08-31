using Microsoft.AspNetCore.Mvc;
using SchoolAPI.Interfaces;
using SchoolAPI.Models;

namespace SchoolAPI.Controllers
{
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService _studentService;

        private readonly ICourseService _courseService;

        public StudentsController(IStudentService studentService, ICourseService courseService)
        {
            _studentService = studentService;

            _courseService = courseService;
        }

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<Student>> GetById(string id)
        {
            var student = await _studentService.GetById(id);

            if (student is null)
            {
                return NotFound();
            }

            if (student.Courses is null || !student.Courses.Any())
            {
                return Ok(student);
            }

            student.CourseList ??= new();

            foreach (var courseId in student.Courses)
            {
                var course = await _courseService.GetById(courseId) ?? throw new Exception("Invalid Course Id");

                student.CourseList.Add(course);
            }

            return Ok(student);
        }

        //Other methods
    }
}
