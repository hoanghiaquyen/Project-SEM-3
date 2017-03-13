﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShoeShop.Areas.Admin.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage =" Bạn chưa nhập tên đăng nhập!")]
        public string UserName { get; set; }

        [Required(ErrorMessage = " Bạn chưa nhập mật khẩu!")]
        public string Password { get; set; }
        public bool Remember { get; set;}
    }
}