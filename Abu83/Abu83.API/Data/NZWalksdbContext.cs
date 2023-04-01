using Abu83.API.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace Abu83.API.Data
{
    public class NZWalksdbContext:DbContext
    {
        public NZWalksdbContext(DbContextOptions<NZWalksdbContext> options):base(options)        
        {
                
        }

        public DbSet<Region> Regions { get; set; }

        public DbSet<Walk> Walks { get; set; }
        public DbSet<WalkDifficulty> WalkDifficulty { get; set; }

    }
  }
