using STM.PLayer.UI;

namespace STM.PLayer
{
    interface IUnit
    {
        void NotifyUnitChanges(MeasureType measureType, string unit);
        void UpdateUnit(MeasureType measureType, string unit);
    }
}
