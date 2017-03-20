
namespace QA.Engine.Administration.Data
{
    /// <summary>
    /// Содержит данные о наличии потомков для раздела
    /// </summary>
    public class SiteMapChildrenCountResult
    {
        /// <summary>
        /// Идентификатор раздела
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Признак наличия потомков
        /// </summary>
        public int ChildrenCount { get; set; }
    }
}
