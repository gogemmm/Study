using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Model
{
    /**
     * Login 信息数据实体类
     */
    public class LoginInfo
    {
        // 姓名
        private String username;
        // 密码
        private String password;
        // 权限级别
        private String privilege;

        public String getUsername() 
        { 
            return this.username;
        }
        public void setUsername(String username)
        {
            this.username = username;
        }

        public String getPassword()
        {
            return this.password;
        }
        public void setPassword(String password) 
        { 
            this.password = password;
        }

        public String getPrivilege()
        {
            return this.privilege;
        }
        public void setPrivilege(String privilege) 
        { 
            this.privilege = privilege;
        }
    }
}
