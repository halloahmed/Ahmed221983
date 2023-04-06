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

        public async Task<Region> AddRegionAsync(Region region)
        {
            region.Id = Guid.NewGuid();
            await nZWalksdbContext.AddAsync(region);    
            await nZWalksdbContext.SaveChangesAsync();
            return region;
        }

        public async Task<Region> deleteAnync(Guid id)
        {
           var region = await nZWalksdbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);
            if (region == null)
            {
                return null;
            }
            // Delete the Region
            nZWalksdbContext.Regions.Remove(region);
            await nZWalksdbContext.SaveChangesAsync();
            return region;  
        }

        public async Task<IEnumerable<Region>> GetAllAsync()
        {
            return await nZWalksdbContext.Regions.ToListAsync();            
        }

        public async Task<Region> GetAsync(Guid id)
        {
            return await nZWalksdbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Region> UpdateAsync(Guid id, Region region)
        {
            var exitregion = await nZWalksdbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);
            if (exitregion == null)
            {
                return null;
            }
            exitregion.Code= region.Code;
            exitregion.Area= region.Area;
            exitregion.Name= region.Name;
            exitregion.Lat= region.Lat;
            exitregion.Long= region.Long;
            exitregion.Population= region.Population;
            nZWalksdbContext.SaveChangesAsync();
            return exitregion;
        }
    }
}
