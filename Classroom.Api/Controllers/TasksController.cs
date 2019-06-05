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
    public class TasksController : ControllerBase
    {
        private readonly ITasksService service;

        public TasksController(ITasksService service)
        {
            this.service = service;
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<List<TaskModel>>> GetAll(Guid courseId, CancellationToken cancellationToken)
        {
            // add limitation for amount of courses fetched
            return await service.GetAllTasksAsync(courseId, cancellationToken);
        }

        [HttpPost("")]
        public async Task<ActionResult<Course>> Post(TaskModel model, CancellationToken cancellationToken)
        {
            // add model validation
            var result = await service.AddTaskAsync(model, cancellationToken);

            return CreatedAtRoute(new { controller = "tasks", id = result.Id }, result);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult> Put(Guid id, TaskModel model, CancellationToken cancellationToken)
        {
            // add model validation
            model.Id = id;
            var isUpdated = await service.UpdateTaskAsync(model, cancellationToken);

            if (!isUpdated)
                return NotFound();

            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> Delete(Guid id, CancellationToken cancellationToken)
        {
            var isDeleted = await service.DeleteTaskAsync(id, cancellationToken);

            if (!isDeleted)
                return NotFound();

            return NoContent();
        }
    }
}