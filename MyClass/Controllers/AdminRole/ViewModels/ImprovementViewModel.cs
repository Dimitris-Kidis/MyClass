namespace MyClass.Controllers.AdminRole.ViewModels
{
    public class ImprovementViewModel
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Role { get; set; }
        public DateTimeOffset Time { get; set; }
        public string ImprovementText { get; set; }
    }
}
