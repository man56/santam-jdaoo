using System.IO.Ports;
using System.Linq;
using System.Windows.Forms;
using STM.BLayer.Parameters;
using STM.BLayer.Configurations;
using System.Threading;
using System;
using STM.Properties;

namespace STM.DLayer
{
    public class RS232
    {
        static RS232 instanse;
        public static bool Connected { set; get; }
        public static RS232 Current
        {
            get { return instanse ?? (instanse = new RS232()); }
        }
        static SerialPort port;

        private RS232()
        {
            if (!CreatePort())
                AutoDiscovery();
        }

        private void AutoDiscovery()
        {
            try
            {
                Connected = false;
                var ports = SerialPort.GetPortNames();
                ports = (from port in ports let tmp = new SerialPort(port) where !tmp.IsOpen select port).ToArray();

                foreach (var p in ports)
                {
                    SerialPortParameters.Name = p;
                    if (CreatePort())
                    {
                        using (SettingLoader sl = SettingLoader.Current)
                        {
                            sl.SavePortSetting();
                        }
                        break;
                    }
                }
            }
            catch
            {
            }
            if (!Connected)
                MessageBox.Show(Resources.RS232_AutoDiscovery_Error_on_serial_port, AboutBox.AssemblyTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        static bool CreatePort()
        {
            port = new SerialPort
                       {
                           PortName = SerialPortParameters.Name,
                           BaudRate = SerialPortParameters.BaudRate,
                           Parity = SerialPortParameters.Parity,
                           StopBits = SerialPortParameters.StopBits,
                           DtrEnable = true,
                           RtsEnable = false,
                           DiscardNull = true,
                           ReadBufferSize = 640,
                           WriteTimeout = 5,
                           ReadTimeout = 3000
                       };

            bool isConnected = false;
            try
            {
                if (!port.IsOpen)
                    port.Open();
                Connected = true;
                port.Write("ADM\r");
                Thread.Sleep(100);
                var response = Read();
                if ((response.Length == 9 && response[4] == ';') || response == "Syntax Err" || response == "Syntax Err30")
                    isConnected = true;
                else
                    port.Close();
            }
            catch(Exception ex)
            {
                port.Close();
                isConnected = false;
            }
            Connected = isConnected;
            return Connected;
        }
        
        public void Send(string cmd)
        {
            if (Connected)
            {
                cmd += '\r';
                lock (port)
                {
                    for (int i = 0; i < cmd.Length; i++)
                    {
                        port.Write(cmd[i].ToString());
                          Delay.Sleep(250.00);
                    }
                }

                
            }
        }

        public static string Read()
        {
            string cmd = "";
            int nullCh = 0;
            if (Connected)
            {
                lock (port)
                {
                    
                    while (nullCh < 30)
                    {
                        int ch = port.ReadChar();
                        Delay.Sleep(5);
                        if ((char) ch == '\r' && cmd.Length > 0)
                        {
                            break;
                        }

                        cmd += (char) ch;
                        if (((char) ch).ToString() == "")
                            nullCh++;
                        else
                            nullCh = 1;
                    }
                }
            }
            return cmd;
        }


        public void ClearPortBuffer()
        {
            try
            {
                lock (port)
                {
                    var data =  port.ReadExisting();
                    data.ToString();
                }
            }
            catch
            {
            }
        }

        public static string[] GetPorts()
        {
            var names = SerialPort.GetPortNames();

            return (from name in names let tmp = new SerialPort(name) where !tmp.IsOpen select name).ToArray();
        }
    }
}
