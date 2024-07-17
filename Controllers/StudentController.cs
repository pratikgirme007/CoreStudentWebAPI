using CoreStudentWebAPI.DataAccessLayer.Models;
using CoreStudentWebAPI.DataAccessLayer.Services;
using CoreStudentWebAPI.Filters;
using CoreStudentWebAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.IdentityModel.Protocols;
using System.Diagnostics;

namespace CoreStudentWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly StudentRepository _studentRepository;
        public StudentController(IStudentService studentService)
        {
            _studentRepository = new StudentRepository(studentService);
        }

        [HttpGet]
        [Route("GetStudents")]
        //[ServiceFilter(typeof(LogFilterAttribute))]
        public ActionResult<List<Student>> Get()
        {
            try
            {
                var students = _studentRepository.GetList();
                return Ok(students);
            }
            catch(Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }

        [HttpGet]
        [Route("GetStudentById/{id}")]
        public Student GetById(int id)
        {
            Student student = new Student();
            try
            {
                student = _studentRepository.GetById(id);
                //if (student == null || student.StudentId == 0)
            }
            catch (Exception exception)
            {
                //
            }
            return student;
        }

        [HttpPost]
        [Route("SaveStudentComplex")]
        public ActionResult<List<Student>> SaveStudentComplex(Student student)
        {
            try
            {
                var result = _studentRepository.Post(student);
                return Ok(result);
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }

        [HttpPost]
        [Route("SaveStudentPremitive")]
        public ActionResult<List<Student>> SaveStudentPremitive(string firstName, string middleName, string lastName, DateTime dateOdBirth, string gender)
        {
            Student student = new Student()
            {
                FirstName = firstName,
                MiddleName = middleName,
                LastName = lastName,
                DateOfBirth = dateOdBirth,
                Gender = gender
            };
            try
            {
                var result = _studentRepository.Post(student);
                return Ok(result);
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }
       
    }
}
