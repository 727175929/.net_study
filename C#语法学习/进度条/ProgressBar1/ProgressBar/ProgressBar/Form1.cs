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


        //模拟进度条  
        private void Send()
        {
            int i = 0;
            while (i <= 100)
            {
                //显示进度信息  
                this.ShowPro(i);
                if (i == 100)
                {
                    i = 0;
                }
                i++; //模拟发送多少  
                Thread.Sleep(5);
            }
            Thread.CurrentThread.Abort();
        }

        private delegate void ProgressBarShow(int i);

        private void ShowPro(int value)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new ProgressBarShow(ShowPro), value);
            }
            else
            {
                this.progressBar1.Value = value;
                this.label1.Text = value + "% Processing...";
            }
        }

        private void myStartingMethod()
        {
            for (int i = 1; i <= 100; i++)
            {

                progressBar1.Value = i;


            }
        }  

        private void button1_Click(object sender, EventArgs e)
        {
            Thread myThread = new System.Threading.Thread(new ThreadStart(Send));

            myThread.IsBackground = true;
            myThread.Start();
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }
    }
}
