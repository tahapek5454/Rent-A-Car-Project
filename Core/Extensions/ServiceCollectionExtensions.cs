using Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Extensions
{
    public static class ServiceCollectionExtensions
    {
        // servis bagımlılıklarnı ekledigimiz koleksiyondur .Net

        // ServiceCollectiona metod ekledim yani IModuleden implemete edilen tum modulleri alsın ve cozsun

        // Tum Injectionları toplatabilecegimiz bir yapi
        public static IServiceCollection AddDependencyResolvers(this IServiceCollection serviceCollection, ICoreModule[] modules )
        {
            foreach (var module in modules)
            {
                module.Load(serviceCollection);

            }
            // servisCollection icindkei tum modulleri halletik 'dependencyResolver'
            return ServiceTool.Create(serviceCollection);
        }

    }
}
