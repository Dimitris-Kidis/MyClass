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

namespace Query.Admins.GetAdminsPaged
{
    public class GetAdminsPagedQueryHandler : IRequestHandler<GetAdminsPagedQuery, PaginatedResult<GetPagedAdminsDto>>
    {
        private readonly IUserRepository<User> _usersRepository;
        private readonly IMapper _mapper;
        public GetAdminsPagedQueryHandler(
            IUserRepository<User> usersRepository,
            IMapper mapper)
        {
            _usersRepository = usersRepository;
            _mapper = mapper;
        }
        public async Task<PaginatedResult<GetPagedAdminsDto>> Handle(GetAdminsPagedQuery request, CancellationToken cancellationToken)
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
            var q1 = (from user in users
                      where !user.TeacherId.HasValue && !user.StudentId.HasValue

                      select new PagedAdminsDto
                      {
                          Id = user.Id,
                          FirstName = user.FirstName,
                          LastName = user.LastName,
                          Email = user.Email,
                          DateOfBirth = user.DateOfBirth,
                          Gender = user.Gender,
                          SignedUpAt = user.CreatedAt,
                      }

                      );

            return await q1.CreatePaginatedResultAsync<PagedAdminsDto, GetPagedAdminsDto>(req, _mapper);
        }
    }
}
