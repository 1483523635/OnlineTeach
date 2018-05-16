using OnlineTeach.Web.Data.Cource;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineTeach.Web.Models.AdultViewModels
{
    public class CourceItemViewModel
    {
        [Key]
        public long Key { get; set; }
        [Display(Name = "课程名称")]
        public string Name { get; set; }
        [Display(Name = "教师名称")]
        public string TeacherName { get; set; }
        [Display(Name = "状态")]
        public CourceState State { get; set; }

    }
}
