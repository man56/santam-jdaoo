using System;
using System.Collections.Generic;
using System.Linq;
using STM.BLayer.TestSample;
using STM.PLayer.Report;

namespace STM.BLayer.StmTest
{
    public class TestingSample
    {
        #region common

        public double Thickness { set; get; }
        public double Width { set; get; }
        public double GagueLength { set; get; }
        public double TotalLength { set; get; }
        public double R1 { set; get; }
        public double R2 { set; get; }
        public string Id { set; get; }

        private string saveString;

        #endregion

        #region Tension Compression

        public double Area { set; get; }
        public double Weight { set; get; }
        public double Density { set; get; }
        public TensionCompressionSampleType TensionCompressionSampleType { set; get; }

        #endregion

        #region Bending

        public double L { set; get; }
        public double l { set; get; }
        public double Inertia { set; get; }
        public bool ThreePoint { set; get; }
        public BendingSampleType BendingSampleType { set; get; }

        #endregion

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="sampleType">type of bending sample</param>
        /// <param name="threePoint">true if three point bending</param>
        /// <param name="sampleName">sample id</param>
        /// <param name="L">Support length</param>
        /// <param name="l">load position length</param>
        /// <param name="dim1">diameter(circular && pipe), width (rectangular), inertia(inertia) </param>
        /// <param name="dim2">thickness(rectangular), inner diameter(pipe) </param>
        public TestingSample(BendingSampleType sampleType, bool threePoint, string sampleName, double L, double l, double dim1 = 0, double dim2 = 0)
        {
            SetBendingSample(sampleType, threePoint, sampleName, L, l, dim1, dim2);
        }

        private void SetBendingSample(BendingSampleType sampleType, bool threePoint, string sampleName, double l0, double l1, double dim1, double dim2)
        {
            var spacer = ((char) 3).ToString();
            saveString = string.Format("{0} {1} {2} {3} {4} {5} {6} {7}", -1 + spacer, sampleType + spacer, threePoint + spacer, sampleName + spacer, l0 + spacer, l1 + spacer, dim1 + spacer, dim2 + spacer);
            BendingSampleType = sampleType;
            TensionCompressionSampleType = (TensionCompressionSampleType)(-1);
            L = l0;
            l = l1;
            Id = sampleName;
            ThreePoint = threePoint;
            switch (sampleType)
            {
                case BendingSampleType.Circular:
                    R1 = dim1;
                    Inertia = Math.PI * Math.Pow(R1, 4) / 64;
                    break;

                case BendingSampleType.Rectangular:
                    Width = dim1;
                    Thickness = dim2;
                    Inertia = Width * Math.Pow(Thickness, 3) / 12;
                    break;

                //case BendingSampleType.Pipe:
                //    R1 = dim1;
                //    R2 = dim2;
                //    break;

                case BendingSampleType.Inertia:
                    Inertia = dim1;
                    break;
            }
        }

        /// <summary>
        ///  Constructor
        /// </summary>
        /// <param name="sampleType">type of tension sample</param>
        /// <param name="sampleName">sample id</param>
        /// <param name="length">gauge length</param>
        /// <param name="dim1">diameter(circular && pipe), width(rectangular), density(weight), area(area) </param>
        /// <param name="dim2">thickness(rectangular), inner diameter(pipe), weight(weight)</param>
        /// <param name="dim3">total length (weight)</param>
        public TestingSample(TensionCompressionSampleType sampleType, string sampleName, double length, double dim1, double dim2, double dim3)
        {
            SetTensionCompressionSample(sampleType, sampleName, length, dim1, dim2, dim3);
        }

        private void SetTensionCompressionSample(TensionCompressionSampleType sampleType, string sampleName, double length, double dim1, double dim2, double dim3)
        {
            var spacer = ((char)3).ToString();
            saveString = string.Format("{0} {1} {2} {3} {4} {5} {6}", sampleType + spacer, -1 + spacer, sampleName + spacer, length + spacer, dim1 + spacer, dim2 + spacer, dim3 + spacer);
            BendingSampleType = (BendingSampleType)(-1);
            TensionCompressionSampleType = sampleType;
            Id = sampleName;
            GagueLength = length;
            switch (sampleType)
            {
                case TensionCompressionSampleType.Circular:
                    R1 = dim1;
                    Area = Math.PI*R1*R1/4;
                    break;

                case TensionCompressionSampleType.Tear:
                case TensionCompressionSampleType.Rectangular:
                    Width = dim1;
                    Thickness = dim2;
                    Area = Width*Thickness;
                    break;

                case TensionCompressionSampleType.Pipe:
                    R1 = dim1;
                    R2 = dim2;
                    Area = Math.PI*(R1 - R2)*(R1 + R2)/4;
                    break;

                case TensionCompressionSampleType.Oring:
                    R1 = dim1;
                    R2 = dim2;
                    Area = Math.PI*(R1 - R2)*(R1 + R2)/4;
                    break;

                case TensionCompressionSampleType.Weight:
                    Density = dim1;
                    Weight = dim2;
                    TotalLength = dim3;
                    Area = Weight/Density/(TotalLength/1000)*1e6;
                    break;

                case TensionCompressionSampleType.Area:
                    Area = dim1;
                    break;

                case TensionCompressionSampleType.Denier:
                    Density = dim1;
                    R1 = Math.Sqrt(dim1/(9000*dim2*0.7855));
                    Area = Math.PI*R1*R1/4;
                    break;

                case TensionCompressionSampleType.Tex:
                    Density = dim1;
                    R1 = Math.Sqrt(dim1/(1000*dim2*0.7855));
                    Area = Math.PI*R1*R1/4;
                    break;

               }
        }

        /// <summary>
        /// Retrives sample specification from saved context
        /// </summary>
        /// <param name="savedString"></param>
        public TestingSample(string savedString)
        {
            savedString = savedString.Remove(0, "Sample: ".Length);
            var parameters = savedString.Split((char)3).Select(p => p.Trim()).ToList();
            if (parameters[0] == "-1")
            {
                var sampleType = (BendingSampleType) Enum.Parse(typeof (BendingSampleType), parameters[1]);
                var threePoint = bool.Parse(parameters[2]);
                var sampleName = parameters[3];
                var ll0 = double.Parse(parameters[4]);
                var ll1 = double.Parse(parameters[5]);
                var dim1 = double.Parse(parameters[6]);
                var dim2 = double.Parse(parameters[7]);
                SetTensionCompressionSample((TensionCompressionSampleType)sampleType, sampleName, 0, dim1, dim2, 0);
                SetBendingSample(sampleType, threePoint, sampleName, ll0, ll1, dim1, dim2);
            }

            if (parameters[0] == "")
            {
                var sampleType = (TensionCompressionSampleType)Enum.Parse(typeof(TensionCompressionSampleType),
                    parameters[1].Substring(0, 1).ToUpper() + parameters[1].Substring(1).ToLower());
                var dim1 = double.Parse(parameters[2]);
                var dim2 = double.Parse(parameters[3]);
                var thickness = double.Parse(parameters[4]);
                var width = double.Parse(parameters[5]);
                var g_len = double.Parse(parameters[6]);
                var density = double.Parse(parameters[7]);
                var weight = double.Parse(parameters[8]);
                var total_len = double.Parse(parameters[9]);
                switch (sampleType)
                {
                    case TensionCompressionSampleType.Rectangular:
                        SetTensionCompressionSample(sampleType, "", g_len, width, thickness, total_len);
                        break;
                    case TensionCompressionSampleType.Circular:
                        SetTensionCompressionSample(sampleType, "", g_len, dim1, dim2, total_len);
                        break;
                    case TensionCompressionSampleType.Weight:
                        SetTensionCompressionSample(sampleType, "", g_len, density, weight, total_len);
                        break;
                }
            }
            else
            {
                var sampleType = (TensionCompressionSampleType)Enum.Parse(typeof(TensionCompressionSampleType), parameters[0]);
                var sampleName = parameters[2];
                var length = double.Parse(parameters[3]);
                var dim1 = double.Parse(parameters[4]);
                var dim2 = double.Parse(parameters[5]);
                var dim3 = double.Parse(parameters[6]);
                SetTensionCompressionSample(sampleType, sampleName, length, dim1, dim2, dim3);
            }
        }
        /// <summary>
        /// Returns true length after extention
        /// </summary>
        /// <param name="extention"></param>
        /// <returns></returns>
        public double GetTrueLength(double extention)
        {
            return GagueLength + extention;
        }

        public string GetSaveString()
        {
            return string.Format("Sample: {0}", saveString);
        }

        public List<ExeclReportParameter> ToReport()
        {
            var retVal = new List<ExeclReportParameter>{
                new ExeclReportParameter {Name = "ID", Value = Id},
                new ExeclReportParameter {
                    Name = "Sample Test Type",
                    Value = (int)TensionCompressionSampleType != -1? "Tension/Compression" : (ThreePoint ? "3 Point Bending" : "4 Point Bending")
                                         },
                    new ExeclReportParameter{
                        Name = "Sample Type",
                        Value = (int)TensionCompressionSampleType != -1? TensionCompressionSampleType.ToString() : BendingSampleType.ToString()}
            };

            #region Tension compression

            switch (TensionCompressionSampleType)
            {
                case TensionCompressionSampleType.Circular:
                    retVal.Add(new ExeclReportParameter { Name = "D", Value = string.Format("{0} mm", R1) });
                    break;

                case TensionCompressionSampleType.Oring:
                    retVal.Add(new ExeclReportParameter { Name = "D", Value = R1 + " mm" });
                    retVal.Add(new ExeclReportParameter { Name = "Width", Value = string.Format("{0} mm", Width) });
                    break;

                case TensionCompressionSampleType.Pipe:
                    retVal.Add(new ExeclReportParameter { Name = "D", Value = string.Format("{0} mm", R1) });
                    retVal.Add(new ExeclReportParameter { Name = "di", Value = string.Format("{0} mm", R2) });
                    break;

                case TensionCompressionSampleType.Rectangular:
                case TensionCompressionSampleType.Tear:
                    retVal.Add(new ExeclReportParameter { Name = "Width", Value = string.Format("{0} mm", Width) });
                    retVal.Add(new ExeclReportParameter { Name = "Thickness", Value = string.Format("{0} mm", Thickness) });
                    break;

                case TensionCompressionSampleType.Weight:
                    retVal.Add(new ExeclReportParameter { Name = "Density", Value = string.Format("{0} Kg/m3", Density) });
                    retVal.Add(new ExeclReportParameter { Name = "Weight", Value = string.Format("{0} Kg", Weight) });
                    retVal.Add(new ExeclReportParameter { Name = "Length", Value = string.Format("{0} mm", TotalLength) });
                    break;

            }

            #endregion
            #region Bending

            switch (BendingSampleType)
            {
                case BendingSampleType.Inertia:
                    retVal.Add(new ExeclReportParameter { Name = "Inertia", Value = string.Format("{0} mm4", Inertia) });
                    break;

                case BendingSampleType.Circular:
                    retVal.Add(new ExeclReportParameter { Name = "D", Value = string.Format("{0} mm", R1) });
                    break;

                //case BendingSampleType.Pipe:
                //    retVal.Add(new ExeclReportParameter { Name = "D", Value = string.Format("{0} mm", R1) });
                //    retVal.Add(new ExeclReportParameter { Name = "di", Value = string.Format("{0} mm", R2) });
                //    break;

                case BendingSampleType.Rectangular:
                    retVal.Add(new ExeclReportParameter { Name = "Width", Value = string.Format("{0} mm", Width) });
                    retVal.Add(new ExeclReportParameter { Name = "Thickness", Value = string.Format("{0} mm", Thickness) });
                    break;
            }

            #endregion

            if ((int)TensionCompressionSampleType != -1)
            {
                retVal.Add(new ExeclReportParameter { Name = "Area", Value = string.Format("{0} mm2", Area) });
            }
            else
            {
                retVal.Add(new ExeclReportParameter { Name = "Bending Type", Value = ThreePoint ? "3 Point Bending" : "4 Point Bending" });
                retVal.Add(new ExeclReportParameter { Name = "Inertia", Value = string.Format("{0} mm4", Inertia) });
            }

            retVal.Add(new ExeclReportParameter { Name = "Gauge Length", Value = string.Format("{0} mm", GagueLength) });

            retVal.Add(new ExeclReportParameter { Name = string.Empty, Value = string.Empty });

            return retVal;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof (TestingSample)) return false;
            return Equals((TestingSample) obj);
        }

        public bool Equals(TestingSample other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return other.Thickness.Equals(Thickness) &&
                   other.Width.Equals(Width) && 
                   other.GagueLength.Equals(GagueLength) && 
                   other.TotalLength.Equals(TotalLength) && 
                   other.R1.Equals(R1) && 
                   other.R2.Equals(R2) && 
                   other.Area.Equals(Area) && 
                   other.Weight.Equals(Weight) && 
                   other.Density.Equals(Density) && 
                   Equals(other.TensionCompressionSampleType, TensionCompressionSampleType) && 
                   other.L.Equals(L) &&
                   other.l.Equals(l) && 
                   other.Inertia.Equals(Inertia) && 
                   other.ThreePoint.Equals(ThreePoint) &&
                   Equals(other.BendingSampleType, BendingSampleType);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int result = (saveString != null ? saveString.GetHashCode() : 0);
                result = (result*397) ^ Thickness.GetHashCode();
                result = (result*397) ^ Width.GetHashCode();
                result = (result*397) ^ GagueLength.GetHashCode();
                result = (result*397) ^ TotalLength.GetHashCode();
                result = (result*397) ^ R1.GetHashCode();
                result = (result*397) ^ R2.GetHashCode();
                result = (result*397) ^ Area.GetHashCode();
                result = (result*397) ^ Weight.GetHashCode();
                result = (result*397) ^ Density.GetHashCode();
                result = (result*397) ^ TensionCompressionSampleType.GetHashCode();
                result = (result*397) ^ L.GetHashCode();
                result = (result*397) ^ l.GetHashCode();
                result = (result*397) ^ Inertia.GetHashCode();
                result = (result*397) ^ ThreePoint.GetHashCode();
                result = (result*397) ^ BendingSampleType.GetHashCode();
                return result;
            }
        }

        public static bool operator ==(TestingSample left, TestingSample right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(TestingSample left, TestingSample right)
        {
            return !Equals(left, right);
        }
    }

}
