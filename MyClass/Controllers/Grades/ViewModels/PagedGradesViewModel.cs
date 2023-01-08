namespace MyClass.Controllers.Grades.ViewModels
{
    public class PagedGradesViewModel
    {
        public int Id { get; set; }
        public string StudentName { get; set; }
        public float GradeOne { get; set; }
        public float GradeTwo { get; set; }
        public float GradeThree { get; set; }
        public float GradeFour { get; set; }
        public int Labs { get; set; }
        public int Seminars { get; set; }
        public int Courses { get; set; }
    }
}
