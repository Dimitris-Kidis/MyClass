namespace Query.Teachers.GetAllStudentTeachersByStudentId
{
    public class TeacherListDto
    {
        public int UserId { get; set; }
        public int TeacherId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Position { get; set; }
        public string Description { get; set; }
        public string Subject { get; set; }
        public string Avatar { get; set; }
        public string Experience { get; set; }



    }
}
