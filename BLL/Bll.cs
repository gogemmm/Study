using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace BLL
{
    public class Bll
    {
        DAL dAL = new DAL();
        private bool checkUser(string table,string username,string password) 
        {
            string sql = $"select Name,Password from {table} where Name = '{username}' and Password = '{password}'";
            IDataReader dr = dAL.read(sql) ;
            if (dr.Read()) 
            {
                return true ;
            }else {
                return false ;
            }
        }


        public bool login(LoginInfo loginInfo)
        {
            if (loginInfo.UserName == "" || loginInfo.PassWord == "" || loginInfo.Role == "") 
            {
                return false;
            }
            if (loginInfo.Role == "Student")
            {
                return this.checkUser("Student", loginInfo.UserName, loginInfo.PassWord);
            }
            else if (loginInfo.Role == "Teacher")
            {
                return this.checkUser("Teacher", loginInfo.UserName, loginInfo.PassWord);
            }
            else if (loginInfo.Role == "Admin")
            {
                return true;
            }else { return false ;}
            return false;
        }
    }
}
