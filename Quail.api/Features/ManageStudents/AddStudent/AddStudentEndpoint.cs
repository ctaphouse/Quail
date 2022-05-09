using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Quail.Api.Persistence;
using Quail.Api.Persistence.Entities;
using Quail.Shared.Features.ManageStudents.AddStudent;

namespace Quail.Api.Features.ManageStudents.AddStudent;

public class AddStudentEndpoint :EndpointBaseAsync.WithRequest<AddStudentRequest>.WithActionResult<int>
{
    private readonly QuailContext _context;

    public AddStudentEndpoint(QuailContext context)
    {
        _context = context;
    }

    [HttpPost(AddStudentRequest.RouteTemplate)]
    public override async Task<ActionResult<int>> HandleAsync(AddStudentRequest request, CancellationToken cancellationToken = default)
    {
        var student = new Student
        {
            FirstName = request.Student.FirstName,
            LastName = request.Student.LastName,
            DepartmentId = request.Student.DepartmentId
        };

        await _context.Students.AddAsync(student);

        var courses = request.Student.CourseStudents.Select(j => new CourseStudent
        {
            CourseId = j.CourseId,
            Student = student
        }
        );

        await _context.CourseStudent.AddRangeAsync(courses);

        await _context.SaveChangesAsync(cancellationToken);

        return student.Id;

    }
}