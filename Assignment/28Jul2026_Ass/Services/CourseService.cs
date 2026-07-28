using CourseRegistrationSystem.Models;

namespace CourseRegistrationSystem.Services
{
    public class CourseService : ICourseService
    {
        // In-memory sample data. Static so it persists across requests
        // within the same running instance of the app.
        private static readonly List<Course> _courses = new()
        {
            new Course { Id = 1, Title = "Introduction to Programming", Credits = 4, duration = 12 },
            new Course { Id = 2, Title = "Data Structures",             Credits = 4, duration = 14 },
            new Course { Id = 3, Title = "Database Management Systems", Credits = 3, duration = 10 },
            new Course { Id = 4, Title = "Web Development",             Credits = 3, duration = 8  }
        };

        private static int _nextId = 5;

        public IEnumerable<Course> GetAll()
        {
            return _courses;
        }

        public Course? GetById(int id)
        {
            return _courses.FirstOrDefault(c => c.Id == id);
        }

        public Course Register(Course course)
        {
            course.Id = _nextId++;
            _courses.Add(course);
            return course;
        }

        public bool UpdateDuration(int id, int newDuration)
        {
            var course = _courses.FirstOrDefault(c => c.Id == id);
            if (course == null) return false;

            course.duration = newDuration;
            return true;
        }

        public bool Cancel(int id)
        {
            var course = _courses.FirstOrDefault(c => c.Id == id);
            if (course == null) return false;

            _courses.Remove(course);
            return true;
        }
    }
}
