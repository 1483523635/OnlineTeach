using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineTeach.Web.Models.AccountViewModels
{
    public class ForgotPasswordViewModel
    {
        [Required(ErrorMessage ="{0}不能为空")]
        [EmailAddress]
        [Display(Name ="邮箱地址")]
        public string Email { get; set; }
    }
}
