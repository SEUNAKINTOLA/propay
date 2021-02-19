using Microsoft.AspNetCore.Mvc;

namespace ProPay.Web.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class BaseApiController : Controller
    {
    }
}
