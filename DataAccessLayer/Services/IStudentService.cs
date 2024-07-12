using CoreStudentWebAPI.DataAccessLayer.Models;

namespace CoreStudentWebAPI.DataAccessLayer.Services
{
    public interface IStudentService
    {
        IList<Student> GetStudents();
        Student GetStudentById(int id);
        string CreateStudent(Student student);
    }
}
