using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 独立空间坐标定位工具
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text == "定义")
            {
                bool a = getCoors.IsNumber(textBox1.Text);
                bool b = getCoors.IsNumber(textBox2.Text);
                bool c = getCoors.IsNumber(textBox3.Text);
                if (a && b && c)
                {
                    ///1 黑掉输入框
                    textBox1.Enabled = false;
                    textBox2.Enabled = false;
                    textBox3.Enabled = false;
                    ///2 改BUTTON 字
                    button1.Text = "修改";
                    ///3 亮点距输入框及BUT
                    textBox4.Enabled = true;
                    textBox5.Enabled = true;
                    textBox6.Enabled = true;
                    textPointName.Enabled = true;
                    button2.Enabled = true;

                }
                else
                { MessageBox.Show("输入错误！"); return; }
            }
            else if (button1.Text == "修改")
            {
                ///1 改BUT 字为定义
                button1.Text = "定义";
                ///2 亮输入框  并清空
                textBox1.Enabled = true;
                textBox2.Enabled = true;
                textBox3.Enabled = true;
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                ///3 黑点距框
                textBox4.Enabled = false;
                textBox5.Enabled = false;
                textBox6.Enabled = false;
                textPointName.Enabled = false;
                textBox4.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
                textPointName.Text = "";
                xValue.Text = "";
                yValue.Text = "";
                zValue.Text = "";
                button2.Enabled = false;
                ///4黑记录框
                button3.Enabled = false;
            }
            else return;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            button4.Text = saveFileDialog1.FileName;
            if (File.Exists(saveFileDialog1.FileName))
            {
                File.Delete(saveFileDialog1.FileName);
            }
            if (button4.Text != "指定输出位置")
            {
                textBox1.Enabled = true;
                textBox2.Enabled = true;
                textBox3.Enabled = true;
                button1.Enabled = true;
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string number = "【" + textPointName.Text + "】：" + xValue.Text + "," + yValue.Text + "," + zValue.Text;
            using (System.IO.StreamWriter coor = new System.IO.StreamWriter(button4.Text, true))
            {
                coor.WriteLine(number);// 直接追加文件末尾，换行   
            }
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            xValue.Text = "xValue √";
            yValue.Text = "xValue √";
            zValue.Text = "zValue √";
            string temp = textPointName.Text;
            string word = "";
            int num = 0;
            int i = 0;
            for (i = temp.Length - 1; i >= 0; i--)
            {
                if (!getCoors.IsNumber(temp.Substring(i, 1)))
                {
                    word = temp.Substring(0, i + 1);
                    num = ((i + 1) < temp.Length) ? Convert.ToInt32(temp.Substring(i + 1)) : 0;
                    break;
                }
            }
            textPointName.Text = word + (num + 1).ToString("000");
            button3.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bool a = getCoors.IsNumber(textBox4.Text);
            bool b = getCoors.IsNumber(textBox5.Text);
            bool c = getCoors.IsNumber(textBox6.Text);
            if (a && b && c)
            {
                double OX = Convert.ToDouble(textBox1.Text);
                double OY = Convert.ToDouble(textBox2.Text);
                double XY = Convert.ToDouble(textBox3.Text);
                double PO = Convert.ToDouble(textBox4.Text);
                double PX = Convert.ToDouble(textBox5.Text);
                double PY = Convert.ToDouble(textBox6.Text);
                var res = getCoors.Cal2(PO, PX, PY, OX, XY, OY);
                xValue.Text = Math.Round(res.Item1, 3).ToString();
                yValue.Text = Math.Round(res.Item2, 3).ToString();
                zValue.Text = Math.Round(res.Item3, 3).ToString();
            }
            else
            { MessageBox.Show("输入错误！"); return; }

            button3.Enabled = true;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (getCoors.IsNumber(textBox1.Text) && getCoors.IsNumber(textBox2.Text))
            {
                textBox3.Text = Math.Round(Math.Sqrt(
                   Convert.ToDouble(textBox1.Text)
                   * Convert.ToDouble(textBox1.Text)
                   + Convert.ToDouble(textBox2.Text)
                   * Convert.ToDouble(textBox2.Text)), 3
                   ).ToString();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (getCoors.IsNumber(textBox1.Text) && getCoors.IsNumber(textBox2.Text))
            {
                textBox3.Text = Math.Round(Math.Sqrt(
                    Convert.ToDouble(textBox1.Text)
                    * Convert.ToDouble(textBox1.Text)
                    + Convert.ToDouble(textBox2.Text)
                    * Convert.ToDouble(textBox2.Text)), 3
                    ).ToString();
            }
        }
    }
}
