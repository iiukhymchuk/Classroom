using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
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
            return await service.GetClasses(cancellationToken);
        }
    }
}