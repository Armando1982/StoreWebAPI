using System.ComponentModel.DataAnnotations;

namespace Store.Models.Models
{
    public class CCustomer
    {
        [Key]
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
    }
}
