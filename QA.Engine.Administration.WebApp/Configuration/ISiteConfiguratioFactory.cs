
namespace QA.Engine.Administration.WebApp.Configuration
{
    public interface ISiteConfiguratioFactory
    {
        SiteConfiguration Create(string customerCode, int siteId);
    }
}