using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO.Ports;
using System.Linq;
using System.Text;

namespace STM.BLayer.StmTest
{
    public class ModbusPort : SerialPort
    {
        private const string ModbusNewLine = "\r\n";

        public enum ModbusFunction : byte
        {
            Unknown = 0,
            ReadCoilStatus = 1,
            ReadInputStatus = 2,
            ReadHoldingRegisters = 3,
            ReadInputRegisters = 4,
            WriteSingleCoil = 5,
            WriteSingleRegister = 6,
            Diagnostics = 8,
            DiagnosticsReturnQueryData = 0,
            WriteMultipleCoils = 15,
            WriteMultipleRegisters = 16,
            ReportSlaveID = 17,
            ReadWriteMultipleRegisters = 23,
            CommandError = 0x80,
        }

        public enum ModbusExceptionCode : byte
        {
            None = 0,
            IllegalCommand = 1,
            IllegalDeviceAddress = 2,
            IllegalDeviceValue = 3,
            ChecksumError = 7
        }

        public class ModbusFrameException : Exception
        {
            public string Frame { get; set; }

            public ModbusFrameException() : base() { }

            public ModbusFrameException(string message) : base(message) { }

            public ModbusFrameException(string message, Exception innerException) : base(message, innerException) { }
        }

        public class Message
        {
            public byte SlaveId { get; set; }
            public ModbusFunction FunctionCode { get; set; }
            public ushort Address { get; set; }

            private byte[] Value;


            public Message() { }

            public Message(byte slaveID, ModbusFunction functionCode)
            {
                SlaveId = slaveID;
                FunctionCode = functionCode;
            }

            public Message(byte slaveID, ModbusFunction functionCode, ushort address, params byte[] value)
                : this(slaveID, functionCode)
            {
                Address = address;
                Value = value;
            }

            public Message(string frame)
            {
                FromFrame(frame);
            }


            public bool IsWriteRegister() =>
                FunctionCode == ModbusFunction.WriteSingleRegister || FunctionCode == ModbusFunction.WriteMultipleRegisters
                 || FunctionCode == ModbusFunction.ReadWriteMultipleRegisters;

            public bool IsWriteCoil() =>
                FunctionCode == ModbusFunction.WriteSingleCoil || FunctionCode == ModbusFunction.WriteMultipleCoils;

            public bool IsReadRegister() =>
                FunctionCode == ModbusFunction.ReadHoldingRegisters || FunctionCode == ModbusFunction.ReadInputRegisters
                || FunctionCode == ModbusFunction.ReadWriteMultipleRegisters;

            public bool IsReadCoil() =>
                FunctionCode == ModbusFunction.ReadCoilStatus || FunctionCode == ModbusFunction.ReadInputStatus;

            public bool ReportSlaveID() =>
                FunctionCode == ModbusFunction.ReportSlaveID;

            public bool IsException() =>
                (FunctionCode & ModbusFunction.CommandError) != 0;


            public void SetValue(params byte[] value)
            {
                Value = value;
            }

            public void SetValue(char value)
            {
                SetValue(new byte[] { (byte)value });
            }

            public void SetValue(byte value)
            {
                SetValue(new byte[] { value });
            }

            public void SetValue(sbyte value)
            {
                SetValue(new byte[] { (byte)value });
            }

            public void SetValue(short value)
            {
                SetValue(new byte[] { (byte)((value & 0xFF00) >> 8), (byte)(value & 0x00FF) });
            }

            public void SetValue(ushort value)
            {
                SetValue(new byte[] { (byte)((value & 0xFF00) >> 8), (byte)(value & 0x00FF) });
            }

            public void SetValue(int value)
            {
                SetValue(new byte[] {
                    (byte)((value & 0xFF000000) >> 24),
                    (byte)((value & 0x00FF0000) >> 16),
                    (byte)((value & 0x0000FF00) >> 8),
                    (byte)(value & 0x000000FF)
                });
            }

            public void SetValue(uint value)
            {
                SetValue(new byte[] {
                    (byte)((value & 0xFF000000) >> 24),
                    (byte)((value & 0x00FF0000) >> 16),
                    (byte)((value & 0x0000FF00) >> 8),
                    (byte)(value & 0x000000FF)
                });
            }


            public byte[] GetValue() { return Value; }

            public T GetValue<T>(T def = default(T))
            {
                object value = def;

                if (Value != null && Value.Length > 0)
                    try
                    {
                        switch (Type.GetTypeCode(typeof(T)))
                        {
                            case TypeCode.Byte:
                                value = (byte)(Value[0] & 0xFF);
                                break;
                            case TypeCode.SByte:
                                value = (sbyte)(Value[0] & 0xFF);
                                break;
                            case TypeCode.Char:
                                value = (char)(Value[0] & 0xFF);
                                break;
                            case TypeCode.Boolean:
                                value = (Value[0] & 0xFF) != 0;
                                break;
                            case TypeCode.Int16:
                                if (Value.Length >= 2)
                                    value = (short)(((short)Value[0] << 8) + (short)Value[1]);
                                else
                                    value = (short)Value[0];
                                break;
                            case TypeCode.UInt16:
                                if (Value.Length >= 2)
                                    value = (ushort)(((ushort)Value[0] << 8) + (ushort)Value[1]);
                                else
                                    value = (ushort)Value[0];
                                break;
                            case TypeCode.Int32:
                                if (Value.Length >= 4)
                                    value = (int)(((int)Value[0] << 24) + ((int)Value[1] << 16) + ((int)Value[2] << 8) + (int)Value[3]);
                                else if (Value.Length >= 2)
                                    value = (int)(((int)Value[0] << 8) + (int)Value[1]);
                                else
                                    value = (int)Value[0];
                                break;
                            case TypeCode.UInt32:
                                if (Value.Length >= 4)
                                    value = (uint)(((uint)Value[0] << 24) + ((uint)Value[1] << 16) + ((uint)Value[2] << 8) + (uint)Value[3]);
                                else if (Value.Length >= 2)
                                    value = (uint)(((uint)Value[0] << 8) + (uint)Value[1]);
                                else
                                    value = (uint)Value[0];
                                break;
                                //case TypeCode.Int64:
                                //    value = BitConverter.ToInt64(Value, 0);
                                //    break;
                                //case TypeCode.UInt64:
                                //    value = BitConverter.ToUInt64(Value, 0);
                                //    break;
                                //case TypeCode.Single:
                                //    value = BitConverter.ToSingle(Value, 0);
                                //    break;
                                //case TypeCode.Double:
                                //    value = BitConverter.ToDouble(Value, 0);
                                //    break;
                                //case TypeCode.String:
                                //    value = BitConverter.ToString(Value, 0);
                                //    break;
                        }
                    }
                    catch (ArgumentException)
                    {
                        return def;
                    }

                return (T)value;
            }


            protected void FromFrame(string frame)
            {
                if (frame != null && frame.Length > 3 && frame.StartsWith(":"))
                {
                    if (frame.EndsWith(ModbusNewLine))
                        frame = frame.Substring(0, frame.Length - ModbusNewLine.Length);
                    if (frame.EndsWith("\r"))
                        frame = frame.Substring(0, frame.Length - "\r".Length);
                    if (frame.EndsWith("\n"))
                        frame = frame.Substring(0, frame.Length - "\n".Length);
                    var value = new byte[frame.Length >> 1];
                    var index = 0;
                    for (var i = 1; i < frame.Length; i += 2)
                        try
                        {
                            var b = frame.Substring(i, 2);
                            var v = int.Parse(b, System.Globalization.NumberStyles.HexNumber);
                            value[index++] = (byte)v;
                        }
                        catch (Exception ex)
                        {
                            throw new ModbusFrameException("Invalid Frame", ex) { Frame = frame };
                        }
                    var lrc = GetLRC(value, 0, value.Length - 1);
                    if (lrc != value[value.Length - 1])
                        throw new ModbusFrameException("Frame LRC Mismatch") { Frame = frame };

                    SlaveId = value[0];
                    FunctionCode = (ModbusFunction)value[1];
                    try
                    {
                        if (IsReadRegister())
                        {
                            index = value[2];
                            Value = new byte[index];
                            for (var i = 0; i < index; i++)
                                Value[i] = value[3 + i];
                        }
                        else if (IsReadCoil())
                        {
                            index = value[2];
                            Value = new byte[index];
                            for (var i = 0; i < index; i++)
                                Value[i] = (byte)(value[3 + i] & 0xFF);
                        }
                        else if (IsWriteCoil() || IsWriteRegister())
                        {
                        }
                        else if (ReportSlaveID())
                        {
                            index = value[2];
                            Value = new byte[index];
                            for (var i = 0; i < index; i++)
                                Value[i] = (byte)(value[3 + i] & 0xFF);
                        }
                        else if (IsException())
                        {
                            Value = new byte[1];
                            Value[0] = value[2];
                        }
                        else
                            throw new ModbusFrameException($"Unsupported Function Code {FunctionCode}") { Frame = frame };
                    }
                    catch (Exception ex)
                    {
                        throw new ModbusFrameException("Invalid Frame Data", ex) { Frame = frame };
                    }
                }
                else
                    throw new ModbusFrameException("Invalid Frame") { Frame = frame };
            }


            protected string GetFrame()
            {
                return GetFrame(this);
            }


            public static string GetFrame(Message message)
            {
                return GetFrame(message.SlaveId, message.FunctionCode, message.Address, message.Value);
            }

            public static string GetFrame(byte slaveId, ModbusFunction functionCode)
            {
                var frame = new byte[2];
                frame[0] = slaveId;
                frame[1] = (byte)functionCode;
                var lrc = GetLRC(frame);
                var sb = new StringBuilder();
                sb.Append(':');
                foreach (var v in frame)
                    sb.Append(v.ToString("X2"));
                sb.Append(lrc.ToString("X2")).Append(ModbusNewLine);
                return sb.ToString();
            }

            public static string GetFrame(byte slaveId, ModbusFunction functionCode, ushort address, params byte[] value)
            {
                var frame = new byte[(value?.Length ?? 0) + 4];
                frame[0] = slaveId;
                frame[1] = (byte)functionCode;
                frame[2] = (byte)((address & 0xFF00) >> 8);
                frame[3] = (byte)(address & 0xFF);
                if (value != null)
                {
                    var index = 4;
                    foreach (var v in value)
                    {
                        frame[index++] = v;
                    }
                }
                var lrc = GetLRC(frame);
                var sb = new StringBuilder();
                sb.Append(':');
                foreach (var v in frame)
                    sb.Append(v.ToString("X2"));
                sb.Append(lrc.ToString("X2")).Append(ModbusNewLine);
                return sb.ToString();
            }

            public static string GetFrame(byte slaveId, ModbusFunction functionCode, ushort address, params ushort[] value)
            {
                var frame = new byte[((value?.Length ?? 0) << 1) + 4];
                frame[0] = slaveId;
                frame[1] = (byte)functionCode;
                frame[2] = (byte)((address & 0xFF00) >> 8);
                frame[3] = (byte)(address & 0xFF);
                if (value != null)
                {
                    var index = 4;
                    foreach (var v in value)
                    {
                        frame[index++] = (byte)((v & 0xFF00) >> 8);
                        frame[index++] = (byte)(v & 0x00FF);
                    }
                }
                var lrc = GetLRC(frame);
                var sb = new StringBuilder();
                sb.Append(':');
                foreach (var v in frame)
                    sb.Append(v.ToString("X2"));
                sb.Append(lrc.ToString("X2")).Append(ModbusNewLine);
                return sb.ToString();
            }


            protected static byte GetLRC(byte[] data)
            {
                var lrc = 0;
                foreach (byte b in data)
                    lrc -= b;
                return (byte)lrc;
            }

            protected static byte GetLRC(byte[] data, int startIndex, int length)
            {
                length += startIndex;
                var lrc = 0;
                for (var index = startIndex; index < length; index++)
                    lrc -= data[index];
                return (byte)lrc;
            }

            protected static byte GetLRC(string frame)
            {
                var length = frame.Length;
                if (frame.EndsWith(ModbusNewLine))
                    length -= ModbusNewLine.Length;
                else if (frame.EndsWith("\r"))
                    length -= "\r".Length;

                var i = frame.StartsWith(":") ? 1 : 0;
                if (i > 0)
                {
                    length -= 2; // LRC
                } else
                {
                    frame = frame.TrimEnd('\n', '\r', ' ');
                    if(frame.IndexOf(' ') >=0)
                    {

                    }
                    length = frame.Length;
                }
                var value = new byte[(length - i) >> 1];
                for (var index = 0; i < length; i += 2)
                    try
                    {
                        var b = frame.Substring(i, 2);
                        var v = int.Parse(b, System.Globalization.NumberStyles.HexNumber);
                        value[index++] = (byte)v;
                    }
                    catch (Exception ex)
                    {
                        throw new ModbusFrameException("Invalid Frame", ex) { Frame = frame };
                    }
                return GetLRC(value);
            }


            public override string ToString()
            {
                return GetFrame(this);
            }
        }

        #region Constructors

        public ModbusPort() : base()
        {
        }

        public ModbusPort(IContainer container) : base(container)
        {
        }

        public ModbusPort(string portName) : base(portName)
        {
        }

        public ModbusPort(string portName, int baudRate) : base(portName, baudRate)
        {
        }

        public ModbusPort(string portName, int baudRate, Parity parity) : base(portName, baudRate, parity)
        {
        }

        public ModbusPort(string portName, int baudRate, Parity parity, int dataBits) : base(portName, baudRate, parity, dataBits)
        {
        }

        public ModbusPort(string portName, int baudRate, Parity parity, int dataBits, StopBits stopBits) : base(portName, baudRate, parity, dataBits, stopBits)
        {
        }

        #endregion

        public void Send(Message message)
        {
            var frame = Message.GetFrame(message);
            base.Write(frame);
        }

        public void Send(byte slaveId, ModbusFunction functionCode)
        {
            var frame = Message.GetFrame(slaveId, functionCode);
            base.Write(frame);
        }

        public void Send(byte slaveId, ModbusFunction functionCode, ushort address, params ushort[] value)
        {
            var frame = Message.GetFrame(slaveId, functionCode, address, value);
            base.Write(frame);
        }

        public Message Receive()
        {
            try
            {
                var response = base.ReadLine();
                var message = new Message(response);
                return message;
            }
            catch (TimeoutException) { return null; }            
        }

        public ushort ReceiveValue()
        {
            return Receive()?.GetValue<ushort>() ?? 0;
        }
    }
}
