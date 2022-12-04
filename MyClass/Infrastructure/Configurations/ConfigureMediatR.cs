//using Command.Texts.CreateNewText;
//using Command.Users.CreateNewUser;
//using Command.Users.DeleteUserById;
//using FluentValidation;
using Command.Notes.CreateNewNote;
using MediatR;
using Query.Teachers.GetAllStudentTeachersByStudentId;
//using Query.Users.GetAllUsers;

namespace MyClass.Infrastructure.Configurations
{
    public static class ConfigureMediatR
    {
        public static IServiceCollection AddMediatRConfigs(this IServiceCollection services)
        {
            services.AddMediatR(typeof(GetAllStudentTeachersByStudentIdQueryHandler).Assembly);
            services.AddMediatR(typeof(CreateNewNoteCommandHandler).Assembly);
            return services;
        }

    }
}
