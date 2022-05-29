using BaseEntityLib;
using BaseRepositoryLib;
using DbContextLib;
using EnumsLib;
using GuideDomain;
using RepositoriesLib.Interfaces.Guide;

namespace RepositoriesLib
{
    public class GuideListRepository : Repository<GuidesList>, IGuideListRepository
    {
        public GuideListRepository(DbFactory dbFactory) : base(dbFactory)
        {
        }

        /// <summary>
        /// Get all guides lists
        /// </summary>
        /// <returns></returns>
        public IQueryable<GuidesList> GetAllGuidesLists()
        {
            return Get(lists => true);
        }

        /// <summary>
        /// Get guide list
        /// </summary>
        /// <param name="guideListId"> Guide list id </param>
        /// <returns></returns>
        public Response<GuidesList> GetGuideListById(Guid guideListId)
        {
            var result = Get(lists => lists.Id == guideListId);
            return new Response<GuidesList>
            {
                Status = ResponseStatus.Success,
                Data = result.Any() 
                    ? result.First() 
                    : throw new Exception($"Guide list {guideListId} not fount."),
                Message = null
            };
        }

        /// <summary>
        /// Add guide list with guides
        /// </summary>
        /// <param name="guideListEntity"> Guide list entity </param>
        /// <returns></returns>
        public Response<GuidesList> AddGuideList(GuidesList guideListEntity)
        {
            Add(guideListEntity);
            
            return new Response<GuidesList>
            {
                Status = ResponseStatus.Success,
                Data = guideListEntity,
                Message = null
            };
        }

        /// <summary>
        /// Add empty guides list
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public Response<GuidesList> AddEmptyGuideList(string name)
        {
            var newList = new GuidesList
            {
                Name = name
            };
            
            Add(newList);

            return new Response<GuidesList>
            {
                Status = ResponseStatus.Success,
                Data = newList,
                Message = null
            };
        }

        /// <summary>
        /// Edit guide list
        /// </summary>
        /// <param name="guideListEntity"> Guide list entity </param>
        /// <returns></returns>
        public Response<GuidesList> UpdateGuidesList(GuidesList guideListEntity)
        {
            Update(guideListEntity);

            return new Response<GuidesList>
            {
                Status = ResponseStatus.Success,
                Data = guideListEntity,
                Message = null
            };
        }

        /// <summary>
        /// Update guide list
        /// </summary>
        /// <param name="id"> Guide list id </param>
        /// <param name="name"> Guide list name </param>
        /// <returns></returns>
        public Response<GuidesList> RenameGuideList(Guid id, string name)
        {
            var guideList = Get(x => x.Id == id);
            
            if (!guideList.Any()) 
                throw new Exception($"Guide list {id} not fount.");
            
            var list = guideList.First();

            var updatedList = new GuidesList
            {
                Id = list.Id,
                Name = name,
                GuideEntities = list.GuideEntities
            };

            Update(updatedList);

            return new Response<GuidesList>
            {
                Status = ResponseStatus.Success,
                Data = updatedList,
                Message = null
            };
        }

        /// <summary>
        /// Delete guide list
        /// </summary>
        /// <param name="id"> Guide list id </param>
        /// <returns></returns>
        public Response<GuidesList> DeleteGuideList(Guid id)
        {
            var guideList = Get(x => x.Id == id);
            if (!guideList.Any())
                throw new Exception($"Guide list {id} not fount.");

            var deletedGuideList = guideList.First();

            Delete(deletedGuideList);

            return new Response<GuidesList>
            {
                Status = ResponseStatus.Success,
                Data = deletedGuideList,
                Message = null
            };
        }
    }
}
