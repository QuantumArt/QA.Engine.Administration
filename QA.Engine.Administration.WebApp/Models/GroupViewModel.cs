using System.Collections.Generic;
using QA.Core.Web;

namespace QA.Engine.Administration.WebApp.Models
{
    public class GroupViewModel<T> : ViewModelBase
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<T> List { get; set; }
    }
}
