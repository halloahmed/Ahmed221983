using Abu83.API.Data;
using Abu83.API.Models.Domain;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Abu83.API.Repositories
{
    public class WalkRepository : IWalkRepository
    {
        private readonly NZWalksdbContext nZWalksdbContext;
        public WalkRepository(NZWalksdbContext nZWalksdbContext)
        {
            this.nZWalksdbContext = nZWalksdbContext;
        }

        public async Task<Walk> AddAsync(Walk walk)
        {
            walk.Id = Guid.NewGuid();
            await nZWalksdbContext.Walks.AddAsync(walk);
            await nZWalksdbContext.SaveChangesAsync();
           
            return walk;
        }

        public async Task<Walk> DeleteAsync(Guid id)
        {
            var exitwalk = await nZWalksdbContext.Walks.FindAsync(id);
            if (exitwalk == null)
            {
                return null;
            }
            nZWalksdbContext.Walks.Remove(exitwalk);
            await nZWalksdbContext.SaveChangesAsync();
            return exitwalk;

        }

        //public NZWalksdbContext NZWalksdbContext { get; }

        public async Task<IEnumerable<Walk>> GetAllAsync()
        {
            return await 
                nZWalksdbContext.Walks
                .Include(x => x.Region)
                .Include(x => x.walkDifficulty)
                .ToListAsync();
        }

        public async Task<Walk> GetAsync(Guid id)
        {
            return await nZWalksdbContext.Walks
                .Include(x => x.Region)
                .Include(x => x.walkDifficulty)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Walk> UpdateAsync(Guid id, Walk walk)
        {
            var walkexit = await  nZWalksdbContext.Walks.FindAsync(id);
            if (walkexit != null) 
            {
                walkexit.Name= walk.Name;
                walkexit.Length= walk.Length;
                walkexit.WalkDifficultyId= walk.WalkDifficultyId;
                walkexit.RegionId= walk.RegionId;
                await nZWalksdbContext.SaveChangesAsync();
                return walkexit;
            }
            return null;
        }
    }
}
