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

namespace lasToxyzrgb
{
    public partial class masterWin : Form
    {

        public masterWin()
        {
            InitializeComponent();
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            textSave.Text = saveFileDialog1.FileName;
        }

        private void butSave_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();
        }

        private void butOpen_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            textOpen.Text = openFileDialog1.FileName;
        }

        double i = 0;
        double j = 0;
        private void butRun_Click(object sender, EventArgs e)
        {
            butRun.Enabled = false;
            Thread sonThread = new Thread(rundata);
            sonThread.IsBackground = true;
            sonThread.Start();
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int k = Convert.ToInt32((i / j) * 100);
            label1.Text = "已处理" + Convert.ToString(i) + "/" + Convert.ToString(j) + "个点";
            label1.Update();
            progressBar1.Value = k;
            progressBar1.Update();
            label2.Text = k + "%";
        }





        //利用delegate 实现进度条更新---------------------------------------------------------------

        //1、进度条在当前窗体上

        /*  网上的案例
         * //更新进度列表

        private delegate void SetPos(int ipos); 

第三步：进度条值更新函数（参数必须跟声明的代理参数一样）

        private void SetTextMessage(int ipos)

         {

            if (this.InvokeRequired)

             {

                 SetPos setpos = new SetPos(SetTextMessage);

                this.Invoke(setpos, newobject[] { ipos});

             }

            else

             {

                this.label1.Text = ipos.ToString() + "/100";

                this.progressBar1.Value = Convert.ToInt32(ipos);

             }

         }

第四步：函数实现

        privatevoid button1_Click(object sender, EventArgs e)

         {

             Thread fThread = new Thread(new ThreadStart(SleepT));//开辟一个新的线程

             fThread.Start();

         }

第五步：新的线程执行函数：

        privatevoid SleepT()

         {

            for (int i = 0; i < 500; i++)

             {

                 System.Threading.Thread.Sleep(100);//没什么意思，单纯的执行延时

                 SetTextMessage(100 * i / 500);

             }

         }*/

        private void 主窗体交互操作(object sender, EventArgs e)
        {
            //新建工作线程并指定任务函数
            Thread newLine = new Thread(works);
            //后台工作
            newLine.IsBackground = true;
            //开始
            newLine.Start();
        }

        //工作内容~将被分到别的线程
        void works()
        {
            for (int i = 0; i < 100; i++)
            {
                Thread.Sleep(500);

                //new 一个代理对象并把 代理事件指定给对象
                ProgressDelegate aa = new ProgressDelegate(deleg);

                //  触发事件,Invoke切换到控件所在的线程，（代理对象，传出参数）
                //  this.Invoke(aa, i);

                //  当有多个参数时使用下面这个方法
                this.Invoke(aa, new object[] { i });
            }
        }

        void deleg(int u)
        {
            this.label1.Text = u.ToString() + "/100";

            this.progressBar1.Value = u;
        }









    }
    //声明一个delegate 类
    delegate void ProgressDelegate(int p);
}
