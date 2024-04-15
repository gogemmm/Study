using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebDemo
{
    /**
     * Login 信息数据实体类
     */
    public class LoginInfo
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}