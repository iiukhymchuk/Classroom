using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Classroom.Services;
using Classroom.Services.Models;
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
        public async Task<ActionResult<List<ClassModel>>> GetAll(CancellationToken cancellationToken)
        {
            return await service.GetClassesAsync(cancellationToken);
        }

        [HttpGet("id: guid")]
        public async Task<ActionResult<ClassModel>> Get(Guid id, CancellationToken cancellationToken)
        {
            // Add not found
            return await service.GetByIdAsync(id, cancellationToken);
        }

        [HttpPost("")]
        public async Task<ActionResult<ClassModel>> Post(ClassModel classModel, CancellationToken cancellationToken)
        {
            if (classModel is null)
            {
                return BadRequest(); // Move to validators
            }
            var result = await service.AddClassAsync(classModel, cancellationToken);

            if (result == 1)
            {
                var url = Url.RouteUrl(new { controller = "classes", id = classModel.Id });
                return Created(url, classModel);
            }

            return null; // remove after thinking on responses
        }
    }
}