using CoreStudentWebAPI.DataAccessLayer.Models;
using CoreStudentWebAPI.DataAccessLayer.Services;
using CoreStudentWebAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
        public ActionResult<List<Student>> GetStudents()
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
        public ActionResult<List<Student>> GetStudentById(int id)
        {
            try
            {
                var student = _studentRepository.GetById(id);
                if(student == null || student.StudentId == 0)
                    return NoContent();
                return Ok(student);
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }

        [HttpPost]
        [Route("SaveStudent")]
        public ActionResult<List<Student>> SaveStudent(Student student)
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
    }
}
