using _04Aug2026_Ass.Data;
using _04Aug2026_Ass.Models;
using _04Aug2026_Ass.Repository;

namespace _04Aug2026_Ass.Services
{
    public class CourseService : ICourseService
    {
        private readonly AppDbContext context;

        public CourseService(AppDbContext context)
        {
            this.context = context;
        }

        public void AddCourse(Course course)
        {
            context.Courses.Add(course);
            context.SaveChanges();
        }

        public void DeleteCourse(int id)
        {
            var course = context.Courses.Find(id);

            if (course != null)
            {
                context.Courses.Remove(course);
                context.SaveChanges();
            }
        }

        public List<Course> GetAll()
        {
            return context.Courses.ToList();
        }

        public Course? GetCourse(int id)
        {
            return context.Courses.Find(id);
        }

        public void UpdateCourse(Course course)
        {
            context.Courses.Update(course);
            context.SaveChanges();
        }
    }
}
