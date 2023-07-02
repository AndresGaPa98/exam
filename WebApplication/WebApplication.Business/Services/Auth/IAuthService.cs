using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.Business.Models;
using WebApplication.Entities.Entities;

namespace WebApplication.Business.Services.Auth
{
    public interface IAuthService
    {
        public Task<ClaimUser> GetToken(Client user, IList<string> roles);
    }
}
