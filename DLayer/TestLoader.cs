using System;
using System.Linq;
using STM.BLayer;
using System.IO;
using STM.BLayer.StmTest;
using STM.BLayer.TestSample;
using static STM.BLayer.StmTest.DataSample;

namespace STM.DLayer
{
    class TestLoader
    {
        public string TestPath { set; get; }
        public TestingSample TestSample { set; get; }
        public TestInformation TestInformation { set; get; }
        public TestExtremom TestExtermom{set;get;}


        public static void Load(string path, ref TestingSample testMaterialSample, ref TestInformation testInformation)
        {
            StreamReader reader;

            try { reader = new StreamReader(path); }
            catch (Exception ex) { throw ex; }
            while (true)
            {
                var str = reader.ReadLine().Trim().ToUpper();

                switch (str)
                {
                    case "SPECIMEN":
                        {
                            readSample(ref testMaterialSample, reader, ref str);
                            testInformation.Date = reader.ReadLine().Trim();
                        }
                        break;

                    case "MODE":
                        break;
                }
            }
        }

        private static void readSample(ref TestingSample testMaterialSample, StreamReader reader, ref string str)
        {
            str = reader.ReadLine().Trim().ToUpper();
            double[] values = new double[8];
            values = values.Select(p => double.Parse(reader.ReadLine().Trim())).ToArray();
            //switch (str)
            //{
            //    case "DIAMETER":
            //        testMaterialSample = new TestingSample(Math.PI * (values[0] * values[0] - values[1] * values[1]), values[7]) 
            //                            { TesnionCompressionSampleType = TensionCompressionSampleType.Rectangular };
            //        break;

            //    case "RECTANGULAR":
            //        testMaterialSample = new TestingSample(values[2] * values[3], values[7]) 
            //                            { TesnionCompressionSampleType = TensionCompressionSampleType.Rectangular };
            //        break;

            //    case "WEIGH":
            //        testMaterialSample = new TestingSample(values[3] / (values[5] * 1e-9 * values[7]), values[7]) 
            //                            { TesnionCompressionSampleType = TensionCompressionSampleType.Weight };
            //        break;

            //    case "AREA":
            //        testMaterialSample = new TestingSample(values[2], values[7]) { TesnionCompressionSampleType = TensionCompressionSampleType.Area };
            //        break;

            //    case "Oring":
            //        testMaterialSample = new TestingSample(Math.PI * (values[0] * values[0] - values[1] * values[1]), values[7]) 
            //                            { TesnionCompressionSampleType = TensionCompressionSampleType.Oring };
            //        break;

            //    case "Pipe":
            //        testMaterialSample = new TestingSample(Math.PI * (values[0] * values[0] - values[1] * values[1]), values[7]) 
            //                            { TesnionCompressionSampleType = TensionCompressionSampleType.Pipe };
            //        break;

            //    default:
            //        throw new Exception("Invalid file");
            //}
            testMaterialSample.Id = reader.ReadLine().Trim();
        }
     
    }


}
