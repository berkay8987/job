using MusteriSiparisUygulamasi.Data;
using MusteriSiparisUygulamasi.Models;

namespace MusteriSiparisUygulamasi.Scripts
{
    public class HandleComments
    {
        public void AddComment(int customerId, int productId, string comment)
        {
            using ApplicationContext context = new ApplicationContext();

            Comment c = new Comment()
            {
                CustomerId = customerId,
                ProductId = productId,
                CommentPrompt = comment
            };

            context.Comments.Add(c);
            context.SaveChanges();
        }

        public void ReadComments()
        {
            using ApplicationContext context = new ApplicationContext();
            var comments = context.Comments;

            Console.WriteLine("Id,CustomerId,ProductId,Comment");
            foreach (Comment c in comments)
            {
                Console.WriteLine($"{c.Id},{c.CustomerId},{c.ProductId},{c.CommentPrompt}");
            }
        }
    }
}
