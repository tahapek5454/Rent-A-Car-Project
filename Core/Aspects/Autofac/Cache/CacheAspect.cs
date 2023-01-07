using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Caching.Abstract;
using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Aspects.Autofac.Cache
{
    public class CacheAspect : MethodInterception
    {
        private int _duration;
        private ICacheManager _cacheManager;
        // managerimizi ve suremizi aldik
        public CacheAspect(int duration = 60)
        {
            _duration = duration;
            _cacheManager = ServiceTool.ServiceProvider.GetService<ICacheManager>();
        }

        public override void Intercept(IInvocation invocation)
        {
            //invocatin = metodumuz
            //Kullanılacak metodun dosya yoluunu aldık mesela -> DataAcces.Abstract.ICarDal
            var methodName = string.Format($"{invocation.Method.ReflectedType.FullName}.{invocation.Method.Name}");
            //Varsa metodun parametrelerini aldık
            var arguments = invocation.Arguments.ToList();
            //Keyi olusturduk
            var key = $"{methodName}({string.Join(",", arguments.Select(x => x?.ToString() ?? "<Null>"))})";

            // kontrol ettik ilgili key'in donen verisi varsa metodun return'une onu verdik
            if (_cacheManager.IsAdd(key))
            {
                invocation.ReturnValue = _cacheManager.Get(key);
                return;
            }
            // Cache'de yoksa metodun calisip isini klasik yapmasini sagladik
            invocation.Proceed();
            // donen degeri tabii iligli key ve duraiton time ile birlikte cache' ekledik
            _cacheManager.Add(key, invocation.ReturnValue, _duration);
        }
    }
}
