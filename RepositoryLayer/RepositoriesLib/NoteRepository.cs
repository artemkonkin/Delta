using BaseEntityLib;
using BaseRepositoryLib;
using DbContextLib;
using EnumsLib;
using NoteDomain;
using RepositoriesLib.Interfaces;

namespace RepositoriesLib
{
    public class NoteRepository : Repository<NoteEntity>, INoteRepository
    {
        public NoteRepository(DbFactory dbFactory) : base(dbFactory)
        {
        }

        public IQueryable<NoteEntity> GetUserNotes(string? userId)
        {
            return Get(x => x.UserId == userId);
        }

        public Response<NoteEntity> AddNote(string title, string text, string userId)
        {
            var note = new NoteEntity(title, text, userId);

            try
            {
                if (!note.ValidOnAdd())
                    throw new Exception("Note invalid!");

                Add(note);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new Response<NoteEntity>(ResponseStatus.Error, note, $"Error {e}");
            }

            return new Response<NoteEntity>(ResponseStatus.Success, note, "OK");
        }

        public Response<NoteEntity> UpdateNote(NoteEntity entity)
        {
            try
            {
                Update(entity);
            }
            catch
            {
                return new Response<NoteEntity>()
                {
                    Status = ResponseStatus.Error
                };
            }

            return new Response<NoteEntity>()
            {
                Status = ResponseStatus.Success
            };
        }

        public Response<NoteEntity> DeleteNote(Guid noteId)
        {
            try
            {
                var note = Get(note => note.Id == noteId).First();
                Delete(note);
            }
            catch
            {
                return new Response<NoteEntity>()
                {
                    Status = ResponseStatus.Error
                };
            }

            return new Response<NoteEntity>()
            {
                Status = ResponseStatus.Success
            };
        }
    }
}