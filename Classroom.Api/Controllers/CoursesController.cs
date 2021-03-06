﻿using Classroom.Common.Models;
using Classroom.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Classroom.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly ICoursesService service;

        public CoursesController(ICoursesService service)
        {
            this.service = service;
        }

        [HttpGet("")]
        public async Task<ActionResult<List<Course>>> GetAll(CancellationToken cancellationToken)
        {
            // add limitation for amount of courses fetched
            return await service.GetAllCoursesAsync(cancellationToken);
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<Course>> Get(Guid id, CancellationToken cancellationToken)
        {
            var model = await service.GetCourseByIdAsync(id, cancellationToken);

            if (model is null)
                return NotFound();

            return model;
        }

        [HttpPost("")]
        public async Task<ActionResult<Course>> Post(Course model, CancellationToken cancellationToken)
        {
            // add model validation
            var result = await service.AddCourseAsync(model, cancellationToken);

            return CreatedAtRoute(new { controller = "courses", id = result.Id }, result);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult> Put(Guid id, Course model, CancellationToken cancellationToken)
        {
            // add model validation
            var isUpdated = await service.UpdateCourseAsync(id, model, cancellationToken);

            if (!isUpdated)
                return NotFound();

            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> Delete(Guid id, CancellationToken cancellationToken)
        {
            var isDeleted = await service.DeleteCourseAsync(id, cancellationToken);

            if (!isDeleted)
                return NotFound();

            return NoContent();
        }
    }
}