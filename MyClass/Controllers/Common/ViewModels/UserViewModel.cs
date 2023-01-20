namespace MyClass.Controllers.Common.ViewModels
{
    public class UserViewModel
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTimeOffset DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string Avatar { get; set; }
        public bool IsAdmin { get; set; }
        public int? TeacherId { get; set; }
        public int? StudentId { get; set; }
    }
}
