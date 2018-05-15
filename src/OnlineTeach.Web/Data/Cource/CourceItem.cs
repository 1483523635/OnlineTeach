using OnlineTeach.Web.Domains.AggrationRoot;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineTeach.Web.Data.Cource
{
    public class CourceItem : AggrationRoot<long>
    {
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public DateTime StartTime { get; set; } = DateTime.Now;
        public DateTime EndTime { get; set; } = DateTime.Now.AddMonths(1);
        public int BookCount { get; set; } = 0;
        public GradeType Grade { get; set; }
        public string Content { get; set; }
        public double Price { get; set; }
        public List<CourceOutLine> CourceOutLines { get; set; }
    }
    public enum GradeType
    {
        [Display(Name = "未定义")]
        undefine = 0,
        [Display(Name = "一年级")]
        One,
        [Display(Name = "二年级")]
        Two,
        [Display(Name = "三年级")]
        Three,
        [Display(Name = "四年级")]
        Four,
        [Display(Name = "五年级")]
        Five,
        [Display(Name = "六年级")]
        Six,
        [Display(Name = "七年级")]
        Seven,
        [Display(Name = "八年级")]
        Eight,
        [Display(Name = "九年级")]
        Nine,
        [Display(Name = "高一")]
        Ten,
        [Display(Name = "高二")]
        Eleven,
        [Display(Name = "高三")]
        twelve
    }
}
