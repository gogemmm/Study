using Demo.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Data;
using System.Data.SqlClient;

namespace Demo
{
    public class BLL
    {
        DAL dal = new DAL();


        //添加事件
        public void AddStudent(string Id, string Name, string Class, string Birthday, string JG) 
        {
            if (Id != null || Name != null || Class != null || Birthday != null || JG != null)
            {
                string sql = $"insert into Student(Id, Name, Class, Birthday, JG, Password)values('{Id}','{Name}','{Class}','{Birthday}','{JG}','000000');";
                MessageBox.Show("添加成功！", "提示");
                dal.Excute(sql);
            }
            else {
                MessageBox.Show("不可以有空项哦~","提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);            
            }
            
        }




        //让表显示数据
        public IDataReader showTable(string table) 
        {
            DAL dAL = new DAL();
            string sql = $"select * from {table}";
            IDataReader dr = dAL.read(sql);
            return dr;

        }






        //退出事件
        public void FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("是否要退出程序？", "系统提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                e.Cancel = false;     //关闭窗体

                Application.Exit(); //退出整个程序
                
            }
            else
                e.Cancel = true;     //返回窗体
        }




        private bool checkUser(string table, String username, String password)
        {
            string sql = $"select Name,Password from {table} where Name = '{username}' and Password = '{password}'";
            IDataReader dr = dal.read(sql);
            if (dr.Read())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool login(LoginInfo loginInfo)
        {
            if (loginInfo.getUsername() == "" || loginInfo.getPassword() == "" || loginInfo.getPrivilege() == "")
            {
                MessageBox.Show("输入不完整，请检查后输入", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (loginInfo.getPrivilege() == "学生")
            {
                return this.checkUser("Student", loginInfo.getUsername(), loginInfo.getPassword());
            }
            else if (loginInfo.getPrivilege() == "老师")
            {
                return this.checkUser("Teacher", loginInfo.getUsername(), loginInfo.getPassword());
            }
            else if (loginInfo.getUsername() == "admin" && loginInfo.getPassword() == "admin")
            {
                return true;
            }
            return false;
        }
    }
}
