namespace MyClass.Controllers.Teachers.ViewModels
{
    public class AllTeachersForStudentViewModel
    {
        public int UserId { get; set; }
        public int TeacherId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Position { get; set; }
        public string Description { get; set; }
        public string Subject { get; set; }
        public string Avatar { get; set; }
    }
}
