using Business.Constract;
using Castle.DynamicProxy;
using Core.Extensions;
using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.BusinessAspects.Autofac
{
    //JWT için yapıldı
    // Core'daki autofac içine yazmamaızın sebebi bu yetkilendirmeler projeden projeye değişebilir.
    public class SecuredOperation : MethodInterception
    {
        private string[] _roles;
        private IHttpContextAccessor _httpContextAccessor;

        public SecuredOperation(string roles)
        {
            _roles = roles.Replace(" ", "").Split(','); //rolleri splitledik aldik
            // aspect injectionları yakalayamaz o yuzden ona ozel tool yaptık
            _httpContextAccessor = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();

        }

        protected override void OnBefore(IInvocation invocation)
        {
            var roleClaims = _httpContextAccessor.HttpContext.User.ClaimRoles();
            foreach (var role in _roles)
            {
                if (roleClaims.Contains(role))
                {
                    return;
                }
            }
            if (_roles[0].Length == 0) throw new Exception(Messages.EnterAuthantication);
            else throw new Exception(Messages.AuthorizationDenied);
        }
    }
}
