using System.ComponentModel.DataAnnotations.Schema;

namespace SteamCopy.Models
{
    public class SteamGameDetail
    {
        public int Id { get; set; }

        public int SteamGameId { get; set; }

        [Column(TypeName = "decimal(6,2)")]
        public decimal Price { get; set; }

        [Column(TypeName="decimal(2,1)")]
        public decimal Rating { get; set; }

        public string Description { get; set; } = string.Empty;

        public string OverallQuality { get; set; } = string.Empty;
    }
}