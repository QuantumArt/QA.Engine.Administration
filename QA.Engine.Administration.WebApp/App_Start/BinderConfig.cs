using System.Web.Mvc;
using QA.Core.Web;

namespace QA.Engine.Administration.WebApp.App_Start
{
    public class BinderConfig
    {
        public static void RegisterBinders()
        {
            DataAnnotationsModelValidatorProvider.RegisterAdapter(typeof(RequiredIfAttribute), typeof(RequiredIfValidator));
        }
    }
}
