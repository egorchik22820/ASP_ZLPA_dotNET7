﻿using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ASP_ZALUUPA.Domain.Entities
{
    public abstract class EntityBase
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Заполните название"), Display(Name = "Название"), MaxLength(200)]
        public string? Title { get; set; }

        public DateTime DateCreated { get; set; } = DateTime.UtcNow;
    }
}
