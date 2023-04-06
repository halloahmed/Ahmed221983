
using Abu83.API.Models.Domain;

namespace Abu83.API.Repositories
{
    public interface IRegionRepository
    {
       Task<IEnumerable<Region>>GetAllAsync();
       Task<Region>GetAsync(Guid id);
       Task<Region> AddRegionAsync(Region region );
       Task<Region>deleteAnync(Guid id);
       Task<Region> UpdateAsync(Guid id, Region region);
    }
}
