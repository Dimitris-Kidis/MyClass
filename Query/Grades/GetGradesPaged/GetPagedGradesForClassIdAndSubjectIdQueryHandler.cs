using ApplicationCore.Domain.Entities;
using ApplicationCore.Services.Repository.ClassRepository;
using ApplicationCore.Services.Repository.UserRepository;
using AutoMapper;
using MediatR;
using Query.Pagination;
using Query.Pagination.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Query.Grades.GetGradesPaged
{
    public class GetPagedGradesForClassIdAndSubjectIdQueryHandler : IRequestHandler<GetPagedGradesForClassIdAndSubjectIdQuery, PaginatedResult<PagedGradesForClassAndSubjectDto>>
    {
        private readonly IUserRepository<User> _usersRepository;
        private readonly IClassRepository<Student> _studentsRepository;
        private readonly IClassRepository<Grade> _gradesRepository;
        private readonly IMapper _mapper;
        public GetPagedGradesForClassIdAndSubjectIdQueryHandler(
            IClassRepository<Student> studentsRepository,
            IClassRepository<Grade> gradesRepository,
            IUserRepository<User> usersRepository,
            IMapper mapper)
        {
            _studentsRepository = studentsRepository;
            _usersRepository = usersRepository;
            _gradesRepository = gradesRepository;
            _mapper = mapper;
        }
        public async Task<PaginatedResult<PagedGradesForClassAndSubjectDto>> Handle(GetPagedGradesForClassIdAndSubjectIdQuery request, CancellationToken cancellationToken)
        {
            PagedRequest req = new()
            {
                PageIndex = request.PageIndex,
                PageSize = request.PageSize,
                ColumnNameForSorting = request.ColumnNameForSorting,
                SortDirection = request.SortDirection,
                RequestFilters = request.RequestFilters
            };

            var users = _usersRepository.GetAll();
            var students = _studentsRepository.GetAll();
            var grades = _gradesRepository.GetAll();

            var q1 = (from user in users
                      join student in students on user.StudentId equals student.Id
                      join grade in grades on student.Id equals grade.StudentId
                      where student.ClassId == request.ClassId && grade.SubjectId == request.SubjectId
                      select new GetPagedGradesForClassIdAndSubjectIdDto
                      {
                          Id = grade.Id,
                          StudentName = user.FirstName + " " + user.LastName,
                          GradeOne = grade.GradeOne,
                          GradeTwo = grade.GradeTwo,
                          GradeThree = grade.GradeThree,
                          GradeFour = grade.GradeFour,
                          Labs = grade.Labs,
                          Seminars = grade.Seminars,
                          Courses = grade.Courses
                      }

                      );

            return await q1.CreatePaginatedResultAsync<GetPagedGradesForClassIdAndSubjectIdDto, PagedGradesForClassAndSubjectDto>(req, _mapper);
        }
    }
}
