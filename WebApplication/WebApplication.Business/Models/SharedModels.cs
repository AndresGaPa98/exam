using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication.Business.Models
{
    internal class SharedModels
    {
    }
    public class PaginationModel
    {
        public int Size { get; set; }
        public int Index { get; set; }
        public int? Id { get; set; }
        public string? ClientId { get; set; }
    }
}
