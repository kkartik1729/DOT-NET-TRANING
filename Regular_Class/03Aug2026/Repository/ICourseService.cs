using _3Aug.Models;

namespace _3Aug.Repository
{
    public interface ICourseService
    {
        List<Course> GetAll();

        Course GetCourse(int id);

        void AddCourse(Course course);

        void UpdateCourse(Course course);

        void DeleteCourse(int id);
    }
}