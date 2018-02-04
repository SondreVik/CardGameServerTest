using CardsLibrary.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace CardsLibrary
{
    public static class RegisterServices
    {
        public static IServiceCollection SetupContainer(IServiceCollection services)
        {
            services.AddTransient<ICardGeneratorService, CardGeneratorService>();
            return services;
        }
    }
}
