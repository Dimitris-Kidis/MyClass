using ApplicationCore.Domain.Entities;
using ApplicationCore.Services.Repository.ClassRepository;
using ApplicationCore.Services.Repository.UserRepository;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Query.Schedules.GetScheduleInfo
{

    public class GetScheduleQueryHandler : IRequestHandler<GetScheduleQuery, ScheduleDto>
    {
        private readonly IClassRepository<ClassTeacher> _classesAndTeachersRepository;
        private readonly IClassRepository<Subject> _subjectsRepository;
        private readonly IClassRepository<Class> _classRepository;
        private readonly IClassRepository<Teacher> _teacherRepository;
        private readonly IClassRepository<Schedule> _scheduleRepository;
        private readonly IUserRepository<User> _userRepository;
        private readonly IMapper _mapper;

        public GetScheduleQueryHandler(
            IClassRepository<ClassTeacher> classesAndTeachersRepository,
            IClassRepository<Subject> subjectsRepository,
            IClassRepository<Teacher> teacherRepository,
            IClassRepository<Schedule> scheduleRepository,
            IClassRepository<Class> classRepository,
            IUserRepository<User> userRepository,
            IMapper mapper)
        {
            _classesAndTeachersRepository = classesAndTeachersRepository;
            _classRepository = classRepository;
            _subjectsRepository = subjectsRepository;
            _teacherRepository = teacherRepository;
            _userRepository = userRepository;
            _scheduleRepository = scheduleRepository;
            _mapper = mapper;
        }

        public async Task<ScheduleDto> Handle(GetScheduleQuery request, CancellationToken cancellationToken)
        {
            var users = _userRepository.GetAll();
            var subjects = _subjectsRepository.GetAll();
            var schedules = _scheduleRepository.GetAll();
            var classes = _classRepository.GetAll();

            var schedulesDtos =
                (from schedule in schedules
                 join user in users on schedule.TeacherId equals user.TeacherId
                 join subject in subjects on schedule.SubjectId equals subject.Id
                 join clas in classes on schedule.ClassId equals clas.Id
                 where schedule.Id == request.ScheduleId
                 select new ScheduleDto
                 {
                     Id = schedule.Id,
                     TeacherName = user.FirstName + " " + user.LastName,
                     SubjectName = subject.Name,
                     LessonName = schedule.LessonName,
                     ClassName = clas.ClassName,
                     DateAndTime = schedule.DateAndTime,
                     Cabinet = schedule.Cabinet
                 }).ToList().FirstOrDefault();

            return _mapper.Map<ScheduleDto>(schedulesDtos);
        }
    }
}
