using System.Reflection;
using AutoMapper;
using Landy.Domain.Repositories;
using Landy.Infrastructure.SearchIndexers;
using Landy.Services.Offer.Core.Configuration;
using Landy.Services.Offer.Core.Mappers;
using Landy.Services.Offer.Core.Persistence.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class OfferModuleServiceCollectionExtensions
    {
        public static IServiceCollection AddOfferModuleCore(this IServiceCollection services, AppSettings appSettings)
        {
            services
                .AddEFDataAccess(appSettings.ConnectionStrings.Offers)
                .AddMediatR(Assembly.GetExecutingAssembly())
                .AddMappers()
                .AddSearchIndexer(appSettings.SearchIndexer);

            return services;
        }

        private static IServiceCollection AddEFDataAccess(this IServiceCollection services, string connectionString, string migrationsAssembly = "")
        {
            services.AddDbContext<OfferDbContext>(options => options.UseSqlServer(connectionString, sql =>
            {
                if (!string.IsNullOrEmpty(migrationsAssembly))
                {
                    sql.MigrationsAssembly(migrationsAssembly);
                }
            }))
            .AddScoped<IUnitOfWork>(provider => provider.GetService<OfferDbContext>())
            .AddScoped(typeof(IRepository<,>), typeof(Repository<,>))
            .AddScoped<IOfferRepository, OfferRepository>();

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