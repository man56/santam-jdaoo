using System.Drawing;

namespace STM.BLayer.StmTest
{
    public struct Options
    {
        public static string OutputPath { set; get; }
        public static int MaxRecentFiles { set; get; }
        public static bool NotifyLoadcellType { set; get; }
        public static bool ShowLanguageForm { set; get; }
        public static bool ShowGridLines { set; get; }
        public static string DefTestPath { set; get; }
        public static string ActiveLanguage { set; get; }

        public static bool PrintLogo { set; get; }
        public static bool PrintPlot { set; get; }
        public static bool PrintTestsSpec { set; get; }
        public static bool PrintTestResults { set; get;}

        public static bool ResetMeasuresAtStart { get; set; }
        public static int HugeSampleCount { get;  set; }
    }

    public struct Colors
    {
        public static bool SucceedLoadOrSave { set; get; }
        public static Color PageSpace { set; get; }
        public static Color Background { set; get; }
        public static Color Diagram { set; get; }
		public static Color Diagram2 { set; get; }
		public static Color Lable { set; get; }
        public static Color Scale { set; get; }
        public static Color Title { set; get; }
        public static Color Grid { set; get; }
    }
}
