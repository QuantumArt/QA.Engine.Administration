using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QA.Engine.Administration.Data;

namespace QA.Engine.Administration.WebApp.Test
{

    public class QpHelper : IQpHelper
    {
        public string BackendSid
        {
            get; set;
        }

        public string ConnectionString
        {
            get; set;
        }

        public string CustomerCode
        {
            get; set;
        }

        public string HostId
        {
            get; set;
        }

        public bool IsQpMode
        {
            get; set;
        }

        public string QpKey
        {
            get; set;
        }

        public string SiteId
        {
            get; set;
        }
    }
}
