using System;
using System.Threading;
using System.Windows.Forms;

namespace STM.PLayer.Other
{
    public partial class Prompter : Form
    {
        public int FadeTime { set; get; }
        public string Message { set { lbMessage.Text = value; } }
        public bool UserCancel { get; set; }
        private Thread thd;
        public  Prompter()
        {
            InitializeComponent();
            FadeTime = 5;
        }

        delegate void HideDelegate();
        private void Prompter_Load(object sender, EventArgs e)
        {
            //if (!UserCancel)
            //{
            //    thd = new Thread(() =>
            //                         {
            //                             Thread.Sleep(FadeTime*1000);
            //                             try
            //                             {
            //                                 BeginInvoke(new HideDelegate(Hide));
            //                             }
            //                             catch
            //                             {
            //                             }
            //                         });
            //    thd.Start();
            //}
        }

        private void Prompter_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                thd.Abort();
            }
            catch
            {
            }
        }

        
    }
}
