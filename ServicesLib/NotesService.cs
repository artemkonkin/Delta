using System.Data;
using System.Security.Claims;
using BaseEntityLib;
using BaseServiceLib;
using EnumsLib;
using Microsoft.AspNetCore.Identity;
using NoteDomain;
using RepositoriesLib.Interfaces;
using UnitOfWorkLib;
using UserDomain;

namespace ServicesLib
{
    /// <summary>
    /// Notes service
    /// </summary>
    public class NotesService : BaseService
    {
        private readonly INoteRepository _noteRepository;

        public NotesService(IUnitOfWork uow, INoteRepository noteRepository, UserManager<AppUser> userManager) : base(uow, userManager)
        {
            _noteRepository = noteRepository;
        }

        /// <summary>
        /// Get user notes
        /// </summary>
        /// <param name="userId"> Author user id </param>
        /// <returns> User notes list </returns>
        public IQueryable<NoteEntity> GetUserNotes(string? userId)
        {
            var currentUserId = UserManager.GetUserId(ClaimsPrincipal.Current);

            if (currentUserId == userId)
                return _noteRepository.Get(x => x.UserId == currentUserId);

            throw new Exception($"It's not you! UserId {userId}");
        }

        /// <summary>
        /// Add note
        /// </summary>
        /// <param name="title"> Title </param>
        /// <param name="text"> Text </param>
        /// <param name="user"> Author </param>
        /// <returns> New note entity </returns>
        public async Task<NoteEntity> AddNote(string title, string text, string userId)
        {
            var newNote = _noteRepository.AddNote(title, text, userId);
            await Uow.CommitAsync();
            if (newNote.Status == ResponseStatus.Success)
            {
                return newNote.Data;
            }

            throw new InvalidExpressionException($"Error: {newNote.Message}");
        }

        /// <summary>
        /// Update note
        /// </summary>
        /// <param name="entity"> Note entity </param>
        /// <returns> Edit status </returns>
        public async Task<ResponseStatus> UpdateNote(NoteEntity entity)
        {
            var updatedNote = _noteRepository.UpdateNote(entity);
            await Uow.CommitAsync();
            return updatedNote.Status;
        }

        /// <summary>
        /// Delete note
        /// </summary>
        /// <param name="entity"> Note entity </param>
        public async void DeleteNote(NoteEntity entity)
        {
            try
            {
                _noteRepository.Delete(entity);
                await Uow.CommitAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}