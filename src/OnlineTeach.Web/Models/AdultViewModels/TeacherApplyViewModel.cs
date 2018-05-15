using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineTeach.Web.Models.AdultViewModels
{
    public class TeacherApplyViewModel
    {
        [Key]
        public long Id { get; set; }
        [Display(Name="用户名")]
        public string Name { get; set; }
        [Display(Name = "真实姓名")]
        public string RealName { get; set; }
        [Display(Name = "任职学校")]
        public string School { get; set; }
        [Display(Name = "申请理由")]
        public string ApplyReason { get; set; }
        [Display(Name = "申请时间")]
        public DateTime ApplyTime { get; set; }
        [Display(Name = "申请次数")]
        public int ApplyCount { get; set; } 
        [Display(Name = "申请状态")]
        public ApplyStatu ApplyStatus { get; set; }
    }
    public enum ApplyStatu
    {
        [Display(Name = "未定义")]
        UnDefine = 0,
        [Display(Name = "申请中")]
        Applying,
        [Display(Name = "拒绝")]
        Deny,
        [Display(Name = "通过")]
        Pass
    }
}
