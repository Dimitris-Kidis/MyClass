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

namespace Query.Students.GetStudentsPaged
{
    public class GetPagedStudentsQueryHandler : IRequestHandler<GetPagedStudentsQuery, PaginatedResult<GetPagedStudentsDto>>
    {
        private readonly IClassRepository<Student> _studsRepository;
        private readonly IClassRepository<ClassTeacher> _classesAndTeachersRepository;
        private readonly IClassRepository<Class> _classesRepository;
        private readonly IUserRepository<User> _usersRepository;
        private readonly IMapper _mapper;
        public GetPagedStudentsQueryHandler(
            IClassRepository<Student> studsRepository,
            IClassRepository<ClassTeacher> classesAndTeachersRepository,
            IUserRepository<User> usersRepository,
            IClassRepository<Class> classesRepository,
            IMapper mapper)
        {
            _classesRepository = classesRepository;
            _studsRepository = studsRepository;
            _usersRepository = usersRepository;
            _classesAndTeachersRepository = classesAndTeachersRepository;
            _mapper = mapper;
        }
        public async Task<PaginatedResult<GetPagedStudentsDto>> Handle(GetPagedStudentsQuery request, CancellationToken cancellationToken)
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
            var students = _studsRepository.GetAll();
            var classes = _classesRepository.GetAll();
            var classesAndTeachers = _classesAndTeachersRepository.GetAll();
            var q1 = (from user in users
                      join student in students on user.StudentId equals student.Id
                      join clas in classes on student.ClassId equals clas.Id
                      select new PagedStudentsDto
                      {
                          Id = user.Id,
                          FirstName = user.FirstName,
                          LastName = user.LastName,
                          Email = user.Email,
                          DateOfBirth = user.DateOfBirth,
                          Gender = user.Gender,
                          SignedUpAt = user.CreatedAt,
                          ClassName = clas.ClassName,
                          NumberOfSubjects = classesAndTeachers.Where(x => x.ClassId == student.ClassId).Count()
                      }

                      );

            return await q1.CreatePaginatedResultAsync<PagedStudentsDto, GetPagedStudentsDto>(req, _mapper);
        }
    }
}
