using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;
using QA.Core.Service.Interaction;
using QA.Engine.Administration.Services;
using QA.Engine.Administration.WebApp.AppCode;

namespace QA.Engine.Administration.WebApp.Configuration
{
    [DataContract]
    public class SerializableAppSettings
    {
        public const string AppSettingsGroupName = "AppSettings";

        [DataMember]
        public bool IsViewSiteList { get; set; } = AppSettings.IsViewSiteList;

        [DataMember]
        public int DefaultPageSize { get; set; } = AppSettings.DefaultPageSize;

        [DataMember]
        public string ItemPreviewUrlSuffix { get; set; } = AppSettings.ItemPreviewUrlSuffix;

        [DataMember]
        public string ItemPreviewItemIdParamName { get; set; } = AppSettings.ItemPreviewItemIdParamName;

        [DataMember]
        public string ItemPreviewChosenRegionParamName { get; set; } = AppSettings.ItemPreviewChosenRegionParamName;

        [DataMember]
        public string ItemPreviewChosenCultureParamName { get; set; } = AppSettings.ItemPreviewChosenCultureParamName;

        [DataMember]
        [SuppressMessage("ReSharper", "ValueParameterNotUsed")]
        public string ItemPreviewActionCode
        {
            get
            {
                var service = ClientUtils.Resolve<IQpService>();
                var result = service.GetAction(new UserContext(), AppSettings.ItemPreviewCustomActionId);
                return result.Result == null ? string.Empty : result.Result.Code;
            }
            set { }
        }
    }
}
