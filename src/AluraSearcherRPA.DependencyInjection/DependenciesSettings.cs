using AluraSearcherRPA.Application.Interfaces;
using AluraSearcherRPA.Application.Services;
using AluraSearcherRPA.RPA.Interfaces;
using AluraSearcherRPA.RPA.Services;
using Microsoft.Extensions.DependencyInjection;

namespace AluraSearcherRPA.DependencyInjection
{
    internal static class DependenciesSettings
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IHistoryService, HistoryService>();
            services.AddScoped<ISearchService, SearchService>();
            services.AddScoped<IAutomationService, AluraAutomationService>();
        }
    }
}
