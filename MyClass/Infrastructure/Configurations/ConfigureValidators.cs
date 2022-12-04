//using FluentValidation.AspNetCore;

using FluentValidation.AspNetCore;

namespace MyClass.Infrastructure.Configurations
{
    public static class ConfigureValidators
    {
        public static IMvcBuilder AddValidators(this IMvcBuilder services) =>
            services.AddFluentValidation(opt => opt.RegisterValidatorsFromAssembly(typeof(Command.Notes.CreateNewNote.CreateNewNoteCommand).Assembly));
    }
}
