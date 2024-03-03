using System.IO.Ports;
using System.Linq;
using System.Windows.Forms;
using STM.BLayer.Parameters;
using STM.BLayer.Configurations;
using System.Threading;
using System;
using System.Globalization;

namespace STM.DLayer
{
    public class TMPR232
    {
        public const int NumberOfTemperaturChannels = 8;
        public static bool[] TemperatureHardwareExists = new bool[NumberOfTemperaturChannels];
        public static bool[] TemperatureControlerExists = new bool[NumberOfTemperaturChannels];

        static TMPR232 instanse;
        public static bool Connected { set; get; }
        public static TMPR232 Current
        {
            get { return instanse ?? (instanse = new TMPR232()); }
        }
        static SerialPort port;

        private TMPR232()
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
                    TemperaturePortParameters.Name = p;
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
            catch (Exception e)
            {
            }
        }

        static bool CreatePort()
        {
            if (string.IsNullOrEmpty(TemperaturePortParameters.Name)) return false;

            port = new SerialPort
            {
                PortName = TemperaturePortParameters.Name,
                BaudRate = TemperaturePortParameters.BaudRate,
                Parity = TemperaturePortParameters.Parity,
                StopBits = TemperaturePortParameters.StopBits,
                DataBits = TemperaturePortParameters.DataBits,
                DtrEnable = false,
                RtsEnable = false,
                DiscardNull = false,
                ReadBufferSize = 512,
                WriteTimeout = 100,
                ReadTimeout = 100
            };

            bool isConnected = false;

            try
            {
                if (!port.IsOpen)
                    port.Open();
                Connected = true;
                TemperatureHardwareExists[0] = false;
                for (var channel = 1; channel < NumberOfTemperaturChannels; channel++)
                    try
                    {
                        port.Write(((char)2) + channel.ToString("00") + "DMS,01,0001\r");
                        Thread.Sleep(100);
                        var response = port.ReadLine();
                        if (response?.Contains("OK") ?? false)
                            TemperatureHardwareExists[channel] = true;
                        else
                            TemperatureHardwareExists[channel] = false;

                        isConnected |= TemperatureHardwareExists[channel];
                    }
                    catch 
                    {
                        TemperatureHardwareExists[channel] = false;
                    }
            }
            catch (Exception e)
            {
            }
            finally
            {
                if (!isConnected) port?.Close();
            }

            for (var channel = 0; channel < TemperatureControlerExists.Length; channel++)
                TemperatureControlerExists[channel] = TemperatureHardwareExists[channel];

            Connected = isConnected;
            return Connected;
        }

        public string Send(string cmd)
        {
            if (Connected)
            {
                cmd = ((char)2) + cmd + "\r";
                lock (port)
                    try
                    {
                        port.Write(cmd);
                        Thread.Sleep(100);
                        var response = port.ReadLine();
                        if (response?.Contains("OK") ?? false)
                            return response;
                        else if (response?.Contains("NG") ?? false)
                            return response;
                    }
                    catch (InvalidOperationException e)
                    {
                        try { if (!port.IsOpen) port.Open(); } catch { }
                    }
                    catch { }
            }

            return null;
        }

        public int Read(int channel)
        {
            channel = InstrumentParameters.TemperatureChannelMapping[channel];

            if (TemperatureHardwareExists[channel])
            {
                var response = Send(channel.ToString("00") + "DMC");
                if (response != null)
                    try
                    {
                        if (response.Contains("OK"))
                        {
                            var ok = response.IndexOf("OK") + "OK,".Length;
                            response = response.Substring(ok, response.Length - ok - 1);
                            var temp = int.MinValue;
                            if (int.TryParse(response, NumberStyles.HexNumber, null, out temp))
                                return temp;
                        }
                        else if (response.Contains("NG"))
                        {
                            port.Write(((char)2) + channel.ToString("00") + "DMS,01,0001\r");
                            Thread.Sleep(100);
                            response = port.ReadLine();
                        }
                    }
                    catch
                    {
                    }

            }
            return 0;
        }

        public bool Set(int channel, float setPoint)
        {
            if (TemperatureControlerExists[channel])
                try
                {
                    var response = Send(channel.ToString("00") + "DWS,02,0300,0001," + ((int)setPoint).ToString("X4"));
                    if (response != null)
                        return true;
                }
                catch { return false; }

            return true;
        }

        public bool Set(params float[] setPoints)
        {
            var ret = true;
            for (var channel = 1; channel < NumberOfTemperaturChannels && channel < setPoints.Length; channel++)
                if (TemperatureControlerExists[channel])
                    try
                    {
                        var response = Send(channel.ToString("00") + "DWS,02,0300,0001," + ((int)setPoints[channel - 1]).ToString("X4"));
                    }
                    catch { ret = false; }

            return ret;
        }

        public bool Set(float setPoint)
        {
            var ok = true;
            for (var channel = 1; channel < NumberOfTemperaturChannels; channel++)
                ok &= Set(channel, setPoint);
            return ok;
        }

        public void ClearPortBuffer()
        {
            try
            {
                lock (port)
                {
                    var data = port.ReadExisting();
                }
            }
            catch
            {
            }
        }
    }
}
