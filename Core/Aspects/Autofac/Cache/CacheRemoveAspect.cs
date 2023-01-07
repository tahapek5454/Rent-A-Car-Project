using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Caching.Abstract;
using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Aspects.Autofac.Cache
{
    public class CacheRemoveAspect : MethodInterception
    {
        private string _pattern;
        private ICacheManager _cacheManager;

        public CacheRemoveAspect(string pattern)
        {
            _pattern = pattern;
            _cacheManager = ServiceTool.ServiceProvider.GetService<ICacheManager>();
        }

        protected override void OnSuccess(IInvocation invocation)
        {
            // onSucces'de yap cunku hata verirse veri tabanı atıyorum guncellenmedi bosuna cachi silme
            _cacheManager.RemoveByPattern(_pattern);
        }
    }
}
