using BaseEntityLib;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UserDomain;

namespace NoteDomain
{
    [Table("Notes")]
    public partial class NoteEntity : IBaseEntity<Guid>
    {
        [Key]
        public Guid Id { get; set; }

        /// <summary>
        /// Title
        /// </summary>
        [Required]
        public string Title { get; set; }

        /// <summary>
        /// Text
        /// </summary>
        [Required]
        public string Text { get; set; }

        /// <summary>
        /// Author Id
        /// </summary>
        [Required]
        public string UserId { get; set; }

        /// <summary>
        /// Author
        /// </summary>

        [ForeignKey(nameof(UserId))]
        public virtual AppUser? User { get; set; }
    }
}