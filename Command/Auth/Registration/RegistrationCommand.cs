using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command.Auth.Registration
{
    public class RegistrationCommand : IRequest<int>
    {
        public bool IsAdmin { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public DateTimeOffset DateOfBirth { get; set; }
        public string Gender { get; set; }
        public int Type { get; set; }
        public int? ClassId { get; set; }
        public int? SubjectId { get; set; }
        public string? Position { get; set; }
        public string? Description { get; set; }
        public string? Experience { get; set; }
    }
}
