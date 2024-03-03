using System;

namespace STM.BLayer.Parameters
{
    class CrossHead
    {
        public static bool ActuatorUp { set; get; }
        public static double HiJogSpeed { set; get;}
        public static double LowJogSpeed { set; get; }
        public static double Increament { set; get; }
        public static double MaxSpeed { set; get; }
        public static double MinSpeed { set; get; } 
        private static double speed { set; get; }
        public static bool CtrlKey { set; get; }

        // 14000308, Nazarpour
        public static bool ElectroHydrolic { get; set; }

        
        public static CrossHeadDirection CrossHeadDirection { set; get; }

        public static int CrossHeadDirectionSpeedSgn { set; get; }

        public static void SetCrossHeadDirection(double curPoint, double SetPoint)
        {
            if (curPoint > SetPoint)
                CrossHeadDirection = CrossHeadDirection.Down;
            else if (curPoint < SetPoint)
                CrossHeadDirection = CrossHeadDirection.Up;
            //else if (SetPoint < 0 && curPoint < SetPoint) 91.10.10
            //    CrossHeadDirection = CrossHeadDirection.Up;
            //else if (SetPoint < 0 && curPoint > SetPoint)
            //    CrossHeadDirection = CrossHeadDirection.Down;

            switch (CrossHeadDirection)
            {
                case CrossHeadDirection.Up:
                    CrossHeadDirectionSpeedSgn = 1;
                    break;
                case CrossHeadDirection.Down:
                    CrossHeadDirectionSpeedSgn = -1;
                    break;
                default:
                    CrossHeadDirectionSpeedSgn = 0;
                    break;
            }
        }

        public static bool CrossHeadReaches(double curPoint, double SetPoint)
        {
            if (CrossHeadDirection == CrossHeadDirection.Up)
                return curPoint > SetPoint;
            if (CrossHeadDirection == CrossHeadDirection.Down)
                return curPoint < SetPoint;

            return false;
        }
       
       
        public static double GetJogSpeed(CrossHeadSpeedMode crossHeadSpeedMode)
        {
            if (CtrlKey)
            {
                speed = LowJogSpeed;
                speed = Math.Max(LowJogSpeed, speed);
                speed = Math.Min(HiJogSpeed, speed);
            }
            else if (Math.Abs(Increament) > 0)
            {
                speed += Increament;
                speed = Math.Max(LowJogSpeed, speed);
                speed = Math.Min(HiJogSpeed, speed);
            }
            else
                speed = HiJogSpeed;
            //if(ActuatorUp)
                return (crossHeadSpeedMode == CrossHeadSpeedMode.FastUp || crossHeadSpeedMode == CrossHeadSpeedMode.Up) ? speed : -speed;
            //return (crossHeadSpeedMode == CrossHeadSpeedMode.FastUp || crossHeadSpeedMode == CrossHeadSpeedMode.Up) ? -speed : speed;
        }

        internal static void RestSpeed()
        {
            speed = LowJogSpeed;
        }
    }

    enum CrossHeadDirection
    {
        None = 0,
        Up = 1,
        Down = 2
    }

    public enum CrossHeadSpeedMode
    {
        None = 0,
        Up = 1,
        FastUp = 2,
        Down = 3,
        FastDown = 4
    }
}
