using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Net.Http.Headers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Aspects.Autofac.Authentication
{
    public class AuthenticationAspect : MethodInterception
    {
        private IHttpContextAccessor _httpContextAccessor;

        public AuthenticationAspect()
        {
            // aspect injectionları yakalayamaz o yuzden ona ozel tool yaptık
            _httpContextAccessor = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();
        }

        protected override void OnBefore(IInvocation invocation)
        {

            string header = _httpContextAccessor.HttpContext.Request.Headers[HeaderNames.Authorization].ToString().Replace("Bearer ", "");
            if (header.Length == 0)
            {
                throw new Exception("Sisteme Giris Yapmaniz Gerekmektedir.");
            }
            return;
        }


    }
}
