using QA.Core;
using QA.Core.Service.Interaction;
using QA.Core.Web;
using QA.Engine.Administration.WebApp.Configuration;
using System.Web;

namespace QA.Engine.Administration.WebApp.AppCode
{
    public class ClientUtils : ModelBase
    {
        public static T Resolve<T>()
        {
            return ObjectFactoryBase.ResolveByName<T>(SiteConfiguration.Current.ContainerName);
        }

        public static void SetServiceToken()
        {
            var token = SiteConfiguration.Current;
            var serviceToken = new ServiceToken
            {
                DependencyContainerName = token.ContainerName,
                SiteId = token.SiteId,
                ConnectionName = token.ConnectionName
            };

            HttpContext.Current.Items[ServiceToken.ServiceTokenKey] = serviceToken;
        }
    }
}
