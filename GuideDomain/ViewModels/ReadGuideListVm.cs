using GuideDomain.Guide;

namespace GuideDomain.ViewModels
{
    /// <summary>
    /// Read guide list view model
    /// </summary>
    public class ReadGuideListVm
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
        public ICollection<GuideEntity> Guides { get; set; }
    }
}
