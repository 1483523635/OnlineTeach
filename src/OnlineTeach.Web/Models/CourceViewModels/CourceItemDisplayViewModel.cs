using OnlineTeach.Web.Data.Cource;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineTeach.Web.Models.CourceViewModels
{
    public class CourceItemDisplayViewModel
    {
        [Key]
        public long Key { get; set; }
        [Display(Name="课程名称")]
        public string Name { get; set; }
        [Display(Name = "图片链接")]
        public string ImageUrl { get; set; }
        [Display(Name = "老师名称")]
        public string TeacherName { get; set; }
        [Display(Name = "使用对象")]
        public GradeType Grade { get; set; }
        [Display(Name = "预约数量")]
        public int BookCount { get; set; }
        [Display(Name = "价格")]
        public double Price { get; set; }
        [Display(Name = "大纲数量")]
        public int OutLineCount { get; set; }
    }
}
