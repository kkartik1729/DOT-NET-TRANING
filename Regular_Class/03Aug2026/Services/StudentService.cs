using _3Aug.Models;
using _3Aug.Repository;

namespace _3Aug.Services
{
    public class StudentService : IStudentService
    {
        private static List<Student> students = new()
        {
            new Student
            {
                Id = 1,
                Name = "John",
                Age = 20,
                Course = "DotNet",
                Email = "john@gmail.com"
            },
            new Student
            {
                Id = 2,
                Name = "Bob",
                Age = 19,
                Course = "DotNet",
                Email = "bob@gmail.com"
            },
            new Student
            {
                Id = 3,
                Name = "David",
                Age = 24,
                Course = "Java",
                Email = "david@gmail.com"
            }
        };

        public List<Student> GetAll()
        {
            return students;
        }

        public Student GetStudent(int id)
        {
            return students.FirstOrDefault(s => s.Id == id);
        }

        public void AddStudent(Student student)
        {
            if (students.Count > 0)
            {
                student.Id = students.Max(s => s.Id) + 1;
            }
            else
            {
                student.Id = 1;
            }

            students.Add(student);
        }

        public void UpdateStudent(Student student)
        {
            Student existingStudent = students.FirstOrDefault(s => s.Id == student.Id);

            if (existingStudent != null)
            {
                existingStudent.Name = student.Name;
                existingStudent.Age = student.Age;
                existingStudent.Course = student.Course;
                existingStudent.Email = student.Email;
            }
        }

        public void DeleteStudent(int id)
        {
            Student student = students.FirstOrDefault(s => s.Id == id);

            if (student != null)
            {
                students.Remove(student);
            }
        }
    }
}