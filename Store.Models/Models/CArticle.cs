using System.ComponentModel.DataAnnotations;

namespace Store.Models.Models
{
    public class CArticle
    {
        [Key]
        public int ArticleId { get; set; }
        public string ArticleName { get; set; }
        public string ArticleDescription { get; set; }
        public double ArticlePrice { get; set; }
        public string ArticleImage { get; set; }
    }
}
