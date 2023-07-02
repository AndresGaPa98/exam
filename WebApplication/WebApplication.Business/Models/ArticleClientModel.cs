using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication.Business.Models
{
    public class ArticleClientModel
    {
        public int ArticleId { get; set; }
        public string ClientId { get; set; }
        public int Amount { get; set; }
    }
    public class ArticleClientUpdateModel : ArticleClientModel
    {
        public int Id { get; set; }
    }
    public class ArticleClientCountModel
    {
        public int Total { get; set; }
    }
    public class ArticleClientGetModel
    {
        public int Id { get; set; }
        public int ArticleId { get; set; }
        public DateTime Date { get; set; }
        public ArticleUpdateModel Article { get; set; }
    }
    public class ArticleClientPaginationModel
    {
        public int Total { get; set; }
        public List<ArticleClientGetModel> Data { get; set; }
    }
    public class ArticleDeleteResponse
    {
        public bool Status { get; set; }
        public string Message { get; set; }
    }
}
