namespace Quail.Api.Persistence.Entities;

public class CourseStudent
{
    public int CourseId { get; set; }
    public Course Course { get; set; } = default!;
    public int StudentId { get; set; }
    public Student Student { get; set; } =default!;
}