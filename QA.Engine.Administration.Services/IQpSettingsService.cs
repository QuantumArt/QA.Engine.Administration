namespace QA.Engine.Administration.Services
{
    public interface IQpSettingsService
    {
        string GetSetting(string connectionString, string title);
    }
}