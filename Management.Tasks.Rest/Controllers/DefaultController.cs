using Application.Response;
using Microsoft.AspNetCore.Mvc;

namespace Management.Tasks.Rest.Controllers
{
    public class DefaultController : ControllerBase
    {
        public IActionResult Result<T>(BaseResponse<T> response) =>
            StatusCode((int)response.GetStatusCode(), response);
    }
}
