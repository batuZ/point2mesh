using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lasToxyzrgb
{
    public partial class masterWin
    {
        private void rundata(object sss)
        {
            string savePath = saveFileDialog1.FileName;
            string openPath = openFileDialog1.FileName;
            using (StreamReader srs = new StreamReader(openPath))
            {
                string temp;
                while ((temp = srs.ReadLine()) != null)
                {
                    if (temp.IndexOf("RED") > -1)
                        j++;
                }
                srs.Close();
            }
            string res = Convert.ToString(j) + "\r\n";
            File.WriteAllText(savePath,res);
            
            using (System.IO.StreamReader sr = new System.IO.StreamReader(openPath))
            {
                string str;
                string red = null;
                string green = null;
                string blue = null;
                while ((str = sr.ReadLine()) != null)
                {
                    if (str.IndexOf("RED") > -1)
                    {
                        red = str.Substring(str.LastIndexOf("=") + 1);
                        i++;
                    }
                    else if (str.IndexOf("GREEN") > -1)
                    {
                        green = str.Substring(str.LastIndexOf("=") + 1);
                    }
                    else if (str.IndexOf("BLUE") > -1)
                    {
                        blue = str.Substring(str.LastIndexOf("=") + 1);
                    }
                    else if (blue != null)
                    {
                        using (StreamWriter file = new StreamWriter(savePath, true))
                        {
                            file.WriteLine(str + " " + red + " " + green + " " + blue);
                        }
                        red = null;
                        green = null;
                        blue = null;
                    }
                }
                sr.Close();
                MessageBox.Show("处理完成!");
            }
        }
    }
}
