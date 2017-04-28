namespace QA.Engine.Administration.Data
{
    public class AdminQpDbConnector : Core.Data.QP.QpDbConnector
    {
        public AdminQpDbConnector(IQpHelper qpHelper) : base(qpHelper.ConnectionString)
        {

        }
    }
}
