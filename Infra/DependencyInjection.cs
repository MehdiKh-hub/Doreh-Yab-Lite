using Application.Interfaces;
using Application.Interfaces.Ripository;
using Application.Services;
using Domain.Interfaces.Repositories;
using Infra.Persistence.Ripositories;
using Infra.Persistence.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Infra
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<IStudentRepository, StudentRepository>();
            services.AddScoped<IStudentService,StudentService>();
            services.AddScoped<ICourseReadService, CourseReadService>();
            services.AddScoped<ITeacherReadService,TeacherReadService>();
            services.AddScoped<ICourseRankingService , CourseRankingService>();
            services.AddScoped<ICourseQueryRepository, CourseRepository>();

            return services;
        }
    }
}
