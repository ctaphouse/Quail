using MediatR;
using Quail.Shared.Features.ManageStudents.Shared;

namespace Quail.Shared.Features.ManageStudents.AddStudent;

public record AddStudentRequest(StudentDto Student) : IRequest<AddStudentRequest.Response>
{
    public const string RouteTemplate = "api/students";
    public record Response(int StudentId);
}