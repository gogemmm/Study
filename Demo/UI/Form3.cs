using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Demo
{
    public partial class Form3 : Form
    {
        DAL dAL = new DAL();
        string SID;
        public Form3(string sID)
        {
            SID = sID;
            InitializeComponent();
            toolStripStatusLabel1.Text = "欢迎学号为" + SID + "的同学登陆选课系统";
            table();

        }

        public void table()
        {

            DAL dAL = new DAL();
            string sql = "select * from Course";
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = dAL.dataset(sql).Tables[0];
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //toolStripStatusLabel3.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }

        private void 选择该课ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string cID = dataGridView1.SelectedCells[0].Value.ToString();//获取选中的课程号
            string sql = $"insert into CourseRecord values('{SID}','{cID}')";
            int i = dAL.Excute(sql);
            if (i > 0 ) 
            {
                MessageBox.Show("选择成功");
            }
        }
    }
}
