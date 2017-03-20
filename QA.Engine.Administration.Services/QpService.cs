using System.Collections.Generic;
using System.Configuration;
using System.Data;
using QA.Core;
using QA.Core.Data.QP;
using QA.Core.Service.Interaction;
using QA.Engine.Administration.Dto;

namespace QA.Engine.Administration.Services
{
    public class QpService : QAServiceBase, IQpService
    {
        public QpService()
        {
            MappingBootstrapper.ConfigureContentMapping();
            MappingBootstrapper.ConfigureActionMapping();
        }

        public ServiceEnumerationResult<QpContentDto> GetContents(UserContext userContext)
        {
            return RunEnumeration(userContext, null, () =>
              {
                  var siteName = new QPMetadataManager(ConfigurationManager.ConnectionStrings[CurrentServiceToken.ConnectionName].ConnectionString).GetSiteName(CurrentServiceToken.SiteId);
                  var result = Resolve<QPContentManager>()
                      .Connection(ConfigurationManager.ConnectionStrings[CurrentServiceToken.ConnectionName].ConnectionString)
                      .SiteName(siteName)
                      .ContentName("CONTENT")
                      .Fields("CONTENT_ID, CONTENT_NAME, NET_CONTENT_NAME")
                      .Where("[NET_CONTENT_NAME] is not null")
                      .GetRealData();

                  var contents = MappingHelper.Map<DataRowCollection, List<QpContentDto>>(result.PrimaryContent.Rows);
                  var fields = Resolve<QPContentManager>()
                      .Connection(ConfigurationManager.ConnectionStrings[CurrentServiceToken.ConnectionName].ConnectionString)
                      .SiteName(siteName)
                      .ContentName("CONTENT_ATTRIBUTE")
                      .Fields("ATTRIBUTE_ID, CONTENT_ID, ATTRIBUTE_NAME, NET_ATTRIBUTE_NAME")
                      .Where("[NET_ATTRIBUTE_NAME] is not null")
                      .GetRealData();

                  contents.ForEach(e =>
                  {
                      e.Fields = MappingHelper.Map<DataRow[], List<QpFieldDto>>(fields.PrimaryContent.Select("CONTENT_ID = " + e.Id));
                  });

                  return new ServiceEnumerationResult<QpContentDto>
                  {
                      Result = contents,
                      IsSucceeded = true
                  };
              });
        }

        public ServiceResult<QpActionDto> GetAction(UserContext userContext, int id)
        {
            return Run2(userContext, null, () =>
              {
                  var siteName = new QPMetadataManager(ConfigurationManager.ConnectionStrings[CurrentServiceToken.ConnectionName].ConnectionString).GetSiteName(CurrentServiceToken.SiteId);
                  var result = Resolve<QPContentManager>()
                      .Connection(ConfigurationManager.ConnectionStrings[CurrentServiceToken.ConnectionName].ConnectionString)
                      .SiteName(siteName)
                      .ContentName("BACKEND_ACTION")
                      .Fields("ID, NAME, CODE")
                      .Where("ID = " + id)
                      .GetRealData();

                  return new ServiceResult<QpActionDto>
                  {
                      Result = MappingHelper.Map<DataRow, QpActionDto>(result.PrimaryContent.Rows.Count > 0 ? result.PrimaryContent.Rows[0] : null),
                      IsSucceeded = true
                  };
              });
        }
    }
}
