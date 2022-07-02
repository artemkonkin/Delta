using DirectoryDomain.Directory;

namespace DirectoryDomain.ViewModels
{
    /// <summary>
    /// Read guide list view model
    /// </summary>
    public class ReadDirectoryListVm
    {
        /// <summary>
        /// Identifier
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Directory name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Directories list
        /// </summary>
        public ICollection<DirectoryEntity> Directories { get; set; }
    }
}
