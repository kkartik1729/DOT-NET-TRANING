using CourseRegistrationSystem.Models;

namespace CourseRegistrationSystem.Services
{
    public interface ICourseService
    {
        // View available courses
        IEnumerable<Course> GetAll();
        Course? GetById(int id);

        // Register for a course (adds a new course/registration record)
        Course Register(Course course);

        // Update course duration
        bool UpdateDuration(int id, int newDuration);

        // Cancel a course
        bool Cancel(int id);
    }
}
