using ApplicationCore.Domain.Entities;
using ApplicationCore.Services.Repository.ClassRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command.Notes.DeleteNoteById
{
    public class DeleteNoteByIdCommandHandler : IRequestHandler<DeleteNoteByIdCommand, int>
    {
        private readonly IClassRepository<Note> _notesRepository;
        public DeleteNoteByIdCommandHandler(IClassRepository<Note> notesRepository)
        {
            _notesRepository = notesRepository;
        }
        public Task<int> Handle(DeleteNoteByIdCommand request, CancellationToken cancellationToken)
        {
            if (!_notesRepository.GetAll().Any(note => note.Id == request.Id)) return Task.FromResult(-1);
            var user = _notesRepository.GetByIdAsync(request.Id);
            if (user != null)
            {
                _notesRepository.Delete(user.Result);
                _notesRepository.Save();
            }
            return Task.FromResult(0);
        }
    }
}
