using CourseRegistrationSystem.Models;

namespace CourseRegistrationSystem.Services
{
    public interface ICourseService
    {
        IEnumerable<Course> GetAll();
        Course? GetById(int id);

        Course Register(Course course);

        bool UpdateDuration(int id, int newDuration);
        
        bool Cancel(int id);
    }
}
