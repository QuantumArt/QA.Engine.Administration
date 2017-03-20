using QA.Core;
using QA.Core.Engine;
using QA.Core.Engine.QPData;
using QA.Core.Service.Interaction;
using QA.Engine.Administration.Data;
using QA.Engine.Administration.Dto;

namespace QA.Engine.Administration.Services
{
    public class DictionaryService : QAServiceBase, IDictionaryService
    {
        public DictionaryService()
        {
            MappingBootstrapper.Initialize();
        }

        public ServiceEnumerationResult<DiscriminatorDTO> GetDiscriminators(UserContext userContext)
        {
            return RunEnumeration(userContext, null, () =>
            {
                var items = Resolve<IDictionaryRepository>().GetDiscriminators();
                return new ServiceEnumerationResult<DiscriminatorDTO>
                {
                    Result = MappingHelper.Map<QPDiscriminator, DiscriminatorDTO>(items),
                    PageInfo = null,
                    IsSucceeded = true
                };
            });
        }

        public ServiceEnumerationResult<DiscriminatorConstraintDto> GetDiscriminatorConstraints(UserContext userContext)
        {
            return RunEnumeration(userContext, null, () =>
            {
                var items = Resolve<IDictionaryRepository>().GetItemDefinitionConstraints();
                return new ServiceEnumerationResult<DiscriminatorConstraintDto>
                {
                    Result = MappingHelper.Map<QPItemDefinitionConstraint, DiscriminatorConstraintDto>(items),
                    PageInfo = null,
                    IsSucceeded = true
                };
            });
        }

        public ServiceEnumerationResult<Region> GetRegionList(UserContext userContext, string namePart, PageInfo pageInfo)
        {
            return RunEnumeration(userContext, null, () =>
            {
                var items = Resolve<IDictionaryRepository>().GetRegionList(namePart, pageInfo?.PageNumber, pageInfo?.PageSize);
                var result = new ServiceEnumerationResult<Region>
                {
                    Result = MappingHelper.Map<QPRegion, Region>(items),
                    PageInfo = pageInfo,
                    IsSucceeded = true
                };

                if (pageInfo != null)
                {
                    result.PageInfo.TotalCount = Resolve<IDictionaryRepository>().GetRegionCount(namePart);
                }

                return result;
            });
        }

        public ServiceEnumerationResult<Region> GetRegionListByNames(UserContext userContext, string names)
        {
            return RunEnumeration(userContext, null, () =>
            {
                var items = Resolve<IDictionaryRepository>().GetRegionList(names);
                var result = new ServiceEnumerationResult<Region>
                {
                    Result = MappingHelper.Map<QPRegion, Region>(items),
                    PageInfo = null,
                    IsSucceeded = true
                };

                return result;
            });
        }

        public ServiceEnumerationResult<Culture> GetCultureList(UserContext userContext)
        {
            return RunEnumeration(userContext, null, () =>
            {
                var items = Resolve<IDictionaryRepository>().GetCultureList();
                var result = new ServiceEnumerationResult<Culture>
                {
                    Result = MappingHelper.Map<QPCulture, Culture>(items),
                    PageInfo = null,
                    IsSucceeded = true
                };

                return result;
            });
        }
    }
}
