using System.IO.Ports;
using System.Linq;
using System.Windows.Forms;
using STM.BLayer.Parameters;
using STM.BLayer.Configurations;
using System.Threading;
using System;
using STM.BLayer.StmTest;
using STM.Properties;
using static STM.BLayer.StmTest.ModbusPort;

namespace STM.DLayer
{
    public class RS485
    {
        static RS485 instanse;
        public static bool Connected { set; get; }
        public static RS485 Current
        {
            get { return instanse ?? (instanse = new RS485()); }
        }
        static ModbusPort port;

        private RS485()
        {
            if (!CreatePort())
                AutoDiscovery();
        }

        private void AutoDiscovery()
        {
            try
            {
                Connected = false;
                var ports = ModbusPort.GetPortNames();
                ports = (from port in ports let tmp = new ModbusPort(port) where !tmp.IsOpen select port).ToArray();

                foreach (var p in ports)
                {
                    ModbusPortParameters.Name = p;
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
                MessageBox.Show(Resources.RS485_AutoDiscovery_Error_on_RS485_port, AboutBox.AssemblyTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        static bool CreatePort()
        {
            try
            {
                port = new ModbusPort
                {
                    PortName = ModbusPortParameters.Name,
                    BaudRate = ModbusPortParameters.BaudRate,
                    Parity = ModbusPortParameters.Parity,
                    StopBits = ModbusPortParameters.StopBits,
                    DataBits = ModbusPortParameters.DataBits,
                    DtrEnable = false,
                    RtsEnable = false,
                    DiscardNull = true,
                    ReadBufferSize = 4096,
                    WriteTimeout = 5,
                    ReadTimeout = 500
                };
            }
            catch { return false; }

            bool isConnected = false;
            try
            {
                lock (typeof(RS485))
                {
                    if (!port.IsOpen) port.Open();
                    port.Send(1, ModbusFunction.ReportSlaveID);
                    Thread.Sleep(100);
                    var response = port.Receive();
                    isConnected = (response != null);
                }
            }
            catch (Exception) { }
            finally
            {
                if (!isConnected && port.IsOpen) port.Close();
            }

            Connected = isConnected;
            return Connected;
        }

        public void SendReadRegister(ushort address, ushort words = 1)
        {
            Send(1, ModbusFunction.ReadHoldingRegisters, address, words);
        }

        public void SendReadBit(ushort address)
        {
            Send(1, ModbusFunction.ReadInputStatus, address, 8);
        }

        public void SendWriteRegister(ushort address, ushort value)
        {
            Send(1, ModbusFunction.WriteSingleRegister, address, value);
        }

        public void SendWriteBit(ushort address, bool value)
        {
            Send(1, ModbusFunction.WriteSingleCoil, address, (ushort)(value ? 0xff00 : 0));
        }

        public void Send(byte slaveId, ModbusFunction functionCode, ushort address, ushort value)
        {
            if (Connected)
                lock (port)
                {
                    port.Send(slaveId, functionCode, address, value);
                }
        }

        public static ModbusPort.Message Read()
        {
            if (Connected)
                lock (port)
                {
                    try { return port.Receive(); } catch (ModbusFrameException) { }
                }
            return null;
        }

        public static ushort Read(ushort def)
        {
            if (Connected)
                lock (port)
                {
                    try
                    {
                        def = port.ReceiveValue();
                    }
                    catch (TimeoutException) { }
                    catch (ModbusFrameException) { }
                }
            return def;
        }

        public static uint Read(uint def)
        {
            if (Connected)
                lock (port)
                {
                    try
                    {
                        def = port.Receive().GetValue<uint>();
                    }
                    catch (TimeoutException) { }
                    catch (ModbusFrameException) { }
                }
            return def;
        }


        public void ClearBuffer()
        {
            if (Connected) try
                {
                    lock (port)
                    {
                        port.ReadExisting();
                    }
                }
                catch
                {
                }
        }
    }
}
