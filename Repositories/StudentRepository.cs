using CoreStudentWebAPI.DataAccessLayer.Models;
using CoreStudentWebAPI.DataAccessLayer.Services;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace CoreStudentWebAPI.Repositories
{
    public class StudentRepository
    {
        private readonly IStudentService _studentService;
        public StudentRepository(IStudentService studentService)
        {
            _studentService = studentService;
        }

        public IList<Student> GetList()
        {
            return _studentService.GetStudents();
        }

        public Student GetById(int id)
        {
            return _studentService.GetStudentById(id);
        }

        public string Post(Student student)
        {
            return _studentService.CreateStudent(student);
        }
    }
}
