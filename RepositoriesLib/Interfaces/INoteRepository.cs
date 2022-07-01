using BaseEntityLib;
using BaseRepositoryLib;
using NoteDomain;

namespace RepositoriesLib.Interfaces
{
    public interface INoteRepository : IRepository<NoteEntity>
    {
        IQueryable<NoteEntity> GetUserNotes(string userId);
        Response<NoteEntity> AddNote(string title, string text, string userId);
        Response<NoteEntity> UpdateNote(NoteEntity entity);
        Response<NoteEntity> DeleteNote(Guid entity);
    }
}