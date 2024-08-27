using System.ComponentModel.DataAnnotations.Schema;

namespace Store.Models.Models
{
    public class CStoresArticles
    {
        public int Id { get; set; }
        public DateTime ArticleDate{ get; set; }
        public int StoreId { get; set; }
        [ForeignKey("StoreId")]
        public CStore CStore { get; set; }
        public int ArticleId { get; set; }
        [ForeignKey("ArticleId")]
        public CArticle CArticle { get; set; }
        public int Exists { get; set; }
    }
}
