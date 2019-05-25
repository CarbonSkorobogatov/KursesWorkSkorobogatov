/*
 * Основная модель для реализации портфолио
 */
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace ProxSenceProject.Models
{
    public class Project
    {
        // Идентификатор
        public int ProjectId { get; set; }
        // Наименование проекта
        [Required(ErrorMessage ="Введите наименование проекта")]
        public string ProjectName { get; set; }
        // Описание проекта
        [Required(ErrorMessage = "Введите описание проекта")]
        public string ProjectDescription { get; set; }
        // Возможность купить проект
        [Required]
        [Range(0.01, double.MaxValue)]
        public decimal ProjectPrice { get; set; }
        // Категория проекта
        [Required(ErrorMessage = "Укажите категорию проекта")]
        public string ProjectCategory { get; set; }
        public string ImageName { get; set; }
        public string ImagePath { get; set; }
    }
}
