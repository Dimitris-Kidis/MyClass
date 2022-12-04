using AutoMapper;

namespace MyClass.Infrastructure.Configurations
{
    public static class ConfigureMapper
    {
        public static IServiceCollection AddMapper(this IServiceCollection services)
        {

            services.AddAutoMapper(typeof(Program).Assembly, typeof(Query.Teachers.GetAllStudentTeachersByStudentId.GetAllStudentTeachersByStudentIdQuery).Assembly);
            services.AddAutoMapper(typeof(Program).Assembly, typeof(Command.Notes.CreateNewNote.CreateNewNoteCommand).Assembly);
            //services.AddAutoMapper(typeof(Program).Assembly, typeof(Controllers.Notes.MapperProfiles).Assembly);
            return services;
        }
    }
}
