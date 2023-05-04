using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusteriSiparisUygulamasi.Models
{
    public class Comment
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }

        public int ProductId { get; set; }

        public string CommentPrompt { get; set; } = null!;
    }
}
