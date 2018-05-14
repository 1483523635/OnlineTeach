using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineTeach.Web.Models.AccountViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage ="{0}不能为空")]
        [EmailAddress(ErrorMessage ="{0}地址无效")]
        [Display(Name = "邮箱")]
        public string Email { get; set; }

        [Required(ErrorMessage = "{0}不能为空")]
        [StringLength(100, ErrorMessage = " {0}长度必须在 {2} 和 {1} 之间", MinimumLength = 6)]
        [DataType(DataType.Password,ErrorMessage ="密码必须包含一个大写字母和一个小写字母")]
        [Display(Name = "密码")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "确认密码")]
        [Compare("Password", ErrorMessage = "两次输入的密码不一致")]
        public string ConfirmPassword { get; set; }
    }
}
