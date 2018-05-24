using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;


namespace MyAutoKeys
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        /*************************** 自动执行的部份  ************************************/
        [DllImport("user32.dll")]
        public static extern void keybd_event(byte bVk, byte bScan, int dwFlags, int dwExtraInfo);

        //bvk为键值，例如回车13，bScan设置为0，dwFlags设置0表示按下，2表示抬起；dwExtraInfo也设置为0即可

        private void timer1_Tick(object sender, EventArgs e)
        {
            keybd_event((byte)Keys.D1, 0, 0, 0);
            keybd_event((byte)Keys.D1, 0, 2, 0);
            
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            keybd_event((byte)Keys.D2, 0, 0, 0);
            keybd_event((byte)Keys.D2, 0, 2, 0);
            
        }
        private void timer3_Tick(object sender, EventArgs e)
        {
            keybd_event((byte)Keys.D3, 0, 0, 0);
            keybd_event((byte)Keys.D3, 0, 2, 0);
        }
        private void butRun_Click(object sender, EventArgs e)
        {
            timer1.Start();
            timer2.Start();
            timer3.Start();

        }
        
        private void butStop_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            timer2.Stop();
            timer3.Stop();
        }
        /**************************************************************************/

        /*

        /// <summary>     
        /// 系统热键事件委托。     
        /// </summary>     
        public delegate void HotKeyCallBackHanlder();

        public static class Hotkey
        {
            #region 系统api
            [DllImport("user32.dll")]
            [return: MarshalAs(UnmanagedType.Bool)]
            static extern bool RegisterHotKey(IntPtr hWnd, int id, HotkeyModifiers fsModifiers, int vk);
            [DllImport("user32.dll")]
            static extern bool UnregisterHotKey(IntPtr hWnd, int id);
            #endregion

            /// <summary>          
            /// 注册快捷键          
            /// </summary>          
            /// <param name="hWnd">持有快捷键窗口的句柄</param>          
            /// <param name="fsModifiers">组合键</param>          
            /// <param name="vk">快捷键的虚拟键码</param>          
            /// <param name="callBack">回调函数</param>          
            public static void Regist(IntPtr hWnd, HotkeyModifiers fsModifiers, int vk, HotKeyCallBackHanlder callBack)
            {
                int id = keyid++;
                if (!RegisterHotKey(hWnd, id, fsModifiers, vk))
                    throw new Exception("regist hotkey fail.");
                keymap[id] = callBack;
            }
            /// <summary>          
            /// 注销快捷键          
            /// </summary>          
            /// <param name="hWnd">持有快捷键窗口的句柄</param>          
            /// <param name="callBack">回调函数</param>          
            public static void UnRegist(IntPtr hWnd, HotKeyCallBackHanlder callBack)
            {
                foreach (KeyValuePair<int, HotKeyCallBackHanlder> var in keymap)
                {
                    if (var.Value == callBack)
                        UnregisterHotKey(hWnd, var.Key);
                }
            }
            /// <summary>          
            /// 快捷键消息处理          
            /// </summary>          
            public static void ProcessHotKey(System.Windows.Forms.Message m)
            {
                if (m.Msg == WM_HOTKEY)
                {
                    int id = m.WParam.ToInt32();
                    HotKeyCallBackHanlder callback;
                    if (keymap.TryGetValue(id, out callback))
                    {
                        callback();
                    }
                }
            }
            const int WM_HOTKEY = 0x312;
            static int keyid = 10;
            static Dictionary<int, HotKeyCallBackHanlder> keymap = new Dictionary<int, HotKeyCallBackHanlder>();

            [Flags]
            public enum HotkeyModifiers
            {
                None = 0x0,
                MOD_ALT = 0x1,
                MOD_CONTROL = 0x2,
                MOD_SHIFT = 0x4,
                MOD_WIN = 0x8
            }
        }

        //{ Virtual Keys, Standard Set }
        //{$EXTERNALSYM VK_LBUTTON}
        //VK_LBUTTON = 1;
        //{$EXTERNALSYM VK_RBUTTON}
        //VK_RBUTTON = 2;
        //{$EXTERNALSYM VK_CANCEL}
        //VK_CANCEL = 3;
        //{$EXTERNALSYM VK_MBUTTON}
        //VK_MBUTTON = 4; { NOT contiguous with L & RBUTTON }
        //{$EXTERNALSYM VK_BACK}
        //VK_BACK = 8;
        //{$EXTERNALSYM VK_TAB}
        //VK_TAB = 9;
        //{$EXTERNALSYM VK_CLEAR}
        //VK_CLEAR = 12;
        //{$EXTERNALSYM VK_RETURN}
        //VK_RETURN = 13;
        //{$EXTERNALSYM VK_SHIFT}
        //VK_SHIFT = $10;
        //{$EXTERNALSYM VK_CONTROL}
        //VK_CONTROL = 17;
        //{$EXTERNALSYM VK_MENU}
        //VK_MENU = 18;
        //{$EXTERNALSYM VK_PAUSE}
        //VK_PAUSE = 19;
        //{$EXTERNALSYM VK_CAPITAL}
        //VK_CAPITAL = 20;
        //{$EXTERNALSYM VK_KANA }
        //VK_KANA = 21;
        //{$EXTERNALSYM VK_HANGUL }
        //VK_HANGUL = 21;
        //{$EXTERNALSYM VK_JUNJA }
        //VK_JUNJA = 23;
        //{$EXTERNALSYM VK_FINAL }
        //VK_FINAL = 24;
        //{$EXTERNALSYM VK_HANJA }
        //VK_HANJA = 25;
        //{$EXTERNALSYM VK_KANJI }
        //VK_KANJI = 25;
        //{$EXTERNALSYM VK_CONVERT }
        //VK_CONVERT = 28;
        //{$EXTERNALSYM VK_NONCONVERT }
        //VK_NONCONVERT = 29;
        //{$EXTERNALSYM VK_ACCEPT }
        //VK_ACCEPT = 30;
        //{$EXTERNALSYM VK_MODECHANGE }
        //VK_MODECHANGE = 31;
        //{$EXTERNALSYM VK_ESCAPE}
        //VK_ESCAPE = 27;
        //{$EXTERNALSYM VK_SPACE}
        //VK_SPACE = $20;
        //{$EXTERNALSYM VK_PRIOR}
        //VK_PRIOR = 33;
        //{$EXTERNALSYM VK_NEXT}
        //VK_NEXT = 34;
        //{$EXTERNALSYM VK_END}
        //VK_END = 35;
        //{$EXTERNALSYM VK_HOME}
        //VK_HOME = 36;
        //{$EXTERNALSYM VK_LEFT}
        //VK_LEFT = 37;
        //{$EXTERNALSYM VK_UP}
        //VK_UP = 38;
        //{$EXTERNALSYM VK_RIGHT}
        //VK_RIGHT = 39;
        //{$EXTERNALSYM VK_DOWN}
        //VK_DOWN = 40;
        //{$EXTERNALSYM VK_SELECT}
        //VK_SELECT = 41;
        //{$EXTERNALSYM VK_PRINT}
        //VK_PRINT = 42;
        //{$EXTERNALSYM VK_EXECUTE}
        //VK_EXECUTE = 43;
        //{$EXTERNALSYM VK_SNAPSHOT}
        //VK_SNAPSHOT = 44;
        //{$EXTERNALSYM VK_INSERT}
        //VK_INSERT = 45;
        //{$EXTERNALSYM VK_DELETE}
        //VK_DELETE = 46;
        //{$EXTERNALSYM VK_HELP}
        //VK_HELP = 47;
        //{ VK_0 thru VK_9 are the same as ASCII '0' thru '9' ($30 - $39) }
        //{ VK_A thru VK_Z are the same as ASCII 'A' thru 'Z' ($41 - $5A) }
        //{$EXTERNALSYM VK_LWIN}
        //VK_LWIN = 91;
        //{$EXTERNALSYM VK_RWIN}
        //VK_RWIN = 92;
        //{$EXTERNALSYM VK_APPS}
        //VK_APPS = 93;
        //{$EXTERNALSYM VK_NUMPAD0}
        //VK_NUMPAD0 = 96;
        //{$EXTERNALSYM VK_NUMPAD1}
        //VK_NUMPAD1 = 97;
        //{$EXTERNALSYM VK_NUMPAD2}
        //VK_NUMPAD2 = 98;
        //{$EXTERNALSYM VK_NUMPAD3}
        //VK_NUMPAD3 = 99;
        //{$EXTERNALSYM VK_NUMPAD4}
        //VK_NUMPAD4 = 100;
        //{$EXTERNALSYM VK_NUMPAD5}
        //VK_NUMPAD5 = 101;
        //{$EXTERNALSYM VK_NUMPAD6}
        //VK_NUMPAD6 = 102;
        //{$EXTERNALSYM VK_NUMPAD7}
        //VK_NUMPAD7 = 103;
        //{$EXTERNALSYM VK_NUMPAD8}
        //VK_NUMPAD8 = 104;
        //{$EXTERNALSYM VK_NUMPAD9}
        //VK_NUMPAD9 = 105;
        //{$EXTERNALSYM VK_MULTIPLY}
        //VK_MULTIPLY = 106;
        //{$EXTERNALSYM VK_ADD}
        //VK_ADD = 107;
        //{$EXTERNALSYM VK_SEPARATOR}
        //VK_SEPARATOR = 108;
        //{$EXTERNALSYM VK_SUBTRACT}
        //VK_SUBTRACT = 109;
        //{$EXTERNALSYM VK_DECIMAL}
        //VK_DECIMAL = 110;
        //{$EXTERNALSYM VK_DIVIDE}
        //VK_DIVIDE = 111;
        //{$EXTERNALSYM VK_F1}
        //VK_F1 = 112;
        //{$EXTERNALSYM VK_F2}
        //VK_F2 = 113;
        //{$EXTERNALSYM VK_F3}
        //VK_F3 = 114;
        //{$EXTERNALSYM VK_F4}
        //VK_F4 = 115;
        //{$EXTERNALSYM VK_F5}
        //VK_F5 = 116;
        //{$EXTERNALSYM VK_F6}
        //VK_F6 = 117;
        //{$EXTERNALSYM VK_F7}
        //VK_F7 = 118;
        //{$EXTERNALSYM VK_F8}
        //VK_F8 = 119;
        //{$EXTERNALSYM VK_F9}
        //VK_F9 = 120;
        //{$EXTERNALSYM VK_F10}
        //VK_F10 = 121;
        //{$EXTERNALSYM VK_F11}
        //VK_F11 = 122;
        //{$EXTERNALSYM VK_F12}
        //VK_F12 = 123;
        //{$EXTERNALSYM VK_F13}
        //VK_F13 = 124;
        //{$EXTERNALSYM VK_F14}
        //VK_F14 = 125;
        //{$EXTERNALSYM VK_F15}
        //VK_F15 = 126;
        //{$EXTERNALSYM VK_F16}
        //VK_F16 = 127;
        //{$EXTERNALSYM VK_F17}
        //VK_F17 = 128;
        //{$EXTERNALSYM VK_F18}
        //VK_F18 = 129;
        //{$EXTERNALSYM VK_F19}
        //VK_F19 = 130;
        //{$EXTERNALSYM VK_F20}
        //VK_F20 = 131;
        //{$EXTERNALSYM VK_F21}
        //VK_F21 = 132;
        //{$EXTERNALSYM VK_F22}
        //VK_F22 = 133;
        //{$EXTERNALSYM VK_F23}
        //VK_F23 = 134;
        //{$EXTERNALSYM VK_F24}
        //VK_F24 = 135;
        //{$EXTERNALSYM VK_NUMLOCK}
        //VK_NUMLOCK = 144;
        //{$EXTERNALSYM VK_SCROLL}
        //VK_SCROLL = 145;
        //{ VK_L & VK_R - left and right Alt, Ctrl and Shift virtual keys.
        //Used only as parameters to GetAsyncKeyState() and GetKeyState().
        //No other API or message will distinguish left and right keys in this way. }
        //{$EXTERNALSYM VK_LSHIFT}
        //VK_LSHIFT = 160; 

        */
        /*
         ///<summary>
   
    /// 注册热键
   
    ///</summary>
   
    /// <paramname="hWnd">为窗口句柄</param>
   
    /// <paramname="id">注册的热键识别ID</param>
   
    /// <paramname="control">组合键代码 Alt的值为1，Ctrl的值为2，Shift的值为4，Shift+Alt组合键为5
   
    /// Shift+Alt+Ctrl组合键为7，Windows键的值为8
   
    ///</param>
   
    /// <paramname="vk">按键枚举</param>
   
    ///<returns></returns>
   
   
[DllImport("user32")]
   
    public static extern bool RegisterHotKey(IntPtr hWnd, int id, uint control, Keysvk);

   
    ///<summary>
    /// 取消注册的热键
    ///</summary>
    /// <paramname="hWnd">窗口句柄</param>
    /// <paramname="id">注册的热键id</param>
    ///<returns></returns>
   
   
[DllImport("user32")]
   
    public static extern bool UnregisterHotKey(IntPtr hWnd, int id);

//使用方法

 //注册热键Ctrl+F12，这里的8879就是一个ID识别
  Class APIUse.RegisterHotKey(this.Handle, 8879, 2,Keys.F12);
//响应热键

 protected override void WndProc(ref Message m)
    {
         switch (m.Msg)
        {
   
             case 0x0312:    //这个是window消息定义的注册的热键消息  
  
            if(m.WParam.ToString().Equals("8879"))  //如果是注册的那个热键
 
             {
                //执行button按钮
            }
   
    break;
   
     
         }
             base.WndProc(ref m);
    }


   //用来取消注册的热键
   
     
   Class APIUse.UnregisterHotKey(this.Handle,8879);
        */

        /**************************** 全局热键 *************************************/

        class HotKey
        {
            //如果函数执行成功，返回值不为0。
            //如果函数执行失败，返回值为0。要得到扩展错误信息，调用GetLastError。
            [DllImport("user32.dll", SetLastError = true)]
            public static extern bool RegisterHotKey(
                IntPtr hWnd,                //要定义热键的窗口的句柄
                int id,                     //定义热键ID（不能与其它ID重复）           
                KeyModifiers fsModifiers,   //标识热键是否在按Alt、Ctrl、Shift、Windows等键时才会生效
                Keys vk                     //定义热键的内容
                );

            [DllImport("user32.dll", SetLastError = true)]
            public static extern bool UnregisterHotKey(
                IntPtr hWnd,                //要取消热键的窗口的句柄
                int id                      //要取消热键的ID
                );

            //定义了辅助键的名称（将数字转变为字符以便于记忆，也可去除此枚举而直接使用数值）
            [Flags()]
            public enum KeyModifiers
            {
                None = 0,
                Alt = 1,
                Ctrl = 2,
                Shift = 4,
                WindowsKey = 8
            }
        }

        /// “public static extern bool RegisterHotKey()”这个函数用于注册热键。
        /// 由于这个函数需要引用user32.dll动态链接库后才能使用，并且user32.dll是非托管代码，
        /// 不能用命名空间的方式直接引用，所以需要用“DllImport”进行引入后才能使用。
        /// 于是在函数前面需要加上“[DllImport("user32.dll", SetLastError = true)]”这行语句。
        /// “public static extern bool UnregisterHotKey()”这个函数用于注销热键，
        /// 同理也需要用DllImport引用user32.dll后才能使用。
        /// “public enum KeyModifiers{}”定义了一组枚举，将辅助键的数字代码直接表示为文字，以方便使用。
        /// 这样在调用时我们不必记住每一个辅助键的代码而只需直接选择其名称即可。

        /// 当窗口启动时 注册热键
        private void Form1_Load(object sender, EventArgs e)
        {
            //注册热键Shift+S，Id号为100。HotKey.KeyModifiers.Shift也可以直接使用数字4来表示。
            //HotKey.RegisterHotKey(Handle, 100, HotKey.KeyModifiers.Shift, Keys.S);
            //注册热键Ctrl+B，Id号为101。HotKey.KeyModifiers.Ctrl也可以直接使用数字2来表示。
            //HotKey.RegisterHotKey(Handle, 101, HotKey.KeyModifiers.Ctrl, Keys.F10);

            //注册热键F10，Id号为100。
            HotKey.RegisterHotKey(Handle, 100, 0, Keys.H);
            //注册热键F10，Id号为101。
            HotKey.RegisterHotKey(Handle, 101, 0, Keys.U);
        }
        /// 当窗口关闭后 注销热键
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            //注销Id号为100的热键设定
            HotKey.UnregisterHotKey(Handle, 100);
            //注销Id号为101的热键设定
            HotKey.UnregisterHotKey(Handle, 101);
        }

        /// 
        /// 监视Windows消息
        /// 重载WndProc方法，用于实现热键响应
        /// 
        /// 
        protected override void WndProc(ref Message m)
        {
            const int WM_HOTKEY = 0x0312;
            //按快捷键 
            switch (m.Msg)
            {
                case WM_HOTKEY:
                    switch (m.WParam.ToInt32())
                    {
                        case 100:    //按下的是F10
                            {
                                timer1.Start();
                                timer2.Start();
                                timer3.Start();
                            }
                            break;
                        case 101:    //按下的是F11
                            {
                                timer1.Stop();
                                timer2.Stop();
                                timer3.Stop();
                            }
                            break;
                    }
                    break;
            }
            base.WndProc(ref m);
        }

     

        /************************ 例 *********************************/

        /*
         * RegisterHotKey函数原型及说明：
         * BOOL RegisterHotKey(
         * HWND hWnd,         // window to receive hot-key notification
         * int id,            // identifier of hot key
         * UINT fsModifiers, // key-modifier flags
         * UINT vk            // virtual-key code);
         * 参数 id为你自己定义的一个ID值
         * 对一个线程来讲其值必需在0x0000 - 0xBFFF范围之内,十进制为0~49151
         * 对DLL来讲其值必需在0xC000 - 0xFFFF 范围之内,十进制为49152~65535
         * 在同一进程内该值必须唯一参数 fsModifiers指明与热键联合使用按键
         * 可取值为：MOD_ALT MOD_CONTROL MOD_WIN MOD_SHIFT参数，或数字0为无，1为Alt,2为Control，4为Shift，8为Windows
         * vk指明热键的虚拟键码
         */
        /*
        [System.Runtime.InteropServices.DllImport("user32.dll")] //申明API函数
        public static extern bool RegisterHotKey(
         IntPtr hWnd, // handle to window 
         int id, // hot key identifier 
         uint fsModifiers, // key-modifier options 
         Keys vk // virtual-key code 
        );
        [System.Runtime.InteropServices.DllImport("user32.dll")] //申明API函数
        public static extern bool UnregisterHotKey(
         IntPtr hWnd, // handle to window 
         int id // hot key identifier 
        );
     
       
        private void Form1_Load(object sender, EventArgs e)
        {
            //Handle为当前窗口的句柄,继续自Control.Handle,Control为定义控件的基类
            //RegisterHotKey(Handle, 100, 0, Keys.A); //注册快捷键,热键为A
            //RegisterHotKey(Handle, 100, KeyModifiers.Alt | KeyModifiers.Control, Keys.B);//这时热键为Alt+CTRL+B
            //RegisterHotKey(Handle, 100, 1, Keys.B); //1为Alt键，热键为Alt+B
            RegisterHotKey(Handle, 100, 2,Keys.A); //定义热键为Alt+Tab，这里实现了屏幕系统Alt+Tab键
            RegisterHotKey(Handle, 200, 2, Keys.B); //注册2个热键,根据id值100,200来判断需要执行哪个函数
        }

        private void button1_Click(object sender, EventArgs e) //重新设置热键
        {
            UnregisterHotKey(Handle, 100);//卸载快捷键
            RegisterHotKey(Handle, 100, 2, Keys.C); //注册新的快捷键，参数0表示无组合键
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e) //退出程序时缷载热键
        {
            UnregisterHotKey(Handle, 100);//卸载第1个快捷键
            UnregisterHotKey(Handle, 200); //缷载第2个快捷键
        }

        //重写WndProc()方法，通过监视系统消息，来调用过程
        protected override void WndProc(ref Message m)//监视Windows消息
        {
            const int WM_HOTKEY = 0x0312;//如果m.Msg的值为0x0312那么表示用户按下了热键
            switch (m.Msg)
            {
                case WM_HOTKEY:
                    ProcessHotkey(m);//按下热键时调用ProcessHotkey()函数
                    break;
            }
            base.WndProc(ref m); //将系统消息传递自父类的WndProc
        }

        private void ProcessHotkey(Message m) //按下设定的键时调用该函数
        {
            // IntPtr //IntPtr用于表示指针或句柄的平台特定类型
            //MessageBox.Show(id.ToString());
            string sid = id.ToString();
            switch (sid)
            {
                case "100":
                    MessageBox.Show("调用A函数");
                    break;
                case "200":
                    MessageBox.Show("调用B函数");
                    break;
            }
        }

        *************************************************************************/
    }
}
