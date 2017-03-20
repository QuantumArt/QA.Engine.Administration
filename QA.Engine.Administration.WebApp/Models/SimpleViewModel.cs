using QA.Core.Web;

namespace QA.Engine.Administration.WebApp.Models
{
    public class SimpleViewModel<T> : QpViewModelBase
    {
        public T Data { get; set; }
    }
}
