using ApplicationCore.Domain.Entities;
using ApplicationCore.Services.Repository.ClassRepository;
using ApplicationCore.Services.Repository.UserRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command.Notes.CreateNewNote
{
    public class CreateNewNoteCommandHandler : IRequestHandler<CreateNewNoteCommand, int>
    {
        private readonly IClassRepository<Note> _notesRepository;
        private readonly IUserRepository<User> _userRepository;
        public CreateNewNoteCommandHandler(IClassRepository<Note> notesRepository, IUserRepository<User> userRepository)
        {
            _notesRepository = notesRepository;
            _userRepository = userRepository;
        }
        public Task<int> Handle(CreateNewNoteCommand command, CancellationToken cancellationToken)
        {
            if (_userRepository.GetAll().All(user => user.Id != command.UserId)) return Task.FromResult(-1);

            Note note = new Note
            {
                UserId = command.UserId,
                NoteText = command.NoteText,
                CreatedAt = DateTimeOffset.Now
            };

            _notesRepository.Add(note);
            _notesRepository.Save();

            var resultId = note.Id;
            return Task.FromResult(resultId);
        }
    }
}
