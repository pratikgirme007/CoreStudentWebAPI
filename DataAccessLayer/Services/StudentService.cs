using CoreStudentWebAPI.DataAccessLayer.DBContextModels;
using CoreStudentWebAPI.DataAccessLayer.Models;

namespace CoreStudentWebAPI.DataAccessLayer.Services
{
    public class StudentService : IStudentService
    {
        private readonly StudentDbContext _studentDbContext;
        public StudentService(StudentDbContext studentDbContext)
        {
            _studentDbContext = studentDbContext;
        }
        public string CreateStudent(Student student)
        {
            _studentDbContext.Students.Add(student);
            _studentDbContext.SaveChanges();
            return "Save Successful";
        }

        public Student GetStudentById(int id)
        {
            return _studentDbContext.Students.Where(x => x.StudentId == id).FirstOrDefault();
        }

        public IList<Student> GetStudents()
        {
            return _studentDbContext.Students.ToList<Student>();
        }
    }
}
