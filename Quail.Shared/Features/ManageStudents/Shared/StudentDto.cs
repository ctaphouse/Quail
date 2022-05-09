namespace Quail.Shared.Features.ManageStudents.Shared;

public class StudentDto
{
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public int DepartmentId { get; set; }
    public ICollection<CourseStudent> CourseStudents { get; set; } = new List<CourseStudent>();

    public class CourseStudent
    {
        public int CourseId { get; set; }
    }
}