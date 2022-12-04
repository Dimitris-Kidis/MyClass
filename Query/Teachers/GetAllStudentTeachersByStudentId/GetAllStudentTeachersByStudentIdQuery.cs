using MediatR;

namespace Query.Teachers.GetAllStudentTeachersByStudentId
{
    public class GetAllStudentTeachersByStudentIdQuery : IRequest<IEnumerable<TeacherListDto>>
    {
        public int Id { get; set; }
    }
}
