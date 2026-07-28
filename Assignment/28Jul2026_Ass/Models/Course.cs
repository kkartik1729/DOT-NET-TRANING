namespace CourseRegistrationSystem.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public int Credits { get; set; }
        public int duration { get; set; }
    }
}
