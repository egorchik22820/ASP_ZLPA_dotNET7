﻿using ASP_ZALUUPA.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace ASP_ZALUUPA.Domain.Entities
{
    public class Service : EntityBase
    {
        [Display(Name = "Выберете категорию, к которой относится услуга")]
        public int? ServiceCategoryId { get; set; }
        public ServiceCategory? ServiceCategory { get; set; }


        [Display(Name = "Краткое описание"), MaxLength(3_000)]
        public string? DescriptionShort { get; set; }


        [Display(Name = "Описание"), MaxLength(100_000)]
        public string? Description { get; set; }


        [Display(Name = "Титульная картинка"), MaxLength(300)]
        public string? Photo {  get; set; }

        public string PhotoUrl => $"https://localhost:7088/img/{Photo}";


        [Display(Name = "Тип услуги")]
        public ServiceTypeEnum? Type { get; set; }

        public int? ServicePhotoId { get; set; }
        public ServicePhoto? ServicePhoto { get; set; }
    }
}
