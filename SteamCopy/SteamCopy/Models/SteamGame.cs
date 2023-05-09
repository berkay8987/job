namespace SteamCopy.Models
{
    public class SteamGame
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public SteamGameDetail SteamGameDetail { get; set; } = null!;
    }
}
