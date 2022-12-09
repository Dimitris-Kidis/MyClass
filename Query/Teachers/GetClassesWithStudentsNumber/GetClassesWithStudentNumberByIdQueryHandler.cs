using ApplicationCore.Domain.Entities;
using ApplicationCore.Services.Repository.ClassRepository;
using ApplicationCore.Services.Repository.UserRepository;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Query.Teachers.GetClassesWithStudentsNumber
{
    public class GetClassesWithStudentNumberByIdQueryHandler : IRequestHandler<GetClassesWithStudentNumberByIdQuery, IEnumerable<ClassesWithStudentsNumberDto>>
    {
        private readonly IClassRepository<Schedule> _schedulesRepository;
        private readonly IClassRepository<Student> _studentsRepository;
        private readonly IClassRepository<Class> _classesRepository;
        private readonly IUserRepository<User> _usersRepository;
        private readonly IMapper _mapper;

        public GetClassesWithStudentNumberByIdQueryHandler(
            IClassRepository<Schedule> schedulesRepository,
            IClassRepository<Student> studentsRepository,
            IClassRepository<Class> classesRepository,
            IUserRepository<User> usersRepository,
            IMapper mapper)
        {
            _schedulesRepository = schedulesRepository;
            _studentsRepository = studentsRepository;
            _classesRepository = classesRepository;
            _usersRepository = usersRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ClassesWithStudentsNumberDto>> Handle(GetClassesWithStudentNumberByIdQuery request, CancellationToken cancellationToken)
        {
            var teacherId = _usersRepository
                .FindBy(user => user.Id == request.UserId)
                .FirstOrDefault()
                .TeacherId;

            //var uniqueClasses = _schedulesRepository
            //    .FindBy(schedule => schedule.TeacherId == teacherId)
            //    .DistinctBy(field => field.ClassId)
            //    .Select(schedule => schedule.ClassId)
            //    .ToList();

            var allStudents = _studentsRepository.GetAll();
            var allSchedules = _schedulesRepository.GetAll();
            var allClasses = _classesRepository.GetAll();

            Dictionary<int, int> numberOfStudentsWithClassId =
            new Dictionary<int, int>();
            foreach (var line in allStudents
                //.Where(schedule => schedule.TeacherId == teacherId)
                .GroupBy(info => info.ClassId)
                .Select(group => new {
                    ClassId = group.Key,
                    Count = group.Count()
                }))
            {
                Console.WriteLine("{0} {1}", line.ClassId, line.Count);
                numberOfStudentsWithClassId.Add(line.ClassId, line.Count);
            }

            Dictionary<int, int> schedulesWithClassId =
            new Dictionary<int, int>();
            foreach (var line in allSchedules
                .Where(schedule => schedule.TeacherId == teacherId)
                .GroupBy(info => info.ClassId)
                .Select(group => new {
                    ClassId = group.Key,
                    Count = group.Count()
                }))
            {
                Console.WriteLine("{0} {1}", line.ClassId, line.Count);
                schedulesWithClassId.Add(line.ClassId, line.Count);
            }


            

            var classesNamesWithNumberOfStudentsAndNumberOfSchedules =
                (from first in numberOfStudentsWithClassId
                 join second in schedulesWithClassId on first.Key equals second.Key
                 join clas in allClasses on first.Key equals clas.Id
                 select new ClassesWithStudentsNumberDto
                 {
                     ClassName = clas.ClassName,
                     NumberOfShedules = second.Value,
                     NumberOfStudents = first.Value
                 }).ToList();


            return classesNamesWithNumberOfStudentsAndNumberOfSchedules.Select(_mapper.Map<ClassesWithStudentsNumberDto>);
        }
    }
}
