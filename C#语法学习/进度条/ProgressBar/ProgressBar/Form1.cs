using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProgressBar
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 fm = new Form2(0, 100);
            fm.Show(this);//设置父窗体
            for (int i = 0; i < 10; i++)
            {
                fm.setPos(i);//设置进度条位置
                Thread.Sleep(100);//睡眠时间为100
            }
            fm.Close();//关闭窗体
        }
    }
}
