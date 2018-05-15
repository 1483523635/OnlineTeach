using OnlineTeach.Web.Domains.AggrationRoot;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineTeach.Web.Data.Cource
{
    public class CourceOutLine : AggrationRoot<long>
    {
        public string OUtlineName { get; set; }
        public string TeacherName { get; set; }
        public DateTime StartDate { get; set; }
        public LearnStatus LearnStatu { get; set; }
        public long CourceId { get; set; }
        [ForeignKey(nameof(CourceId))]
        public CourceItem CourceItem { get; set; }


    }
    public enum LearnStatus
    {
        [Display(Name = "未定义")]
        Undefine = 0,
        [Display(Name = "未开始")]
        UnStart,
        [Display(Name = "正在进行中")]
        Starting,
        [Display(Name = "已结束")]
        Started

    }
}
