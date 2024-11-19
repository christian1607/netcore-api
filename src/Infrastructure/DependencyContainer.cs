using Application.Meta;
using Domain.Courses;
using Domain.Lessons;
using Domain.Questions;
using Domain.Students;
using Infrastructure.Db;
using Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class DependencyContainer
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(opt =>
        {
            opt.UseSqlServer(configuration.GetSection("Database").GetSection("ConnectionString").Value);
        });
            

        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IStudentRepository,StudentRepository>();
        services.AddScoped<IQuestionRepository,QuestionRepository>();
        services.AddScoped<ILessonRepository,LessonRepository>();
        services.AddScoped<ICourseRepository,CourseRepository>();
        
        return services;
    }
    

}
