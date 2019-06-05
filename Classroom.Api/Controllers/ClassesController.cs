using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Classroom.Common.Models;
using Classroom.Services;
using Microsoft.AspNetCore.Mvc;

namespace Classroom.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ClassesController : ControllerBase
    {
        private readonly IClassesService service;

        public ClassesController(IClassesService service)
        {
            this.service = service;
        }

        [HttpGet("")]
        public async Task<ActionResult<List<Class>>> GetAll(CancellationToken cancellationToken)
        {
            // add limitation for amount of classes fetched 
            return await service.GetAllClassesAsync(cancellationToken);
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<Class>> Get(Guid id, CancellationToken cancellationToken)
        {
            var model = await service.GetClassByIdAsync(id, cancellationToken);

            if (model is null)
                return NotFound();

            return model;
        }

        [HttpPost("")]
        public async Task<ActionResult<Class>> Post(Class model, CancellationToken cancellationToken)
        {
            // add model validation
            var result = await service.AddClassAsync(model, cancellationToken);

            return CreatedAtRoute(new { controller = "classes", id = result.Id }, result);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult> Put(Guid id, Class model, CancellationToken cancellationToken)
        {
            // add model validation
            var isUpdated = await service.UpdateClassAsync(id, model, cancellationToken);

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