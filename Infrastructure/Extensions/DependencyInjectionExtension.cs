using Application.Common.Behaviors;
using Application.Features.Patients.Commands.CreatePatient;
using Application.Features.Patients.Mappings;
using Application.Interfaces;
using FluentValidation;
using Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Extensions
{
    public static class DependencyInjectionExtension
    {
        public static IServiceCollection AddMappingProfiles(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(PatientProfile).Assembly);

            return services;
        }

        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddValidatorsFromAssembly(typeof(CreatePatientCommand).Assembly);

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

            return services;
        }

        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(Environment.GetEnvironmentVariable("ConnectionStrings__DefaultConnection")));

            services.AddScoped<IAppDbContext, AppDbContext>();

            return services;
        }
    }
}
