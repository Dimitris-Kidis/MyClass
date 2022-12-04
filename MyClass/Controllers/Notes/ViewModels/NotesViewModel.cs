namespace MyClass.Controllers.Notes.ViewModels
{
    public class NotesViewModel
    {
        public int Id { get; set; }
        public string NoteText { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
    }
}
