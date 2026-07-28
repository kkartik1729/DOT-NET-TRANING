namespace CourseRegistrationSystem.Models
{
    // Used by the "update course duration" endpoint, which only
    // needs to change the duration field of an existing course.
    public class UpdateDurationDto
    {
        public int duration { get; set; }
    }
}
