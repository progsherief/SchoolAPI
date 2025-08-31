using MongoDB.Driver;
using SchoolAPI.Models;

namespace SchoolAPI.Interfaces
{
    public interface ICourseService
    {
        Task<Course?> Create(Course course);

        Task<Course?> GetById(string id);
    }

    public interface IStudentService
    {
        Task<Student?> Create(Student student);

        Task<DeleteResult> Delete(string id);

        Task<List<Student>> GetAll();

        Task<Student?> GetById(string id);

        Task<ReplaceOneResult> Update(string id, Student student);
    }
}
