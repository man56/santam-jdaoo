namespace STM.BLayer.Parameters
{
    class SpeedControlParameters
    {
        public static double I { set; get; }
        public static double D { set; get; }
        public static double P { set; get; }

        public static double Kei { set; get; }
        public static double Ked { set; get; }
        public static double Kep { set; get; }
        public static double Etorelance { set; get; }
        public static double EerrorSum { get; set; }
        public static double EerrorLast { get; set; }

        public static double Kfi { set; get; }
        public static double Kfd { set; get; }
        public static double Kfp { set; get; }
        public static double Ftorelance { set; get; }
        public static double FerrorSum { get; set; }
        public static double FerrorLast { get; set; }

        public static double Ksi { set; get; }
        public static double Ksd { set; get; }
        public static double Ksp { set; get; }
        public static double STorelance { set; get; }
        public static double SerrorSum { get; set; }
        public static double SerrorLast { get; set; }


        public static double Velocity { set; get; }
        public static double Command { set; get; }
        public static double Timeout { set; get;}

        public static double Max { set; get; }
        public static double Step { set; get; }
        public static double Offset { set; get; }
    }
}