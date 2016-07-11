using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication.Models.GameModels
{
    public class Genre
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Заполните поле")]
        [Display(Name = "Жанр")]
        [MaxLength(150, ErrorMessage = "Превышена максимальная длина записи")]
        public string Title { get; set; }
    }
}