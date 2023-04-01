
using Abu83.API.Models.Domain;

namespace Abu83.API.Repositories
{
    public interface IRegionRepository
    {
        IEnumerable<Region>GetAll();
    }
}
