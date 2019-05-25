using Microsoft.AspNetCore.Http;//was dismatch with AdminController method
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProxSenceProject.Models.PaginationModels
{
    public class ProjectImagesViewModel
    {
        //public IEnumerable<Project> ProjectData { get; set; }
        public Project project { get; set; }

        [Required(ErrorMessage = "Please Upload a Valid Image File")]
        [DataType(DataType.Upload)]
        [Display(Name = "Upload Product Image")]
        //[FileExtensions(Extensions = "jpg,png,gif,jpeg,bmp,svg")]
        public IFormFile ImageName { get; set; } //Image
    }
}