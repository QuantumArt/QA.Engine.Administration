using System;
using System.Text;
using QA.Core.Engine;
using QA.Core.Extensions;
using QA.Core.Service.Interaction;
using QA.Core.Web;
using QA.Engine.Administration.Services;
using QA.Engine.Administration.WebApp.Actions;
using QA.Engine.Administration.WebApp.AppCode;
using QA.Engine.Administration.WebApp.Configuration;
using QA.Engine.Administration.WebApp.Entities;
using QA.Engine.Administration.WebApp.Resources;

namespace QA.Engine.Administration.WebApp.Models
{
    public class ScriptModel : ModelBase
    {
        public string GetScript()
        {
            var sb = new StringBuilder();
            sb.AppendFormat("var {0} = {1};", new Global().GetType().Name, new Global().ToJsonString());
            sb.AppendFormat("var {0} = {1};", new Shared().GetType().Name, new Shared().ToJsonString());
            sb.AppendFormat("var {0} = {1};", new Resources.SiteMap().GetType().Name, new Resources.SiteMap().ToJsonString());
            sb.AppendFormat("var {0} = {1};", new Resources.SiteMap().GetType().Name, new Resources.SiteMap().ToJsonString());
            sb.Append("var Enums = {");
            sb.AppendFormat("ContentVersionOperations: {0},", (ContentVersionOperations.Delete as Enum).ToJsonString());
            sb.AppendFormat("ItemState: {0},", (ItemState.Approved as Enum).ToJsonString());
            sb.AppendFormat("VersionTypes: {0},", (VersionTypes.Content as Enum).ToJsonString());
            sb.Append("};");
            sb.AppendFormat("var {0} = {1};", SerializableSiteConfiguration.SiteConfigGroup, new SerializableSiteConfiguration().ToJsonString());
            sb.AppendFormat("var {0} = {1};", SerializableAppSettings.AppSettingsGroupName, new SerializableAppSettings().ToJsonString());
            sb.AppendFormat("var {0} = {1};", "QpActionCodes", new QpActionCodes().ToJsonString());
            sb.AppendFormat("var {0} = {1};", "QpEntityCodes", new QpEntityCodes().ToJsonString());
            return sb.ToString();
        }

        public string GetContentsScript()
        {
            var service = ClientUtils.Resolve<IQpService>();
            var result = service.GetContents(new UserContext());
            if (!result.IsSucceeded)
            {
                throw new Exception(App_LocalResources.ErrorMessages.QpContentScriptGenerationErrorMessage);
            }

            var sb = new StringBuilder();
            sb.Append("var QpContents = {};");
            foreach (var item in result.Result)
            {
                var fields = new StringBuilder();
                foreach (var f in item.Fields)
                {
                    fields.AppendFormat("{0}: {{ Name: \"{0}\", Id: \"field_{1}\"}},", f.Name, f.Id);
                }

                sb.AppendFormat("QpContents.{0} = {{ Name: \"{0}\", Id: \"{1}\", Fields: {{{2}}}}};", item.Name, item.Id, fields.ToString());
            }

            return sb.ToString();
        }

        public string GetCultureScript()
        {
            var service = ClientUtils.Resolve<IDictionaryService>();
            var result = service.GetCultureList(new UserContext());
            if (!result.IsSucceeded)
            {
                throw new Exception(App_LocalResources.ErrorMessages.QpCultureScriptGenerationErrorMessage);
            }

            var sb = new StringBuilder();
            sb.Append("var QpCultures = {};");
            foreach (var item in result.Result)
            {
                sb.AppendFormat("QpCultures.culture{0} = {{ Name: \"{1}\", Id: \"{0}\" }};", item.Id, item.Name);
            }

            return sb.ToString();
        }
    }
}
