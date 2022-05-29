using GuideDomain.Guide;

namespace GuideDomain.ViewModels
{
    /// <summary>
    /// Update guide list view model
    /// </summary>
    public class UpdateGuideListVm
    {
        /// <summary>
        /// Identifier
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Guide name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Guides list
        /// </summary>
        public IQueryable<GuideEntity>? Guides { get; set; }
    }
}
