using ApplicationCore.Services.Repository.UserRepository;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Query.Admins.GetAdminAboutInfo
{
    public class GetAdminAboutInfoQueryHandler : IRequestHandler<GetAdminAboutInfoQuery, AdminAboutInfoDto>
    {
        private readonly IUserRepository<ApplicationCore.Domain.Entities.User> _userTeacherRepository;
        private readonly IMapper _mapper;

        public GetAdminAboutInfoQueryHandler(
            IUserRepository<ApplicationCore.Domain.Entities.User> userTeacherRepository,
            IMapper mapper)
        {
            _userTeacherRepository = userTeacherRepository;
            _mapper = mapper;
        }

        public async Task<AdminAboutInfoDto> Handle(GetAdminAboutInfoQuery request, CancellationToken cancellationToken)
        {
            var user = _userTeacherRepository.FindBy(user => user.Id == request.UserId).FirstOrDefault();


            var fullName = user.FirstName + " " + user.LastName;
            var dateOfBirth = user.DateOfBirth.ToString("d", new CultureInfo("es-ES"));
            var createdAt = user.CreatedAt.ToString("d", new CultureInfo("es-ES"));
            var createdBy = user.CreatedBy;

            var aboutInfo = new AdminAboutInfoDto
            {
                FullName = fullName,
                DateOfBirth = dateOfBirth,
                CreatedAt = createdAt,
                CreatedBy = createdBy
            };

            return _mapper.Map<AdminAboutInfoDto>(aboutInfo);
        }
    }
}
