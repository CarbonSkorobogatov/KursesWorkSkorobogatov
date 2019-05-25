using System;
using System.ComponentModel.DataAnnotations;

namespace ProxSenceProject.Models
{
    public class News
    {
        public int NewsId { get; set; }
        public string Title { get; set; }
        public string NewsDescription { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime dateNewsTime { get; set; }
    }
}
