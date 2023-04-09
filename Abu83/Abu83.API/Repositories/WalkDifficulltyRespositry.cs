using Abu83.API.Data;
using Abu83.API.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace Abu83.API.Repositories
{
    public class WalkDifficulltyRespositry : IWalkDifficulltyRespositry
    {
        private readonly NZWalksdbContext nZWalksdbContext;
        public WalkDifficulltyRespositry(NZWalksdbContext nZWalksdbContext)
        {
            this.nZWalksdbContext = nZWalksdbContext;
        }

        public async Task<WalkDifficulty> AddWalkDiffAsync(WalkDifficulty walkDifficulty)
        {
            walkDifficulty.Id= Guid.NewGuid();
            await nZWalksdbContext.AddAsync(walkDifficulty);
            await nZWalksdbContext.SaveChangesAsync();
            return walkDifficulty;
        }

        public async Task<WalkDifficulty> DeleteWalkDiffAsync(Guid id)
        {
            var exitwalkDiff = await nZWalksdbContext.WalkDifficulty.FindAsync(id);
            if (exitwalkDiff != null) 
            {
                nZWalksdbContext.WalkDifficulty.Remove(exitwalkDiff);
                await nZWalksdbContext.SaveChangesAsync();
                return exitwalkDiff;
            }
            return null;
           
          
        }

        public async  Task<IEnumerable<WalkDifficulty>> GetAllAsync()
        {
            return await nZWalksdbContext.WalkDifficulty.ToListAsync();

        }

        public async Task<WalkDifficulty> GetSingleWalkDiffAsync(Guid id)
        {
            return await nZWalksdbContext.WalkDifficulty.FirstOrDefaultAsync(x=>x.Id==id);
        }

        public async Task<WalkDifficulty> UpdateWalkDiffAsync(Guid id, WalkDifficulty walkDifficulty)
        {
            var exitwalkDifficulty = await nZWalksdbContext.WalkDifficulty.FirstOrDefaultAsync(x=> x.Id==id);
            if (exitwalkDifficulty==null)
            {
                return null;
            }
            exitwalkDifficulty.Code = walkDifficulty.Code;
            await nZWalksdbContext.SaveChangesAsync();
            return exitwalkDifficulty;
        }
    }
}
