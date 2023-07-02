using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication.Entities.Entities
{
    public class Article
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ArticleId { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string UrlImage { get; set; }
        public int Stock { get; set; }
        public virtual List<Store> Stores { get; } = new();
        public virtual List<Client> Clients { get; } = new();
    }
    public class ArticleStore
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int StoreId { get; set; }
        public virtual Article Article { get; set; }
        public int ArticleId { get; set; }
        public DateTime Date { get; set; }

    }
    public class ArticleClient
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int ArticleId { get; set; }
   
        public virtual Article Article { get; set; }
        public string ClientId { get; set; }
        public DateTime Date { get; set; }
        public int Amount { get; set; }
    }
}
