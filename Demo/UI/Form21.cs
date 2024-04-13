using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Demo.Model;

namespace Demo
{
    public partial class Form21 : Form
    {
        
       
        DAL dAL = new DAL();
        string[] str = new string[5];
        BLL bLL = new BLL();
        //Model.StudentInfo studentInfo = new StudentInfo();
        


        public Form21()
        {
            InitializeComponent();
            button3.Visible = false;//选择添加学生，隐藏按钮button3（修改）

        }

        


        //用于修改，参数为一个数组
        public Form21(string[] a)
        {
            InitializeComponent();
            for (int i = 0; i < 5; i++)
            {
                str[i] = a[i];
            }
            textBox1.Text = str[1];
            textBox2.Text = str[0];
            textBox3.Text = str[2];
            textBox4.Text = str[3];
            textBox5.Text = str[4];
            button2.Visible = false;//选择修改学生，隐藏按钮button1（保存）

        }

        private void Form21_Load(object sender, EventArgs e)
        {

        }

        //添加
        private void button2_Click(object sender, EventArgs e)
        {
            StudentInfo studentInfo = new StudentInfo
            {
                stuName = textBox1.Text,
                stutId = textBox2.Text,
                stuClass = textBox3.Text,
                stuBirthday = textBox4.Text,
                stuJG = textBox5.Text
            };
            Form2 form2 = new Form2();
            bLL.AddStudent( studentInfo.stutId, studentInfo.stuName, studentInfo.stuClass, studentInfo.stuBirthday, studentInfo.stuJG);
            this.Close();
            form2.table();

        }

         void button3_Click(object sender, EventArgs e)
        {

            bool flag = false;
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "") 
            {
                MessageBox.Show("不能有空项，请检查","提示",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
            else
            {
                if (textBox1.Text != str[1]) //姓名
                {
                    string sql = $"update Student set Name='{textBox1.Text}' where Id = '{str[0]}'and Name = '{str[1]}'";
                    dAL.Excute(sql);
                    str[1] = textBox1.Text;

                }
                if (textBox2.Text != str[0]) //id
                {
                    string sql = $"update Student set Id='{textBox2.Text}' where Id = '{str[0]}'and Name = '{str[1]}'";
                    dAL.Excute(sql);
                    str[0] = textBox2.Text;
                }
                if (textBox3.Text != str[2]) //class
                {
                    string sql = $"update Student set Class='{textBox3.Text}' where Id = '{str[0]}'and Name = '{str[1]}'";
                    dAL.Excute(sql);
                    str[2] = textBox3.Text;
                }
                if (textBox4.Text != str[3]) //出生日期
                {
                    string sql = $"update Student set Birthday='{textBox4.Text}' where Id = '{str[0]}'and Name = '{str[1]}'";
                    dAL.Excute(sql);
                    str[3] = textBox4.Text;
                }
                if (textBox5.Text != str[4]) //籍贯
                {
                    string sql = $"update Student set JG='{textBox5.Text}' where Id = '{str[0]}'and Name = '{str[1]}'";
                    dAL.Excute(sql);
                    str[4] = textBox5.Text;
                }
                flag = true;
                if (flag == true)
                {
                    Form2 form2 = (Form2)this.Owner;//不理解
                    MessageBox.Show("修改成功！");
                    this.Close();
                    form2.table();

                }
                
            }
            
        }
    }
}
