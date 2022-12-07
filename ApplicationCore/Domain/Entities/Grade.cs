namespace ApplicationCore.Domain.Entities
{
    public class Grade : BaseEntity
    {
        public int StudentId { get; set; }
        public Student Student { get; set; }
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }
        public int SubjectId { get; set; }
        public Subject Subject { get; set; }
        public float GradeOne { get; set; }
        public float GradeTwo { get; set; }
        public float GradeThree { get; set; }
        public float GradeFour { get; set; }
        public int Courses { get; set; }
        public int Labs { get; set; }
        public int Seminars { get; set; }

    }
}
