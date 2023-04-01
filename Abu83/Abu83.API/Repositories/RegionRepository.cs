using Abu83.API.Data;
using Abu83.API.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace Abu83.API.Repositories
{
    public class RegionRepository : IRegionRepository
    {
        private readonly NZWalksdbContext nZWalksdbContext;

        public RegionRepository(NZWalksdbContext nZWalksdbContext)
        {
            this.nZWalksdbContext = nZWalksdbContext;
        }
        public IEnumerable<Region> GetAll()
        {
            return nZWalksdbContext.Regions.ToList();            
        }
       
    }
}
