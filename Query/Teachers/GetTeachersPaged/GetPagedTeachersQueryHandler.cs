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

namespace Query.Teachers.GetTeachersPaged
{
    public class GetPagedTeachersQueryHandler : IRequestHandler<GetPagedTeachersQuery, PaginatedResult<GetPagedTeachersDto>>
    {
        private readonly IClassRepository<Teacher> _teachersRepository;
        private readonly IClassRepository<ClassTeacher> _classesAndTeachersRepository;
        private readonly IUserRepository<User> _usersRepository;
        private readonly IMapper _mapper;
        public GetPagedTeachersQueryHandler(
            IClassRepository<Teacher> teachersRepository,
            IClassRepository<ClassTeacher> classesAndTeachersRepository,
            IUserRepository<User> usersRepository,
            IMapper mapper)
        {
            _teachersRepository = teachersRepository;
            _usersRepository = usersRepository;
            _classesAndTeachersRepository = classesAndTeachersRepository;
            _mapper = mapper;
        }
        public async Task<PaginatedResult<GetPagedTeachersDto>> Handle(GetPagedTeachersQuery request, CancellationToken cancellationToken)
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
            var teachers = _teachersRepository.GetAll();
            var classesAndTeachers = _classesAndTeachersRepository.GetAll();
            var q1 = from user in users
                     join teacher in teachers on user.TeacherId equals teacher.Id
                     select new PagedTeachersDto
                     {
                         Id = user.Id,
                         FirstName = user.FirstName,
                         LastName = user.LastName,
                         Email = user.Email,
                         DateOfBirth = user.DateOfBirth,
                         Gender = user.Gender,
                         SignedUpAt = user.CreatedAt,
                         NumberOfClasses = classesAndTeachers.Where(x => x.TeacherId == teacher.Id).Select(x => new { ClassId = x.ClassId }).Distinct().Count(),
                         Position = teacher.Position,
                         Description = teacher.Description,
                         Experience = teacher.Experience,
                         NumberOfSubjects = classesAndTeachers.Where(x => x.TeacherId == teacher.Id).Select(x => new { SubjectId = x.SubjectId }).Distinct().Count()
                     };

            return await q1.CreatePaginatedResultAsync<PagedTeachersDto, GetPagedTeachersDto>(req, _mapper);
        }
    }
}
