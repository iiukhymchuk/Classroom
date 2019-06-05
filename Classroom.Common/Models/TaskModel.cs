﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Classroom.Common.Models
{
    public class TaskModel
    {
        public Guid Id { get; set; }
        [Required]
        [StringLength(255, ErrorMessage = "Identifier too long (255 character limit).")]
        public string Name { get; set; }
        [StringLength(4000, ErrorMessage = "Identifier too long (4000 character limit).")]
        public string Description { get; set; }
        public DateTime? Modified { get; set; }
        public DateTime Created { get; set; }
        public Guid CourseId { get; set; }
    }
}
