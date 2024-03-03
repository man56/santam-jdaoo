
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Windows.Forms.VisualStyles;
using STM.BLayer.StmTest;
using STM.PLayer.UI;

namespace STM.BLayer
{
    public enum TestMethodType
    {
        Tensile = 1,
        Compressive,
        Cyclic,
        Step,
        Creep,
        Relaxation,
    }

    public enum ZeroCode
    {
        None = 0,
        Strain = 1,
        Exten = 2,
        Force = 3,
        SE = 4,
        SEF = 5
    }

    public enum StmExtraControls
    {
        SmtExtraNone = 0,
        SmtExtraPosition = 1,
        SmtExtraForce = 2
    }

    public enum SetPointAction
    {
        None = 0,
        Stop = 1,
        Keep = 2
    }

    public enum TestControlMode
    {
        None = 0,
        Force = MeasureType.Force,
        Extension = MeasureType.Extension,
        Stress = MeasureType.Stress,
        TrueStress = MeasureType.TrueStress,
        Strain = MeasureType.Strain,
        TrueStrain = MeasureType.TrueStrain,
        MassStress = MeasureType.MassStress,
        LengthStress = MeasureType.LengthStress,
        Temperature = MeasureType.Temperature,
    }

    public enum TemperatuerControlMode
    {
        None = 0,
        Set,
        WaitHigher,
        WaitLower,
        Keep
    }

    public enum StrainToExtenMode
    {
        Strain = MeasureType.Strain,
        Extention = MeasureType.Extension,
        Peak = 3
    }

    public enum StrainRemoveOptions
    {
        Stop = 1,
        Continue = 2
    }

    public enum CreepSetPoint
    {
        Force = TestControlMode.Force,
        Stress = TestControlMode.Stress,
        MassStress = MeasureType.MassStress,
        LengthStress = MeasureType.LengthStress
    }

    public enum RelaxationSetPoint
    {
        Extension = TestControlMode.Extension,
        Strain = TestControlMode.Strain,
        Force = TestControlMode.Force,
        Stress = TestControlMode.Stress,
        MassStress = MeasureType.MassStress,
        LengthStress = MeasureType.LengthStress
    }

    public static class EnumExtensions
    {
        /// <summary>
        /// Gets all items for an enum value.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static IEnumerable<T> GetAllItems<T>(this Enum value)
        {
            foreach (object item in Enum.GetValues(value.GetType()))
            {
                yield return (T)item;
            }
        }

        /// <summary>
        /// Gets all items for an enum type.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static IEnumerable<T> GetAllItems<T>() where T : struct
        {
            foreach (object item in Enum.GetValues(typeof(T)))
            {
                yield return (T)item;
            }
        }

        /// <summary>
        /// Gets all combined items from an enum value.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        /// <example>
        /// Displays ValueA and ValueB.
        /// <code>
        /// EnumExample dummy = EnumExample.Combi;
        /// foreach (var item in dummy.GetAllSelectedItems<EnumExample>())
        /// {
        ///    Console.WriteLine(item);
        /// }
        /// </code>
        /// </example>
        public static IEnumerable<T> GetAllSelectedItems<T>(this Enum value)
        {
            int valueAsInt = Convert.ToInt32(value, CultureInfo.InvariantCulture);

            foreach (object item in Enum.GetValues(typeof(T)))
            {
                int itemAsInt = Convert.ToInt32(item, CultureInfo.InvariantCulture);

                if (itemAsInt == (valueAsInt & itemAsInt))
                {
                    yield return (T)item;
                }
            }
        }

        /// <summary>
        /// Determines whether the enum value contains a specific value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="request">The request.</param>
        /// <returns>
        ///     <c>true</c> if value contains the specified value; otherwise, <c>false</c>.
        /// </returns>
        /// <example>
        /// <code>
        /// EnumExample dummy = EnumExample.Combi;
        /// if (dummy.Contains<EnumExample>(EnumExample.ValueA))
        /// {
        ///     Console.WriteLine("dummy contains EnumExample.ValueA");
        /// }
        /// </code>
        /// </example>
        public static bool Contains<T>(this Enum value, T request)
        {
            int valueAsInt = Convert.ToInt32(value, CultureInfo.InvariantCulture);
            int requestAsInt = Convert.ToInt32(request, CultureInfo.InvariantCulture);

            if (requestAsInt == (valueAsInt & requestAsInt))
            {
                return true;
            }

            return false;
        }

        public static IList<KeyValuePair<T, string>> ToList<T>(this Enum value)
        {
            var dic = new Dictionary<T, string>();
            foreach (T item in GetAllItems<T>(value))
            {
                dic.Add(item, Enum.GetName(typeof(T), item));
            }

            return dic.ToList();
        }
    }
}
