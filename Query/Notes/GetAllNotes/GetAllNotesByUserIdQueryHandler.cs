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

namespace Query.Notes.GetAllNotes
{
    public class GetAllNotesByUserIdQueryHandler : IRequestHandler<GetAllNotesByUserIdQuery, IEnumerable<NotesDto>>
    {
        private readonly IClassRepository<Note> _notesRepository;
        private readonly IUserRepository<User> _userRepository;
        private readonly IMapper _mapper;

        public GetAllNotesByUserIdQueryHandler(
            IClassRepository<Note> notesRepository,
            IUserRepository<User> userRepository,
            IMapper mapper)
        {
            _userRepository = userRepository;
            _notesRepository = notesRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<NotesDto>> Handle(GetAllNotesByUserIdQuery request, CancellationToken cancellationToken)
        {
            var notes = _notesRepository.GetAll().Where(note => note.UserId == request.Id).OrderByDescending(note => note.CreatedAt);

            return notes.Select(_mapper.Map<NotesDto>);
        }
    }
}
