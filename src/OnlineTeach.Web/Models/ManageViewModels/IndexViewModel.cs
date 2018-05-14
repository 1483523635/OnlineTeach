using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineTeach.Web.Models.ManageViewModels
{
    public class IndexViewModel
    {
        [Display(Name ="用户名")]
        public string Username { get; set; }

        public bool IsEmailConfirmed { get; set; }
        [Display(Name ="邮箱")]
        [Required(ErrorMessage ="{0}不能为空")]
        [EmailAddress]
        public string Email { get; set; }

        [Phone]
        [Display(Name = "手机号")]
        public string PhoneNumber { get; set; }

        public string StatusMessage { get; set; }
    }
}
