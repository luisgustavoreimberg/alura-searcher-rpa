using AluraSearcherRPA.Application.Interfaces;
using AluraSearcherRPA.Application.Mappers;
using AluraSearcherRPA.Application.Services;
using AluraSearcherRPA.Infrastructure.Interfaces;
using AluraSearcherRPA.Infrastructure.Repositories;
using AluraSearcherRPA.RPA.Interfaces;
using AluraSearcherRPA.RPA.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace AluraSearcherRPA.DependencyInjection
{
    public static class ServicesSettings
    {
        public static void ConfigureServices(this IServiceCollection services, string driverPath)
        {
            services.AddScoped<IHistoryService, HistoryService>();
            services.AddScoped<ISearchService, SearchService>();
            services.AddScoped<IAutomationService, AluraAutomationService>(provider => new AluraAutomationService(driverPath));
            services.AddAutoMapper(typeof(CourseInfoProfile).Assembly);
        }
        public static void ConfigureSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Alura Searcher RPA",
                    Version = "v1",
                    Description = "API criada para realizar a chamada ao RPA de busca de cursos na Alura",
                    Contact = new OpenApiContact
                    {
                        Name = "Luis Reimberg"
                    }
                });
            });
        }
        public static void ConfigureDatabase(this IServiceCollection services, string connectionString)
        {
            services.AddScoped<ISearchRepository>(provider => new SearchRepository(connectionString));
        }
    }
}
