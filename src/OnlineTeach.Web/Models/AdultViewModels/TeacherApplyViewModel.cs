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
        public string Name { get; set; }
        public string RealName { get; set; }
        public string School { get; set; }
        public string ApplyReason { get; set; }
        public DateTime ApplyTime { get; set; }
        public int ApplyCount { get; set; }
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
