using System.Collections.Generic;
using STM.BLayer;
using STM.Properties;

namespace STM.BLayer.Time
{
    public struct TimeUnits
    {
        public static readonly UnitSet UnitSet = new UnitSet(new Dictionary<string, Unit>
                        {
                            {Resources.TimeUnits_UnitSet_sec, new Unit {Abbreviation = Resources.TimeUnits_UnitSet_sec, M = 1.0, Name = Resources.TimeUnits_UnitSet_Second}},
                            {Resources.TimeUnits_UnitSet_min, new Unit {Abbreviation = Resources.TimeUnits_UnitSet_min, M = 1.0/60, Name = Resources.TimeUnits_UnitSet_Minute}},
                            {Resources.TimeUnits_UnitSet_h, new Unit {Abbreviation = Resources.TimeUnits_UnitSet_h, M = 1.0/3600, Name = Resources.TimeUnits_UnitSet_Hour}},
                        });
    }
}