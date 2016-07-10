using System;
using System.ComponentModel.DataAnnotations;
using WebApplication.Models.GameModels;

namespace WebApplication.Models
{
    public class Game
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Введите название игры")]
        [Display(Name = "Название")]
        [MaxLength(150, ErrorMessage = "Превышена максимальная длина записи")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Введите имя издателя")]
        [Display(Name = "Издатель")]
        [MaxLength(30, ErrorMessage = "Превышена максимальная длина записи")]
        public string Publisher { get; set; }

        [Required(ErrorMessage = "Выберете жанр")]
        [Display(Name = "Жанр")]
        public int GenreId { get; set; }

        public Genre Genre { get; set; }

        [Required(ErrorMessage = "Введите дату выхода")]
        //[DataType(DataType.Date)]
        [RegularExpression(@"(0[1-9]|[12][0-9]|3[01])[.](0[1-9]|1[012])[.](19|20)\d\d", ErrorMessage = "Некорректная дата")]
        [Display(Name = "Дата выхода. Формат: 23.03.2015")]
        public string Date { get; set; }

        [Required(ErrorMessage = "Введите цену")]
        [Range(1, 100000, ErrorMessage = "Недопустимая цена")]
        [Display(Name = "Цена")]
        public float Price { get; set; }

        [Required(ErrorMessage = "Введите скидку. от 0% до 100%")]
        [Range(0, 100, ErrorMessage = "Введите скидку. от 0% до 100%")]
        [Display(Name = "Cкидка")]
        public float Discount { get; set; }

        //  [Required]
        [Display(Name = "Изображение")]
        public string Img { get; set; }

        [Required(ErrorMessage = "Введите описание")]
        [Display(Name = "Описание")]
        [MaxLength(500, ErrorMessage = "Превышена максимальная длина записи")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Выберете минимальную ОС")]
        [Display(Name = "Операционная система")]
        public int OSId { get; set; }
        public OS OS { get; set; }

        [Required(ErrorMessage = "Выберете минимальный Процессор")]
        [Display(Name = "Процессор")]
        public int CPUId { get; set; }
        public CPU CPU { get; set; }

        [Required(ErrorMessage = "Выберете минимальный объем ОЗУ")]
        [Display(Name = "Объем ОЗУ. Гбайт")]
        public int RAMId { get; set; }
        public RAM RAM { get; set; }

        [Required(ErrorMessage = "Выберете видеокарту")]
        [Display(Name = "Видеокарта")]
        public int VideoCardId { get; set; }
        public VideoCard VideoCard { get; set; }

        [Required(ErrorMessage = "Выберете DirectX")]
        [Display(Name = "DirectX")]
        public int DirectXId { get; set; }
        public DirectX DirectX { get; set; }

        [Required(ErrorMessage = "Выберете объем требуемого пространства на диске")]
        [Display(Name = "HDD. ГБайт")]
        [Range(0.1, 100000, ErrorMessage = "Недопустимое значение")]
        public float HDD { get; set; }
    }
}