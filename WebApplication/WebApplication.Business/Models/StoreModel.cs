using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication.Business.Models
{
    public class StoreModel
    {
        public string BranchName { get; set; }
        public string Address { get; set; }
    }
    public class StoreUpdateModel : StoreModel
    {
        public int StoreId { get; set; }
    }
    public class StorePaginationModel  {
        public int Total { get; set; }
        public List<StoreUpdateModel> Data { get; set; }
    }
}
