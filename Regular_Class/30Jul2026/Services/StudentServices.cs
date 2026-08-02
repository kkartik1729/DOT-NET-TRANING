using _30Jul2026.Models;

namespace _30Jul2026.Services
{
    public class StudentService : IStudentService
    {
        private static List<Student> students = new List<Student>
        {
            new Student { Id = 1, FirstName = "abc", LastName = "aaa", Phonee = 789654, BatchId = 1101 },
            new Student { Id = 2, FirstName = "bob", LastName = "alice", Phonee= 809654, BatchId = 1102 },
            new Student { Id = 3, FirstName = "john", LastName = "rahul", Phonee = 9114654, BatchId = 1101 },
            new Student { Id = 4, FirstName = "neha", LastName = "priya", Phonee= 7789654, BatchId = 1102 }
        };

        public List<Student> GetStudents()
        {
            return students;
        }

        public Student? GetStudentByID(int id)
        {
            return students.FirstOrDefault(s => s.Id == id);
        }

        public void AddStudent(Student student)
        {
            students.Add(student);
        }
    }
}