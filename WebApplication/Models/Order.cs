using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class Order
    {
        public int Id { get; set; }

        public int GameId { get; set; }
        public Game Game { get; set; }
        public int Price { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }


        //// [Required]
        //[Display(Name = "Издатель")]
        //[MaxLength(30, ErrorMessage = "Превышена максимальная длина записи")]
        //public string Publisher { get; set; }

        //// [Required]
        //[Display(Name = "Жанр")]
        //[MaxLength(30, ErrorMessage = "Превышена максимальная длина записи")]
        //public string Genre { get; set; }

        ////  [Required]
        ////[DataType(DataType.Date)]
        //[Display(Name = "Дата выхода")]
        //public string Date { get; set; }

        //// [Required]
        //[Display(Name = "Цена")]
        //public float Price { get; set; }

        //// [Display(Name = "Cкидка")]
        //public float Discount { get; set; }

        ////  [Required]
        //[Display(Name = "Изображение")]
        //public string Img { get; set; }

        ////   [Required]
        //[Display(Name = "Описание")]
        //[MaxLength(500, ErrorMessage = "Превышена максимальная длина записи")]
        //public string Description { get; set; }

        ////  [Required]
        //[Display(Name = "ОС")]
        //public string OS { get; set; }

        //// [Required]
        //[Display(Name = "Процессор")]
        //public string CPU { get; set; }

        ////  [Required]
        //[Display(Name = "ОЗУ")]
        //public string RAM { get; set; }

        ////  [Required]
        //[Display(Name = "Видеокарта")]
        //public string VideoCard { get; set; }

        ////  [Required]
        //[Display(Name = "DirectX")]
        //public string DirectX { get; set; }


        ////   [Required]
        //[Display(Name = "HDD")]
        //public string HDD { get; set; }
    }
}