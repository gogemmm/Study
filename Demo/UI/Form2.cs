using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Demo
{
    public partial class Form2 : Form
    {

        
        public Form2()
        {
            InitializeComponent();
            table();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
        }

        public void table()
        {
            
            DAL dAL = new DAL();
            string sql = "select id,Name,CLASS,BIrthday,jg from Student";
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = dAL.dataset(sql).Tables[0];
        }

        private void 添加学生信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form21 f = new Form21();
            f.ShowDialog();
        }

        private void 修改学生信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string[] str = { dataGridView1.SelectedCells[0].Value.ToString(), dataGridView1.SelectedCells[1].Value.ToString(), dataGridView1.SelectedCells[2].Value.ToString(), dataGridView1.SelectedCells[3].Value.ToString(), dataGridView1.SelectedCells[4].Value.ToString() };
            //MessageBox.Show(str[0]+ str[4]);
            Form21 form21 = new Form21(str);    
            form21.ShowDialog(this);
        }

        private void 删除学生信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            string id, name;
            id = dataGridView1.SelectedCells[0].Value.ToString();
            name = dataGridView1.SelectedCells[1].Value.ToString();
            string sql = $"delete from Student where Id='{id}' or Name='{name}'";
            DAL dAL = new DAL();
            int rows = dAL.Excute(sql);

            if (rows > 0)
            {
                MessageBox.Show("删除成功！");
                table();
            }
            else
            {
                MessageBox.Show("删除操作失败！");
            }

        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

            table();
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }
    }
}
