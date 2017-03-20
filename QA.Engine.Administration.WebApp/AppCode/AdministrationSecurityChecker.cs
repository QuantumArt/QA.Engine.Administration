using QA.Core.Web.Qp;
using System.Web;

namespace QA.Engine.Administration.WebApp.AppCode
{
    public class AdmininstrationSecurityChecker : QPSecurityChecker
    {
        public override bool CheckAuthorization(HttpContextBase context)
        {
            ClientUtils.SetServiceToken();
            return base.CheckAuthorization(context);
        }
    }
}
