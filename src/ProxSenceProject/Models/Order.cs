using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace ProxSenceProject.Models
{
    public class Order
    {
        [BindNever]
        public int OrderId { get; set; }
        [BindNever]
        public ICollection<CartLine> Lines { get; set; }
        [BindNever]
        public bool Passed { get; set; }
        [Required(ErrorMessage ="Пожалуйста, введите ваше имя")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Пожалуйста, введите ваше отчество")]
        public string SecondName { get; set; }
        [Required(ErrorMessage = "Пожалуйста, введите ваш телефон")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "Пожалуйста, введите ваше имейл")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string EmailAddress { get; set; }
        [Required(ErrorMessage = "Пожалуйста, введите страну в которой проживаете")]
        public string Country { get; set; }
        [Required(ErrorMessage = "Пожалуйста, введите город в котором проживаете")]
        public string Town { get; set; }
    }
}
