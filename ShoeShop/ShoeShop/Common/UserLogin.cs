using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoeShop.Common
{
    [Serializable]
    public class UserLogin
    {
        public string IdLogin { get; set; }
        public string UserName { get; set; }
    }
}