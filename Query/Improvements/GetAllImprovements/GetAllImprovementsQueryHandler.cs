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

namespace Query.Improvements.GetAllImprovements
{
    public class GetAllImprovementsQueryHandler : IRequestHandler<GetAllImprovementsQuery, IEnumerable<ImprovementDto>>
    {
        private readonly IClassRepository<Improvement> _imprRepository;
        private readonly IUserRepository<User> _userRepository;
        private readonly IMapper _mapper;

        public GetAllImprovementsQueryHandler(
            IClassRepository<Improvement> imprRepository,
            IUserRepository<User> userRepository,
            IMapper mapper)
        {
            _userRepository = userRepository;
            _imprRepository = imprRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ImprovementDto>> Handle(GetAllImprovementsQuery request, CancellationToken cancellationToken)
        {
            var allImprovements = _imprRepository.GetAll();
            var idsOfUsersWithImprovement = allImprovements.Select(x => x.UserId).ToListAsync(cancellationToken).Result;
            var allUsers = _userRepository
                .FindBy(user => idsOfUsersWithImprovement
                .Contains(user.Id));


            var result = (from al in allImprovements
                          join au in allUsers on al.UserId equals au.Id
                          select new ImprovementDto
                          {
                              Id = al.Id,
                              UserName = au.FirstName + " " + au.LastName,
                              Time = al.CreatedAt,
                              Role = au.StudentId != null ? "Student" : (au.TeacherId != null ? "Teacher" : "Admin"),
                              ImprovementText = al.HelpNote
                          }).ToList();

            return result.Select(_mapper.Map<ImprovementDto>);
        }
    }
}
