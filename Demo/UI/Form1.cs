using Demo.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Demo
{
    public partial class Form1 : Form
    {
        
        /* 控件逻辑 */
        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (pictureBox1.Location.X < 150)
            {
                pictureBox1.Location = new Point(pictureBox1.Location.X + 1, pictureBox1.Location.Y);
            }
            else
            {
                timer1.Stop();
            }
        }
       

        BLL bll = new BLL();

        //登录事件
        private void button1_Click(object sender, EventArgs e)
        {
            bool flag = true;
            LoginInfo loginInfo = new LoginInfo();
            loginInfo.setUsername(textBox1.Text);
            loginInfo.setPassword(textBox3.Text);
            loginInfo.setPrivilege(comboBox1.Text);
            if (this.bll.login(loginInfo) != false)
            {
                timer1.Start();
                textBox1.Visible = false;
                textBox3.Visible = false;
                label2.Visible = false;
                label3.Visible = false;
                label4.Visible = false;
                comboBox1.Visible = false;
                button1.Visible = false;
                button2.Visible = false;
                
            }
            else {
                flag = false;
                MessageBox.Show("出错了捏~", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            if (comboBox1.Text == "学生" && flag == true)
                {   
                    string sql = $"select * from Student where Name = '{textBox1.Text}' and password = '{textBox3.Text}'";
                    MessageBox.Show($"{sql}");
                    DAL dAL = new DAL();
                    IDataReader dr = dAL.read(sql);
                    dr.Read();
                    string sID = dr["ID"].ToString();
                    Form3 form3 = new Form3(sID);
                    
                    form3.Show();
                    this.Hide();
                    
                }
                else if (comboBox1.Text == "老师" && flag == true)
                {
                    Form2 form2 = new Form2();
                    form2.Show();
                    this.Hide();
                }
                else if (comboBox1.Text == "管理员" && flag == true)
                {
                    Form4 form4 = new Form4();
                    form4.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("出错了捏~", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = null;
            textBox3.Text = null;
            comboBox1.Text= null;
        }
    }
}
