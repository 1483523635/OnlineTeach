using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineTeach.Web.Models.ManageViewModels
{
    public class ChangeToTeacherViewModel
    {
        [Key]
        public long Id { get; set; }
        [Required(ErrorMessage = "{0}不能为空")]
        [Display(Name = "真实姓名")]
        [DataType(DataType.Text)]
        public string RealName { get; set; }
        [Display(Name = "任职学校")]
        [Required(ErrorMessage = "{0}不能为空")]
        [DataType(DataType.Text)]
        public string School { get; set; }
        [Display(Name = "申请理由")]
        [Required(ErrorMessage = "{0}不能为空")]
        [DataType(DataType.Text)]
        [StringLength(maximumLength: 100, ErrorMessage = "{0}长度必须大于{1}，小于{2}", MinimumLength = 10)]
        public string ApplyReason { get; set; }
        public string StatusMessage { get; set; }
    }
}
