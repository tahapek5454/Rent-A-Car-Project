using Core.CrossCuttingConcerns.Caching.Abstract;
using Core.CrossCuttingConcerns.Caching.Concrete.Microsoft;
using Core.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.DependencyResolvers
{
    public class CoreModule : ICoreModule
    {
        public void Load(IServiceCollection serviceCollection)
        {
            // Autofac ile biz business'da proje ozgu ve genel ctor da atayabilecegimiz injectionları cozebilirz
            // Burası Core katmanı ve genel her projeye hitap etmeli.
            // .NET altyapısından yararlanarak olusturdugumuz serviceTool ve ICoreModule'dan yararlanarak genel bir dependencyResolver kullanıyoruz
            // Aspect calisirken autofacten yararlanamadigi icin aspectten olusan dependencyi 'httpContextAccessor' burda cozucez
            // Hem Aspect olması hem de genel her projede olması bizi bu duruma goturdu
            serviceCollection.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            serviceCollection.AddSingleton<ICacheManager, MemoryCacheManager>();
            serviceCollection.AddMemoryCache(); //IMemoryCache .net sagliyordu zaten adamlar kısa yoldan injection cozmus
        }
    }
}
