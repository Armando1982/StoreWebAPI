using System.ComponentModel.DataAnnotations.Schema;

namespace Store.Models.Models
{
    public class CShopingCart
    {
        public int Id { get; set; }
        public DateTime DateMovement { get; set; }
        [ForeignKey("ArticleId")]
        public int ArticleId { get; set; }
        public CArticle CArticle { get; set; }
        [ForeignKey("CustomerId")]
        public int CustomerId { get; set; }
        public CCustomer CCustomer { get; set; }
        public int Count { get; set; }
    }
}
