using _3Aug.Models;
using _3Aug.Repository;

namespace _3Aug.Services
{
    public class CourseService : ICourseService
    {
        private static List<Course> courses = new()
        {
            new Course
            {
                Id = 1,
                CourseName = "ASP.NET Core",
                Duration = "6 Months",
                Fee = 25000,
                Description = "Web Development using ASP.NET Core"
            },
            new Course
            {
                Id = 2,
                CourseName = "Java",
                Duration = "4 Months",
                Fee = 20000,
                Description = "Core Java and Advanced Java"
            },
            new Course
            {
                Id = 3,
                CourseName = "Python",
                Duration = "5 Months",
                Fee = 22000,
                Description = "Python Full Stack"
            }
        };

        public List<Course> GetAll()
        {
            return courses;
        }

        public Course GetCourse(int id)
        {
            return courses.FirstOrDefault(c => c.Id == id);
        }

        public void AddCourse(Course course)
        {
            if (courses.Count > 0)
                course.Id = courses.Max(c => c.Id) + 1;
            else
                course.Id = 1;

            courses.Add(course);
        }

        public void UpdateCourse(Course course)
        {
            var existing = courses.FirstOrDefault(c => c.Id == course.Id);

            if (existing != null)
            {
                existing.CourseName = course.CourseName;
                existing.Duration = course.Duration;
                existing.Fee = course.Fee;
                existing.Description = course.Description;
            }
        }

        public void DeleteCourse(int id)
        {
            var course = courses.FirstOrDefault(c => c.Id == id);

            if (course != null)
                courses.Remove(course);
        }
    }
}