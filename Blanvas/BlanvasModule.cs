using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blanvas
{
    public static class BlanvasModule
    {
        public static IServiceCollection AddBlanvasModule(this IServiceCollection services)
        {
            services.AddSingleton<BlanvasCore>();
            return services;
        }
    }
}
