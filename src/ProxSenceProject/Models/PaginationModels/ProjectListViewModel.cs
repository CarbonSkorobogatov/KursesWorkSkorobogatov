using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProxSenceProject.Models.PaginationModels
{
    public class ProjectListViewModel
    {
        public IEnumerable<Project> ProjectData { get; set; }
        public Project project { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public string CurrentCategory { get; set; }
        public string ImageName { get; set; }

        [Required(ErrorMessage = "Please Upload a Valid Image File")]
        [DataType(DataType.Upload)]
        [Display(Name = "Upload Product Image")]
        [FileExtensions(Extensions = "jpg,png,gif,jpeg,bmp,svg")]
        public IFormFile Image { get; set; }
    }
}

