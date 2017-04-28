using QA.Core.Data;
using QA.Core.Engine.QPData.Context;


namespace QA.Engine.Administration.Data
{
    public class AdminUnitOfWork : QPUnitOfWork
    {

        public AdminUnitOfWork(IQpHelper qpHelper, IXmlMappingResolver mappingSource) : base(qpHelper.ConnectionString, mappingSource)
        {
            
        }
    }
}
