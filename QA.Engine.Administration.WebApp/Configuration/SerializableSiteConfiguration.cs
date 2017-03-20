using System.Runtime.Serialization;

namespace QA.Engine.Administration.WebApp.Configuration
{
    [DataContract]
    public class SerializableSiteConfiguration
    {
        public const string SiteConfigGroup = "SiteConfiguration";

        [DataMember]
        public int RootPageId { get; set; } = SiteConfiguration.Current.RootPageId;

        [DataMember]
        public string CurrentName { get; set; } = SiteConfiguration.CurrentName;

        [DataMember]
        public int SiteId { get; set; } = SiteConfiguration.Current.SiteId;
    }
}
