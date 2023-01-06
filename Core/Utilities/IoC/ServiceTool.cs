using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.IoC
{
    // bagimsiz ınjectionları cozuyor
    // Dependency Injection Yazılımda bağımlılıkların dışarıdan enjekte edilmesi işlemidir
    // herhangi bir servisin karsiligini bu tool ile alabilirz
    // aspect yaparken daha onceki kullandigimiz yontem islemitor 'autofac'
    // ayriyetten konsol uygulamaları, window uygulamaları icin de bunu kullanabilirz
    // net in alt yapısı kullanılıyor
    public static class ServiceTool
    {
        public static IServiceProvider ServiceProvider { get; private set; }

        public static IServiceCollection Create(IServiceCollection services)
        {
            ServiceProvider = services.BuildServiceProvider();
            return services;
        }
    }
}
