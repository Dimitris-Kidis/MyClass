using ApplicationCore.Domain.Entities;
using ApplicationCore.Services.Repository.ClassRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command.Schedules.CreateSchedule
{
    public class CreateScheduleCommandHandler : IRequestHandler<CreateScheduleCommand, int>
    {
        private readonly IClassRepository<Schedule> _scheduleRepository;
        public CreateScheduleCommandHandler(IClassRepository<Schedule> scheduleRepository)
        {
            _scheduleRepository = scheduleRepository;
        }
        public Task<int> Handle(CreateScheduleCommand request, CancellationToken cancellationToken)
        {
            var newSchedule = new Schedule
            {
                SubjectId = request.SubjectId,
                ClassId = request.ClassId,
                TeacherId = request.TeacherId,
                LessonName = request.LessonName,
                DateAndTime = request.DateAndTime,
                Cabinet = request.Cabinet
            };

            _scheduleRepository.Add(newSchedule);
            _scheduleRepository.Save();

            var resultId = newSchedule.Id;
            return Task.FromResult(resultId);
        }
    }
}
