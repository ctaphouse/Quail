namespace Quail.Api.Persistence.Entities;

public class Student
{
    public int Id { get; set; }
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public int DepartmentId { get; set; }
    public Department Department { get; set; } = default!;
    public ICollection<Course> Courses { get; set; } = new List<Course>();
}