using Application.Interfaces.Repositories;
using Application.Interfaces.Ripository;
using Application.Interfaces.Services;
using Application.Services;
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

            return services;
        }
    }
}
