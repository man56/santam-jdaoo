using System;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using STM.BLayer.Configurations;
using STM.Properties;

namespace STM
{
    class Lock
    {
        [DllImport("Rockey2.dll")]
        static extern int RY2_Find();
        [DllImport("Rockey2.dll")]
        static extern int RY2_Open(int mode, Int32 uid, ref Int32 hid);
        [DllImport("Rockey2.dll")]
        static extern void RY2_Close(int handle);
        [DllImport("Rockey2.dll")]
        static extern int RY2_Read(int handle, int block_index, StringBuilder buffer512);
	
        public static void Check(string userCode)
        {            
            if (string.IsNullOrEmpty(userCode) || !CheckUser(userCode) )
            {
                using (var frmReg = new FrmRegister())
                {
                    while (true)
                    {
                        if (frmReg.ShowDialog() == DialogResult.OK)
                        {
                            if (CheckUser(frmReg.UserCode))
                            {
                                SettingLoader.Current.SetUser(frmReg.UserCode);
                                break;
                            }
                            MessageBox.Show(Resources.Lock_Check_Invalid_register_code_);
                        }
                        else
                        {
                            Environment.Exit(0);
                        }
                    }
                }
            }
        }

        private static bool CheckUserCreep(string userCode)
        {
            var handle = 0;
            var returnCode = RY2_Find();
            const int uid = -94502711;
            int hid = 0;
            if (returnCode == 0)
            {
                return false;
            }
            returnCode = RY2_Open(1, uid, ref hid);
            handle = returnCode;
            if (returnCode < 0)
            {
                return false;
            }
            var retbuff = new StringBuilder("0", 512);

            returnCode = RY2_Read(handle, 0, retbuff);
            RY2_Close(handle);
            if (returnCode == 0)
                if (retbuff.ToString().Equals(userCode))
                    return true;

            return false;
        }

        private static bool CheckUser(string userCode)
        {
            Program.FullCreepAvailable = CheckUserCreep(userCode);
            if (Program.FullCreepAvailable) return true;

            var handle = 0;
            var returnCode = RY2_Find();
            const int uid = 1755563400;
            const int uid_creep = -94502711;
            int hid = 0;
            if(returnCode == 0)
            {
                MessageBox.Show(Resources.Lock_CheckUser_Insert_usb_lock_);
                Environment.Exit(0);
            }
            returnCode = RY2_Open(1, uid, ref hid);
            if(returnCode<0)
                returnCode = RY2_Open(1, uid_creep, ref hid);
            handle = returnCode;
            if (returnCode < 0)
            {
                SplashScreen.CloseForm();
                MessageBox.Show(Resources.Lock_CheckUser_Error__can_not_open_the_usb_lock_);
                Environment.Exit(0);
            }
            var retbuff = new StringBuilder("0", 512);

            returnCode = RY2_Read(handle, 0, retbuff);
            RY2_Close(handle);
            if (returnCode == 0)
                if (retbuff.ToString().Equals(userCode))
                    return true;
			
            return false;
        }
    }
}