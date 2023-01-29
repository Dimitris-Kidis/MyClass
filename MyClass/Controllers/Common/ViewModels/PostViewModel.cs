namespace MyClass.Controllers.Common.ViewModels
{
    public class PostViewModel
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string Header { get; set; }
        public string Author { get; set; }
        public int Target { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
    }
}
