using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication.Models
{
    public class Game
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Название")]
        [MaxLength(150, ErrorMessage = "Превышена максимальная длина записи")]
        public string Title { get; set; }

        // [Required]
        [Display(Name = "Издатель")]
        [MaxLength(30, ErrorMessage = "Превышена максимальная длина записи")]
        public string Publisher { get; set; }

        // [Required]
        [Display(Name = "Жанр")]
        [MaxLength(30, ErrorMessage = "Превышена максимальная длина записи")]
        public string Genre { get; set; }

        //  [Required]
        //[DataType(DataType.Date)]
        [Display(Name = "Дата выхода")]
        public string Date { get; set; }

        // [Required]
        [Display(Name = "Цена")]
        public float Price { get; set; }

        // [Display(Name = "Cкидка")]
        public float Discount { get; set; }

        //  [Required]
        [Display(Name = "Изображение")]
        public string Img { get; set; }

        //   [Required]
        [Display(Name = "Описание")]
        [MaxLength(500, ErrorMessage = "Превышена максимальная длина записи")]
        public string Description { get; set; }

        //  [Required]
        [Display(Name = "ОС")]
        public string OS { get; set; }

        // [Required]
        [Display(Name = "Процессор")]
        public string CPU { get; set; }

        //  [Required]
        [Display(Name = "ОЗУ")]
        public string RAM { get; set; }

        //  [Required]
        [Display(Name = "Видеокарта")]
        public string VideoCard { get; set; }

        //  [Required]
        [Display(Name = "DirectX")]
        public string DirectX { get; set; }


        //   [Required]
        [Display(Name = "HDD")]
        public string HDD { get; set; }
    }
}