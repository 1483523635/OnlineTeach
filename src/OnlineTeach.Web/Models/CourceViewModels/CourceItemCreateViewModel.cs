using OnlineTeach.Web.Data.Cource;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineTeach.Web.Models.CourceViewModels
{
    public class CourceItemCreateViewModel
    {
        [Key]
        public long Key { get; set; }
        [Display(Name = "课程名称")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string Name { get; set; }
        [Display(Name = "图片链接")]
        [DataType(DataType.ImageUrl)]
        public string ImageUrl { get; set; }
        [Display(Name = "开始时间")]
        [Required(ErrorMessage = "{0}不能为空")]
        [DataType(DataType.DateTime)]
        public DateTime StartTime { get; set; } = DateTime.Now;
        [Display(Name = "结束时间")]
        [Required(ErrorMessage = "{0}不能为空")]
        [DataType(DataType.DateTime)]
        public DateTime EndTime { get; set; } = DateTime.Now.AddMonths(1);
        [Display(Name = "适用对象")]
        [Required(ErrorMessage = "{0}不能为空")]
        [Range(1, 12, ErrorMessage = "{0}必须在{1}和{2}之间")]
        public GradeType Grade { get; set; }
        [Display(Name = "课程简介")]
        public string Content { get; set; }
        [Display(Name = "售价")]
        [Required(ErrorMessage = "{0}不能为空")]
        public double Price { get; set; } = 100;

        public string StateMessage { get; set; }
    }
}
