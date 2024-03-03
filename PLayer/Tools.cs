using System;
using System.Windows.Forms;
using System.ComponentModel;
using System.Drawing;
using STM.DLayer;
using STM.Extensions;

namespace STM.PLayer
{
    public class TippedTextBox : TextBox
    {
        ToolTip tip;

        string[] stip;
        public string[] Tip
        {
            set
            {
                if (value == null)
                    return;
                try
                {
                    stip = value;

                    tip = new ToolTip { ToolTipTitle = stip[0] };
                    tip.SetToolTip(this, value[1]);
                }
                catch (Exception exception)
                {
                    exception.ToString();
                }
            }
            get { return stip; }
        }
    }

    public class NRTextBox : TippedTextBox
    {
        private bool validData;

        [Category("Option")]
        public DataType DataType
        {
            set;
            get;
        }
        [Category("Option")]
        public double Resolution
        {
            set;
            get;
        }

        public int ValueInInt
        {
            get
            {
                try
                {
                    return int.Parse(Text);
                }
                catch
                {
                    Text = DefaultValue;
                }
                return (int)double.Parse(Text);
            }
        }
        public float ValueInFoalt
        {
            get
            {
                try
                {
                    return float.Parse(Text);
                }
                catch
                {
                    Text = DefaultValue;
                }
                return float.Parse(Text);
            }
        }
        public double ValueInDouble
        {
            get
            {
                try
                {
                    if (FractionalDigits == 0)
                        return double.Parse(Text);
                    return Math.Round(double.Parse(Text), FractionalDigits);
                }
                catch
                {
                    Text = DefaultValue;
                }
                return double.Parse(Text);
            }
        }

        [Category("Option"), DefaultValue(0)]
        public string DefaultValue
        {
            get;
            set;
        }
        [Category("Option"), DefaultValue(0)]
        public string MaxValue
        {
            get;
            set;
        }
        [Category("Option"), DefaultValue(0)]
        public string MinValue
        {
            get;
            set;
        }
        [Category("Option"), DefaultValue(1)]
        public int FractionalDigits { get; set; }

        [Category("Option")]
        public bool CheckInRange
        {
            set;
            get;
        }

        public bool ValidData()
        {
            if (validData == false)
            {
                BackColor = Color.Red;
                Focus();
            }
            else
                BackColor = Color.White;

            return validData;
        }

        protected override void OnEnter(EventArgs e)
        {
            base.OnEnter(e);
            CheckResolution();
            Select();
        }
        protected override void OnLeave(EventArgs e)
        {
            base.OnLeave(e);
            CheckResolution();
        }
       

        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            CheckDataType();
        }

        private void CheckDataType()
        {
            if (Text == "")
            {
                validData = false;
                BackColor = Color.White;
            }
            else
            {
                if (DataType == DataType.Int)
                {
                    try
                    {
                        int.Parse(Text);
                        BackColor = Color.White;
                        validData = true;
                    }
                    catch
                    {
                        validData = false;
                        BackColor = Color.Red;
                    }
                }
                else
                {
                    try
                    {
                        double.Parse(Text);
                        BackColor = Color.White;
                        validData = true;
                    }
                    catch
                    {
                        validData = false;
                        BackColor = Color.Red;
                    }
                }
            }
        }

        private void CheckResolution()
        {
            if (CheckInRange)
                CheckValueInRange();
            return;
            if (DataType != DLayer.DataType.Int)
                try
                {
                    var format = "{0:0.";
                    for (int i = 0; i < FractionalDigits; i++)
                        format += "#";
                    if (FractionalDigits == 0)
                        format = "{0:0.#";
                    format += "}";
                    Text = string.Format(format, ValueInDouble);

                }
                catch (Exception exception)
                {
                    exception.ToString();
                }

        }
        private void CheckValueInRange()
        {
            if (MinValue.ToDouble() < MaxValue.ToDouble())
            {
                if (Text.ToDouble() < MinValue.ToDouble())
                {
                    Text = MinValue;
                    //CheckResolution();
                }
                else if (MaxValue.ToDouble() < Text.ToDouble())
                {
                    Text = MaxValue;
                    //CheckResolution();
                }
            }

        }

        public void Validate()
        {
            CheckValueInRange();
            CheckDataType();
        }

        public NRTextBox()
        {
            DataType = DataType.Int;
            CheckInRange = false;
            DefaultValue = "0";
            MinValue = "0";
            MaxValue = "0";
            FractionalDigits = 0;
            Resolution = 0;
        }

        [Localizable(false)]
        public override string Text
        {
            get
            {
                return base.Text;
            }
            set
            {
                base.Text = value;
                CheckValueInRange();
            }
        }
    }

    public sealed class BuletLinkLable : RadioButton
    {
        bool drawUnderLine;
        
        public BuletLinkLable()
        {
            ForeColor = Color.Blue;
        }

        protected override void OnClick(EventArgs e)
        {
            Checked = true;
            base.OnClick(e);
            Invalidate();
        }

        protected override void OnMouseUp(MouseEventArgs mevent)
        {
            Checked = true;
            base.OnMouseUp(mevent);
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            Checked = true;
            base.OnMouseClick(e);
            Invalidate();
        }

        protected override void OnMouseEnter(EventArgs eventargs)
        {
            base.OnMouseEnter(eventargs);
            drawUnderLine = true;
            Invalidate();
        }

        protected override void OnMouseLeave(EventArgs eventargs)
        {
            base.OnMouseLeave(eventargs);
            drawUnderLine = false;
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            base.OnPaint(pevent);
            if (Checked)
            {
                pevent.Graphics.FillRectangle(Brushes.Blue, new Rectangle(0, Margin.Top, (int)Font.GetHeight(), (int)Font.GetHeight()));
            }
            if (drawUnderLine)
            {
                pevent.Graphics.FillRectangle(Brushes.Green, new Rectangle(0, Margin.Top, (int)Font.GetHeight(), (int)Font.GetHeight()));
                pevent.Graphics.DrawLine(Pens.Blue, (int)Font.GetHeight(), (int)Font.GetHeight() + 5, Width - Margin.Right * 2, (int)Font.GetHeight() + 5);
            }
            else
            {
                using (Brush brush = new SolidBrush(BackColor))
                {
                    pevent.Graphics.FillRectangle(brush, new Rectangle(0, Margin.Top, (int)Font.GetHeight(), (int)Font.GetHeight()));
                }
            }
        }
    }
}
