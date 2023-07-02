using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication.Business.Models
{
    public class ArticleModel
    {
        public string Code { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string UrlImage { get; set; }
        public int Stock { get; set; }
        public int? Amount { get; set; }
    }
    public class ArticleUpdateModel : ArticleModel
    {
        public int Id { get; set; }
    }
    public class ArticleStoreModel
    {
        public int StoreId { get; set; }
        public ArticleModel Article { get; set; }
    }
    public class ArticleStoreUpdateModel
    {
        public int Id { get; set; }
        public int StoreId { get; set; }
        public ArticleUpdateModel Article { get; set; }
    }
    public class ArticleStoreGetModel{
        public int Id { get; set; }
        public int StoreId { get; set; }
        public int ArticleId { get; set; }
        public DateTime Date { get; set; }
        public ArticleUpdateModel Article { get; set; }
    }
    public class ArticleStorePaginationModel
    {
        public int Total { get; set; }
        public List<ArticleStoreGetModel> Data { get; set; }
    }
}
