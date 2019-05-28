using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Classroom.Common;
using Classroom.Common.Models.Api;
using Classroom.Services;
using Microsoft.AspNetCore.Mvc;

namespace Classroom.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ClassesController : ControllerBase
    {
        private readonly string controllerPath;
        private readonly IClassesService service;

        public ClassesController(IClassesService service)
        {
            var controllerName = nameof(ClassesController);
            controllerPath = controllerName.Substring(0, controllerName.IndexOf("Controller")).ToLower();
            this.service = service;
        }

        [HttpGet("")]
        public async Task<ActionResult<List<ClassModel>>> GetAll(CancellationToken cancellationToken)
        {
            // add limitation for amount of classes fetched 
            var result = await service.GetAllClassesAsync(cancellationToken);
            return result.Select(x => x.ToApiModel()).ToList();
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<ClassModel>> Get(Guid id, CancellationToken cancellationToken)
        {
            var model = await service.GetClassByIdAsync(id, cancellationToken);

            if (model is null)
                return NotFound();

            return model.ToApiModel();
        }

        [HttpPost("")]
        public async Task<ActionResult<ClassModel>> Post(ClassInputModel model, CancellationToken cancellationToken)
        {
            // add model validation
            var serviceModel = await service.AddClassAsync(model.ToServicesModel(), cancellationToken);
            var result = serviceModel.ToApiModel();

            return CreatedAtAction(nameof(Get), new { id = result.Id }, result);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult> Put(Guid id, ClassInputModel model, CancellationToken cancellationToken)
        {
            // add model validation
            var isUpdated = await service.UpdateClassAsync(id, model.ToServicesModel(), cancellationToken);

            if (!isUpdated)
                return NotFound();

            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> Delete(Guid id, CancellationToken cancellationToken)
        {
            var isDeleted = await service.DeleteClassAsync(id, cancellationToken);

            if (!isDeleted)
                return NotFound();

            return NoContent();
        }
    }
}