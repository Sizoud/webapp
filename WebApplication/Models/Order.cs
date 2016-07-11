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

        [Required(ErrorMessage = "Выберете игру")]
        [Display(Name = "Игра")]
        public int? GameId { get; set; }

        public Game Game { get; set; }

        [Required(ErrorMessage = "Введите цену")]
        [Display(Name = "Цена")]
        public float Price { get; set; }

        [Required(ErrorMessage = "Введите своё имя")]
        [Display(Name = "Имя")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Введите номер Email")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Некорректный адрес")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Введите номер телефона")]
        [RegularExpression(@"^((80|\+375)[\- ]?)?(\(?\d{2}\)?[\- ]?)?[\d\- ]{7}$", ErrorMessage = "Некорректный номер телефона")]
        [Display(Name = "Номер телефона")]
        public string Phone { get; set; }

    }
}