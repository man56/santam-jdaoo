using STM.DLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace STM.DLayer
{
    internal class TMPR485
    {
        public const int NumberOfTemperaturChannels = 7;
        private const int CQ_DELAY = 20;

        public enum Temperatures : ushort
        {
            TemperatureZn1 = 6160,
            TemperatureZn2 = 6161,
            TemperatureZn3 = 6162,
            TemperatureAmb = 6163,
            SetpointZn1 = 6138,
            SetpointZn2 = 6117,
            SetpointZn3 = 6096,
        }

        public enum Commands : ushort
        {
            SetpointZn1dsp = 6177,
            SetpointZn2dsp = 6177,
            SetpointZn3dsp = 6177,
            SetpointZn1 = 6176,
            SetpointZn2 = 6175,
            SetpointZn3 = 6174,
        }

        private static object PortLock = new object();
        private static volatile bool DisableSend = false;

        public static bool Connected { get { return RS485.Connected; } }

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


        private TMPR485() { }

        public static TMPR485 Current = new TMPR485();

        public TMPR485 Clone()
        {
            var plc = new TMPR485
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
        protected ushort getSetpointZn1() { return SetpointZn1 = ReadRegister((ushort)Temperatures.SetpointZn1, SetpointZn1); }
        protected ushort getSetpointZn2() { return SetpointZn2 = ReadRegister((ushort)Temperatures.SetpointZn2, SetpointZn2); }
        protected ushort getSetpointZn3() { return SetpointZn3 = ReadRegister((ushort)Temperatures.SetpointZn3, SetpointZn3); }


        public int Read(int channel)
        {
            ushort value = 0;
            if (Connected)
                switch (BLayer.Parameters.InstrumentParameters.TemperatureChannelMapping[channel])
                {
                    case 0: value = getTemperatureAmb(); break;
                    case 1: value = getSetpointZn1(); break;
                    case 2: value = getSetpointZn2(); break;
                    case 3: value = getSetpointZn3(); break;
                    case 4: value = getTemperatureZn1(); break;
                    case 5: value = getTemperatureZn2(); break;
                    case 6: value = getTemperatureZn3(); break;
                }
            if (value > BLayer.Parameters.InstrumentParameters.TemperatureMax * 10) value = 0;
            return value;
        }

        public bool Set(int channel, float setPoint)
        {
            if (Connected)
                switch (/*BLayer.Parameters.InstrumentParameters.TemperatureChannelMapping[]*/channel)
                {
                    case 1: return setSetpointZn1(setPoint);
                    case 2: return setSetpointZn2(setPoint);
                    case 3: return setSetpointZn3(setPoint);
                    case 4: return setSetpointZn1dsp(setPoint);
                    case 5: return setSetpointZn2dsp(setPoint);
                    case 6: return setSetpointZn3dsp(setPoint);
                    default: return true;
                }
            return false;
        }

        public bool Set(float setPoints)
        {
            var ok = true;
            for (var channel = 1; channel <= NumberOfTemperaturChannels; channel++)
                ok &= Set(channel, setPoints);
            return ok;
        }

        public bool Set(params float[] setPoints)
        {
            var ret = true;
            for (var channel = 0; channel <= NumberOfTemperaturChannels && channel < setPoints.Length; channel++)
                try
                {
                    var response = Set(channel, setPoints[channel]);
                }
                catch { ret = false; }

            return ret;
        }

        protected bool setSetpointZn1(float value)
        {
            var tmp = (ushort)(value * 10);
            if (WriteRegister((ushort)Commands.SetpointZn1, tmp))
            {
                SetpointZn1 = tmp;
                return true;
            }
            return false;
        }
        protected bool setSetpointZn2(float value)
        {
            var tmp = (ushort)(value * 10);
            if (WriteRegister((ushort)Commands.SetpointZn2, tmp))
            {
                SetpointZn2 = tmp;
                return true;
            }
            return false;
        }
        protected bool setSetpointZn3(float value)
        {
            var tmp = (ushort)(value * 10);
            if (WriteRegister((ushort)Commands.SetpointZn3, tmp))
            {
                SetpointZn3 = tmp;
                return true;
            }
            return false;
        }


        protected bool setSetpointZn1dsp(float value)
        {
            var tmp = (ushort)(value * 10);
            if (WriteRegister((ushort)Commands.SetpointZn1dsp, tmp))
            {
                SetpointZn1dsp = tmp;
                return true;
            }
            return false;
        }
        protected bool setSetpointZn2dsp(float value)
        {
            var tmp = (ushort)(value * 10);
            if (WriteRegister((ushort)Commands.SetpointZn2dsp, tmp))
            {
                SetpointZn2dsp = tmp;
                return true;
            }
            return false;
        }
        protected bool setSetpointZn3dsp(float value)
        {
            var tmp = (ushort)(value * 10);
            if (WriteRegister((ushort)Commands.SetpointZn3dsp, tmp))
            {
                SetpointZn3dsp = tmp;
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
                    Thread.Sleep(CQ_DELAY);
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
                    Thread.Sleep(CQ_DELAY);
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
                    Thread.Sleep(CQ_DELAY);
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
                    Thread.Sleep(CQ_DELAY);
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
                Thread.Sleep(CQ_DELAY);
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
