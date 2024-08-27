using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Store.Models.Models
{
    public class ApiResponse
    {
        public bool Status { get; set; }
        public CCustomer Customer { get; set; }
        public CStore Store { get; set; }
        public CArticle Article { get; set; }
        public CStoresArticles StoresArticles { get; set; }
        public CShopingCart ShopingCart { get; set; }
        public ModelStateDictionary ModelState { get; set; }

    }
}
