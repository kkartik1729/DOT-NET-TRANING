using _04Aug2026_Ass.Models;

namespace _04Aug2026_Ass.Repository
{
    public interface IStudentService
    {
        List<Student> GetAll();

        Student? GetStudent(int id);

        void AddStudent(Student student);

        void UpdateStudent(Student student);

        void DeleteStudent(int id);
    }
}
