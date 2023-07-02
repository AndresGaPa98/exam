using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication.Business.Models
{
    internal class AuthModel
    {
    }
    public class ClaimUser
    {
        public string AccessToken { get; set; }
    }
    public class AccountRequestModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
    public class AccountResponseModel
    {
        public bool Autentificado { get; set; }
        public string Role { get; set; }
        public string AccessToken { get; set; }
        public string UserId { get; set; }
    }
    public class LogoutModel 
    {
        public string Message { get; set; }
    }
}
