using Microsoft.EntityFrameworkCore;
using SteamCopy.Models;

namespace SteamCopy.Data
{
    public class SteamCopyContext : DbContext
    {
        public SteamCopyContext(DbContextOptions<SteamCopyContext> options) : base(options) { }    

        public DbSet<SteamGame> SteamGames { get; set; }

        public DbSet<SteamGameDetail> SteamGameDetails { get; set; }
    }
}
