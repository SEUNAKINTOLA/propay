using Microsoft.AspNetCore.Mvc;

namespace ProPay.Web.Api
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public abstract class BaseApiController : Controller
    {
    }
}
