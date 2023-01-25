using ApplicationCore.Domain.Entities;
using ApplicationCore.Services.Repository.ClassRepository;
using ApplicationCore.Services.Repository.UserRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command.Schedules.DeleteSchedule
{
    public class DeleteScheduleCommandHandler : IRequestHandler<DeleteScheduleCommand, int>
    {
        private readonly IClassRepository<Schedule> _schedulesRepository;
        public DeleteScheduleCommandHandler(
            IClassRepository<Schedule> schedulesRepository
            )
        {
            _schedulesRepository = schedulesRepository;
        }
        public Task<int> Handle(DeleteScheduleCommand request, CancellationToken cancellationToken)
        {
            if (!_schedulesRepository.GetAll().Any(user => user.Id == request.ScheduleId)) return Task.FromResult(-1);
            var schedule = _schedulesRepository.GetByIdAsync(request.ScheduleId);


            if (schedule != null)
            {
                _schedulesRepository.Delete(schedule.Result);
                _schedulesRepository.Save();
            }

            return Task.FromResult(0);
        }
    }
}
