using STM.DLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace STM.BLayer.StmTest
{
    internal class ParametersOfPLC
    {
        public const int NumberOfTemperaturChannels = 7;

        public enum Registers : ushort
        {
        }

        public enum Status : ushort
        {
        }

        public enum Temperatures : ushort
        {
            TemperatureZn1 = 6139,
            TemperatureZn2 = 6118,
            TemperatureZn3 = 6097,
            TemperatureAmb = 6164,
        }

        protected enum Faults : ushort
        {
        }

        public enum Commands : ushort
        {
            SetpointZn1dsp = 6161,
            SetpointZn2dsp = 6162,
            SetpointZn3dsp = 6163,
            SetpointZn1 = 6175,
            SetpointZn2 = 6176,
            SetpointZn3 = 6177,
        }

        private static object PortLock = new object();
        private static volatile bool DisableSend = false;

        public ushort TemperatureZn1;
        public ushort TemperatureZn2;
        public ushort TemperatureZn3;
        public ushort TemperatureAmb;
        public ushort SetpointZn1dsp;
        public ushort SetpointZn2dsp;
        public ushort SetpointZn3dsp;
        public ushort SetpointZn1;
        public ushort SetpointZn2;
        public ushort SetpointZn3;


        private ParametersOfPLC() { }

        public static ParametersOfPLC Current = new ParametersOfPLC();

        public ParametersOfPLC Clone()
        {
            var plc = new ParametersOfPLC
            {
                TemperatureZn1 = this.TemperatureZn1,
                TemperatureZn2 = this.TemperatureZn2,
                TemperatureZn3 = this.TemperatureZn3,
                TemperatureAmb = this.TemperatureAmb,
                SetpointZn1dsp = this.SetpointZn1dsp,
                SetpointZn2dsp = this.SetpointZn2dsp,
                SetpointZn3dsp = this.SetpointZn3dsp,
                SetpointZn1 = this.SetpointZn1,
                SetpointZn2 = this.SetpointZn2,
                SetpointZn3 = this.SetpointZn3,
            };
            return plc;
        }

        private volatile Commands plcCommand = 0;
        public Commands Command
        {
            set
            {
                lock (PortLock)
                {
                    if (plcCommand != value)
                    {
                        var command = plcCommand;
                        plcCommand = value;
                    }
                }
            }
            get
            {
                lock (PortLock)
                {
                    return plcCommand;
                }
            }
        }

        public bool BeginExecuteCommand(bool value)
        {
            lock (PortLock)
                if (!DisableSend)
                {
                    if (plcCommand != 0)
                    {
                        switch (plcCommand)
                        {
                            case Commands.SetpointZn1:
                            case Commands.SetpointZn2:
                            case Commands.SetpointZn3:
                            case Commands.SetpointZn1dsp:
                            case Commands.SetpointZn2dsp:
                            case Commands.SetpointZn3dsp:
                                return SendWriteBit((ushort)plcCommand, value);
                        }
                    }
                    else
                        return true;
                }
            return false;
        }

        public bool FinishExecuteCommand()
        {
            if (plcCommand != 0)
            {
                if (RecieveWriteBit())
                    Command = 0;
                else
                    return false;
            }
            return true;
        }

        public bool BeginExecuteCommand(Commands command, bool value)
        {
            lock (PortLock)
                if (!DisableSend)
                {
                    if (command != 0)
                    {
                        return SendWriteBit((ushort)command, value);
                    }
                    else
                        return true;
                }
            return false;
        }

        public bool FinishExecuteCommand(Commands command)
        {
            if (command != 0)
            {
                return RecieveWriteBit();
            }
            return true;
        }

        public bool UpdateTemperatures()
        {
            lock (PortLock)
                if (!DisableSend)
                {
                    getTemperatureZn1();
                    getTemperatureZn2();
                    getTemperatureZn3();
                    getTemperatureAmb();
                    return true;
                }
            return false;
        }


        protected ushort getTemperatureZn1() { return TemperatureZn1 = ReadRegister((ushort)Temperatures.TemperatureZn1, TemperatureZn1); }
        protected ushort getTemperatureZn2() { return TemperatureZn2 = ReadRegister((ushort)Temperatures.TemperatureZn2, TemperatureZn2); }
        protected ushort getTemperatureZn3() { return TemperatureZn3 = ReadRegister((ushort)Temperatures.TemperatureZn3, TemperatureZn3); }
        protected ushort getTemperatureAmb() { return TemperatureAmb = ReadRegister((ushort)Temperatures.TemperatureAmb, TemperatureAmb); }


        public int Read(int channel)
        {
            switch (((channel - 1) % 4) + 1)
            {
                case 1: return getTemperatureZn1();
                case 2: return getTemperatureZn2();
                case 3: return getTemperatureZn3();
                case 4: return getTemperatureAmb();
            }
            return 0;
        }

        public bool Set(int channel, int setPoint)
        {
            switch (channel)
            {
                case 1: return setSetpointZn1dsp((ushort)setPoint);
                case 2: return setSetpointZn2dsp((ushort)setPoint);
                case 3: return setSetpointZn3dsp((ushort)setPoint);
                case 4: return true;
                case 5: return setSetpointZn1((ushort)setPoint);
                case 6: return setSetpointZn2((ushort)setPoint);
                case 7: return setSetpointZn3((ushort)setPoint);
            }
            return false;
        }

        public bool Set(int setPoints)
        {
            var ok = true;
            for (int channel = 1; channel <= NumberOfTemperaturChannels; channel++)
                ok &= Set(channel, setPoints);
            return ok;
        }

        public bool Set(params int[] setPoints)
        {
            var ret = true;
            for (var channel = 1; channel<= NumberOfTemperaturChannels && channel < setPoints.Length; channel++)
                try
                {
                    var response = Set(channel, setPoints[channel - 1]);
                }
                catch { ret = false; }

            return ret;
        } 

        protected bool setSetpointZn1(ushort value)
        {
            if (WriteRegister((ushort)Commands.SetpointZn1, value))
            {
                SetpointZn1 = value;
                return true;
            }
            return false;
        }
        protected bool setSetpointZn2(ushort value)
        {
            if (WriteRegister((ushort)Commands.SetpointZn2, value))
            {
                SetpointZn2 = value;
                return true;
            }
            return false;
        }
        protected bool setSetpointZn3(ushort value)
        {
            if (WriteRegister((ushort)Commands.SetpointZn3, value))
            {
                SetpointZn3 = value;
                return true;
            }
            return false;
        }


        protected bool setSetpointZn1dsp(ushort value)
        {
            if (WriteRegister((ushort)Commands.SetpointZn1dsp, value))
            {
                SetpointZn1dsp = value;
                return true;
            }
            return false;
        }
        protected bool setSetpointZn2dsp(ushort value)
        {
            if (WriteRegister((ushort)Commands.SetpointZn2dsp, value))
            {
                SetpointZn2dsp = value;
                return true;
            }
            return false;
        }
        protected bool setSetpointZn3dsp(ushort value)
        {
            if (WriteRegister((ushort)Commands.SetpointZn3dsp, value))
            {
                SetpointZn3dsp = value;
                return true;
            }
            return false;
        }


        protected bool ReadBit(ushort address, bool value)
        {
            return (ReadByte(address, (byte)(value ? 1 : 0)) & 1) != 0;
        }

        protected bool RecieveReadBit(bool def, out bool result)
        {
            byte rByte;
            var read = RecieveReadByte((byte)(def ? 1 : 0), out rByte);
            if (read) result = ((rByte) & 1) != 0; else result = def;
            return read;
        }

        protected bool SendReadBit(ushort address)
        {
            return SendReadByte(address);
        }


        protected byte ReadByte(ushort address, byte value)
        {
            lock (PortLock)
                if (!DisableSend)
                {
                    DisableSend = true;
                    RS485.Current.SendReadBit(address);
                    Thread.Sleep(100);
                    var response = RS485.Read();
                    if (response != null) value = response.GetValue<byte>(value);
                    DisableSend = false;
                }
            return value;
        }

        protected bool RecieveReadByte(byte def, out byte result)
        {
            var read = false;
            result = def;
            lock (PortLock)
                if (DisableSend)
                    try
                    {
                        read = true;
                        var response = RS485.Read();
                        if (response != null) result = response.GetValue<byte>(def);
                    }
                    finally
                    {
                        DisableSend = false;
                    }
            return read;
        }

        protected bool SendReadByte(ushort address)
        {
            lock (PortLock)
                if (!DisableSend)
                {
                    RS485.Current.SendReadBit(address);
                    DisableSend = true;
                    return true;
                }
            return false;
        }


        protected ushort ReadRegister(ushort address, ushort value)
        {
            lock (PortLock)
                if (!DisableSend)
                {
                    DisableSend = true;
                    RS485.Current.SendReadRegister(address);
                    Thread.Sleep(100);
                    value = RS485.Read(value);
                    DisableSend = false;
                }
            return value;
        }

        protected uint ReadRegister(ushort address, uint value)
        {
            lock (PortLock)
                if (!DisableSend)
                {
                    DisableSend = true;
                    RS485.Current.SendReadRegister(address);
                    Thread.Sleep(100);
                    value = RS485.Read(value);
                    DisableSend = false;
                }
            return value;
        }

        public bool RecieveReadRegistere(ushort def, out ushort result)
        {
            var read = false;
            result = def;
            lock (PortLock)
                if (DisableSend)
                    try
                    {
                        read = true;
                        result = RS485.Read(def);
                    }
                    finally
                    {
                        DisableSend = false;
                    }
            return read;
        }

        public bool SendReadRegister(ushort address)
        {
            lock (PortLock)
                if (!DisableSend)
                {
                    RS485.Current.SendReadRegister(address);
                    DisableSend = true;
                    return true;
                }
            return false;
        }


        protected bool WriteRegister(ushort address, ushort value)
        {
            lock (PortLock)
                if (!DisableSend)
                {
                    RS485.Current.SendWriteRegister(address, value);
                    Thread.Sleep(100);
                    var response = RS485.Read();
                    if (response != null)
                    {
                        return response.IsWriteRegister();
                    }
                }
            return false;
        }

        protected bool WriteBit(ushort address, bool value)
        {
            if (SendWriteBit(address, value))
            {
                Thread.Sleep(100);
                return RecieveWriteBit();
            }
            return false;
        }

        protected bool RecieveWriteBit()
        {
            var write = false;
            lock (PortLock)
                if (DisableSend)
                    try
                    {
                        write = true;
                        var response = RS485.Read();
                    }
                    finally
                    {
                        DisableSend = false;
                    }
            return write;
        }

        protected bool SendWriteBit(ushort address, bool value)
        {
            lock (PortLock)
                if (!DisableSend)
                {
                    RS485.Current.SendWriteBit(address, value);
                    DisableSend = true;
                    return true;
                }
            return false;
        }
    }
}