using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TagEChartsBlazor.Configuration
{
    public static class EChartsExtensions
    {
        public static IServiceCollection AddECharts(this IServiceCollection services)
        {
            services.AddScoped<EChartsHelper>();
            return services;
        }
    }
}
