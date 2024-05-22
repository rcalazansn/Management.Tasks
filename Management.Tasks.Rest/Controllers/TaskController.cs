using Application.Interfaces;
using Application.Models;
using Application.Response;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;
using System.Net;

namespace Management.Tasks.Rest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TaskController : DefaultController
    {
        private readonly ILogger<TaskController> _logger;
        private readonly ITaskApplication _application;

        public TaskController(ITaskApplication application, ILogger<TaskController> logger)
        {
            _logger = logger;
            _application = application;
        }

        [HttpPost()]
        [SwaggerResponse((int)HttpStatusCode.Created, "Sucesso na requisição", typeof(BaseResponse<TaskCreateViewModel>))]

        public async Task<IActionResult> CreateTaskAsync([FromBody] TaskCreateViewModel request, CancellationToken ct)
        {
            var response = await _application.NewAsync(request, ct);

            return Result(response);
        }

        [HttpDelete("{id}")]
        [SwaggerResponse((int)HttpStatusCode.OK, "Sucesso na requisição", typeof(BaseResponse<int?>))]
        public IActionResult Delete([FromRoute] int id)
        {
            var response = _application.DeleteAsync(id);
            return Result(response.Result);
        }

        [HttpPatch("Delete/{id}")]
        [SwaggerResponse((int)HttpStatusCode.OK, "Sucesso na requisição", typeof(BaseResponse<int?>))]
        public IActionResult DeleteLogic([FromRoute] int id)
        {
            var response = _application.DeleteLogicAsync(id);
            return Result(response.Result);
        }

        [HttpGet("{id}")]
        [SwaggerResponse((int)HttpStatusCode.OK, "Sucesso na requisição", typeof(TaskCreateViewModel))]
        public async Task<IActionResult> GetByIdAsync([Required] int id, CancellationToken ct)
        {
            var response = await _application.GetByIdAsync(id);

            if (response.NoContent)
                return NoContent();

            return Result(response);
        }

        [HttpGet()]
        [SwaggerResponse((int)HttpStatusCode.OK, "Sucesso na requisição", typeof(TaskCreateViewModel))]
        public async Task<IActionResult> GetAllAsync(CancellationToken ct)
        {
            var response = await _application.GetAllAsync();

            return Result(response);
        }

        [HttpPut()]
        [SwaggerResponse((int)HttpStatusCode.OK, "Sucesso na requisição", typeof(BaseResponse<TaskUpdateViewModel>))]
        public IActionResult Update([FromBody] TaskUpdateViewModel model)
        {
            var response = _application.UpdateAsync(model);
            return Result(response.Result);
        }
    }
}
