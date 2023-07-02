using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace WebApplication.Controllers
{
    [Authorize]
    public class BaseController : ControllerBase
    {
        public string USER_ID { get => User.FindFirstValue(ClaimTypes.Sid); }
    }
}
