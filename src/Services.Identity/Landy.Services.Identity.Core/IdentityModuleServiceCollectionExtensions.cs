using System.Reflection;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Landy.Domain.Repositories;
using Landy.Services.Identity.Core.Configuration;
using Landy.Services.Identity.Core.Mappers;
using Landy.Services.Identity.Core.Persistence.Repositories;
using Landy.Services.Notification.Grpc;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class IdentityModuleServiceCollectionExtensions
    {
        public static IServiceCollection AddIdentityModuleCore(this IServiceCollection services, AppSettings appSettings)
        {
            services.AddEFDataAccess(appSettings.ConnectionStrings.Identities)
                .AddGrpcClients(appSettings.Services)
                .AddMediator()
                .AddMappers();

            return services;
        }

        private static IServiceCollection AddEFDataAccess(this IServiceCollection services, string connectionString, string migrationsAssembly = "")
        {
            services.AddDbContext<IdentityDbContext>(options => options.UseSqlServer(connectionString, sql =>
            {
                if (!string.IsNullOrEmpty(migrationsAssembly))
                {
                    sql.MigrationsAssembly(migrationsAssembly);
                }
            }))
            .AddScoped<IUnitOfWork>(provider => provider.GetService<IdentityDbContext>())
            .AddScoped(typeof(IRepository<,>), typeof(Repository<,>))
            .AddScoped<IUserRepository, UserRepository>();

            return services;
        }

        private static IServiceCollection AddGrpcClients(this IServiceCollection services, ServiceOptions serviceOptions)
        {
            services.AddGrpcClientOptions<Email.EmailClient>(serviceOptions.Notification.Grpc);

            return services;
        }

        private static IServiceCollection AddMediator(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());

            return services;
        }

        private static IServiceCollection AddMappers(this IServiceCollection services)
        {
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            var mapper = mapperConfig.CreateMapper();

            services.AddSingleton(mapper);

            return services;
        }
    }
}
