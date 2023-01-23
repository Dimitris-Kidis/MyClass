using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApplicationCore.Domain.Entities
{
    public class User : IdentityUser<int>
    {
        [Timestamp]
        public byte[] RowVersion { get; set; }
        public bool IsAdmin { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public DateTimeOffset DateOfBirth { get; set; }
        //public int Age { get; set; }
        public int Age => (DateTime.Today - DateOfBirth).Days / 365;
        public string Gender { get; set; }
        public ICollection<Image> Images { get; set; }
        public int? TeacherId { get; set; }
        public Teacher Teacher { get; set; }
        public int? StudentId { get; set; }
        public Student Student { get; set; }
        public ICollection<Note> Notes { get; set; }
        public string CreatedBy { get; set; }
        public string? LastModifiedBy { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset? LastModifiedAt { get; set; }

    }
}
