using BaseEntityLib;
using BaseRepositoryLib;
using DbContextLib;
using GuideDomain;
using GuideDomain.Guide;
using RepositoriesLib.Interfaces.Guide;

namespace RepositoriesLib
{
    public class GuideRepository : Repository<GuidesList>, IGuideRepository
    {
        public GuideRepository(DbFactory dbFactory) : base(dbFactory)
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

        /// <summary>
        /// Get all guides
        /// </summary>
        /// <returns></returns>
        public IQueryable<GuideEntity> GetAllGuides()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get guide
        /// </summary>
        /// <param name="id"> Guide id </param>
        /// <returns></returns>
        public GuideEntity GetGuide(Guid id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Add guide
        /// </summary>
        /// <param name="guideEntity"> Guide entity </param>
        /// <returns></returns>
        public GuideEntity AddGuide(GuideEntity guideEntity)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Add empty guide
        /// </summary>
        /// <param name="name"> Guide name </param>
        /// <returns></returns>
        public GuideEntity AddEmptyGuide(string name)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Edit guide
        /// </summary>
        /// <param name="guideEntity"> Guide entity </param>
        /// <returns></returns>
        public GuideEntity EditGuide(GuideEntity guideEntity)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Rename guide
        /// </summary>
        /// <param name="id"> Guide id </param>
        /// <param name="name"> Gudie name </param>
        /// <returns></returns>
        public GuideEntity RenameGuide(Guid id, string name)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Delete guide
        /// </summary>
        /// <param name="id"> Guide id </param>
        /// <returns></returns>
        public IQueryable<GuideEntity> DeleteGuide(Guid id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get all guide cols
        /// </summary>
        /// <returns></returns>
        public IQueryable<GuideCol> GetAllGuidesCols()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get guide col
        /// </summary>
        /// <param name="id"> Col id </param>
        /// <returns></returns>
        public GuideCol GetGuideCol(Guid id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Add guide col
        /// </summary>
        /// <param name="guideColEntity"> Guide col entity </param>
        /// <returns></returns>
        public GuideCol AddGuideCol(GuideCol guideColEntity)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Add emty guide col
        /// </summary>
        /// <param name="name"> Guide col name </param>
        /// <returns></returns>
        public GuideCol AddEmptyGuideCol(string name)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Edit guide col
        /// </summary>
        /// <param name="guideColEntity"> Guide col entity </param>
        /// <returns></returns>
        public GuideCol EditGuideCol(GuideCol guideColEntity)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Rename guide col
        /// </summary>
        /// <param name="id"> Guide col id </param>
        /// <param name="name"> Guide col name </param>
        /// <returns></returns>
        public GuideCol RenameGuideCol(Guid id, string name)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Delete guide col
        /// </summary>
        /// <param name="id"> Guide col id </param>
        /// <returns></returns>
        public IQueryable<GuideCol> DeleteGuideCol(Guid id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get all guide rows
        /// </summary>
        /// <returns></returns>
        public IQueryable<GuideRow> GetAllGuidesRows()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get guide row
        /// </summary>
        /// <param name="id"> Guide row id </param>
        /// <returns></returns>
        public GuideRow GetGuideRow(Guid id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get guide row data
        /// </summary>
        /// <param name="id"> Guide row id </param>
        /// <returns></returns>
        public GuideRow GetGuideRowData(Guid id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get guide row cols list
        /// </summary>
        /// <param name="id"> Guide row id </param>
        /// <returns></returns>
        public IQueryable<GuideCol> GetGuideRowCols(Guid id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Add guide row
        /// </summary>
        /// <param name="guideRowEntity"> Guide row entity </param>
        /// <returns></returns>
        public GuideRow AddGuideRow(GuideRow guideRowEntity)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Add empty guide row
        /// </summary>
        /// <param name="name"> Guide row name </param>
        /// <returns></returns>
        public GuideRow AddEmptyGuideRow(string name)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Edit guide row
        /// </summary>
        /// <param name="guideRowEntity"> Gudie entity </param>
        /// <returns></returns>
        public GuideRow EditGuideRow(GuideRow guideRowEntity)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Rename guide row
        /// </summary>
        /// <param name="id"> Guide row id </param>
        /// <param name="name"> Guide row name </param>
        /// <returns></returns>
        public GuideRow RenameGuideRow(Guid id, string name)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Delete guide row
        /// </summary>
        /// <param name="id"> Guide row id </param>
        /// <returns></returns>
        public IQueryable<GuideRow> DeleteGuideRow(Guid id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get all row col data
        /// </summary>
        /// <returns></returns>
        public IQueryable<GuideRowColData> GetAllGuideRowsColsData()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get row col data
        /// </summary>
        /// <param name="rowColId"> Row col id </param>
        /// <returns></returns>
        public GuideRowColData GetGuideRowColColData(Guid rowColId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get guide row col data value by row id
        /// </summary>
        /// <param name="rowId"> Guide row </param>
        /// <returns></returns>
        public GuideRowColData GetGuideRowColDataValueByRow(Guid rowId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get guide row col data value by col id
        /// </summary>
        /// <param name="colId"> Guide col id </param>
        /// <returns></returns>
        public GuideRowColData GetGuideRowColDataValueByCol(Guid colId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Add empty row col data
        /// </summary>
        /// <param name="rowColName"> Row col name </param>
        /// <returns></returns>
        public GuideRowColData AddEmptyGuideRowColData(string rowColName)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Edit row col data
        /// </summary>
        /// <param name="guideRowColDataEntity"> Row col entity </param>
        /// <returns></returns>
        public GuideRowColData EditGuideRowColColData(GuideRowColData guideRowColDataEntity)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Edit guide row col data value
        /// </summary>
        /// <param name="rowColId"> Gudie row col id </param>
        /// <param name="value"> Guide row col data value </param>
        /// <returns></returns>
        public GuideRowColData EditGuideRowColColDataValue(Guid rowColId, object value)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Rename row col data
        /// </summary>
        /// <param name="rowColId"> Row col id </param>
        /// <param name="rowColName"> Row col name </param>
        /// <returns></returns>
        public GuideRowColData RenameGuideRowColData(Guid rowColId, string rowColName)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Delete row col data
        /// </summary>
        /// <param name="rowColId"> Row col id </param>
        /// <returns></returns>
        public IQueryable<GuideRowColData> DeleteGuideRowColData(Guid rowColId)
        {
            throw new NotImplementedException();
        }
    }
}
