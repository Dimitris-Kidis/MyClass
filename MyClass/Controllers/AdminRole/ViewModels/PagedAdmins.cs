namespace MyClass.Controllers.AdminRole.ViewModels
{
    public class PagedAdmins
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTimeOffset DateOfBirth { get; set; }
        public string Gender { get; set; }
        public DateTimeOffset SignedUpAt { get; set; }
    }
}
