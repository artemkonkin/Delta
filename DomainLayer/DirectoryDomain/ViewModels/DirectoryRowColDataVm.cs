using DirectoryDomain.Directory;

namespace DirectoryDomain.ViewModels
{
    /// <summary>
    /// Directory row data
    /// </summary>
    public class DirectoryRowColDataVm
    {
        public Guid Id { get; set; }

        /// <summary>
        /// Row
        /// </summary>
        public virtual Guid DirectoryRowId { get; set; }
        public virtual DirectoryRow DirectoryRow { get; set; }

        /// <summary>
        /// Col
        /// </summary>
        public virtual Guid DirectoryColId { get; set; }
        public virtual DirectoryCol DirectoryCol { get; set; }

        /// <summary>
        /// Value
        /// </summary>
        public virtual object Value { get; set; }

    }
}