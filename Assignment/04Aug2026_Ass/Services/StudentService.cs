using _04Aug2026_Ass.Data;
using _04Aug2026_Ass.Models;
using _04Aug2026_Ass.Repository;

namespace _04Aug2026_Ass.Services
{
    public class StudentService : IStudentService
    {
        private readonly AppDbContext context;

        public StudentService(AppDbContext context)
        {
            this.context = context;
        }

        public void AddStudent(Student student)
        {
            context.Students.Add(student);
            context.SaveChanges();
        }

        public void DeleteStudent(int id)
        {
            var student = context.Students.Find(id);

            if (student != null)
            {
                context.Students.Remove(student);
                context.SaveChanges();
            }
        }

        public List<Student> GetAll()
        {
            return context.Students.ToList();
        }

        public Student? GetStudent(int id)
        {
            return context.Students.Find(id);
        }

        public void UpdateStudent(Student student)
        {
            context.Students.Update(student);
            context.SaveChanges();
        }
    }
}
