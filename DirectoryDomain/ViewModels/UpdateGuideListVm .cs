﻿using DirectoriesDomain.Directory;

namespace DirectoriesDomain.ViewModels
{
    /// <summary>
    /// Update guide list view model
    /// </summary>
    public class UpdateDirectoryListVm
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
        public IQueryable<DirectoryEntity>? Directories { get; set; }
    }
}
