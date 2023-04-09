using Abu83.API.Models.Domain;
using Abu83.API.Models.DTO;

namespace Abu83.API.Repositories
{
    public interface IWalkDifficulltyRespositry
    {
        Task<IEnumerable<Models.Domain.WalkDifficulty>> GetAllAsync();
     
        Task<Models.Domain.WalkDifficulty> GetSingleWalkDiffAsync(Guid id);
        Task<Models.Domain.WalkDifficulty> AddWalkDiffAsync(Models.Domain.WalkDifficulty walkDifficulty);
        Task<Models.Domain.WalkDifficulty> UpdateWalkDiffAsync(Guid id , Models.Domain.WalkDifficulty walkDifficulty);
        Task<Models.Domain.WalkDifficulty> DeleteWalkDiffAsync(Guid id);
    }
}
