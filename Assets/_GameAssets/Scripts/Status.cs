using UnityEngine;
using System.Collections;

namespace SS
{
    public struct MinMax
    {
        public float Min;
        public float Max;

        public MinMax(float min, float max)
        {
            Min = min;
            Max = max;
        }
    }

    public abstract class Status
    {
        public string Name { get; protected set; }
        public float GenericValue { get; protected set; } = 0.0f;

        public virtual void UpdateStatus() { }
        public virtual void OnFinishStatus() { }
    }

    public class Status_Warmth : Status
    {
        public MinMax AverageBodyTemperature;
        public float CurrentBodyTemperature;

        public Status_Warmth(float currentBodyTemperature, MinMax averageBodyTemperature)
        {
            Name = "Warmth";
            AverageBodyTemperature = averageBodyTemperature;
            CurrentBodyTemperature = currentBodyTemperature;
            GenericValue = ConvertToGenericValue(CurrentBodyTemperature);
        }

        public override void UpdateStatus()
        {
            // ngecek sekitar
        }

        public float ConvertToGenericValue(float value)
        {
            return (-0.97935f * value * value) + (71.4926f * value) - 1216.5f;
        }
    }

    public class Status_Hunger : Status
    {
        public Status_Hunger()
        {
            Name = "Hunger";
            GenericValue = 100.0f;
        }

        public override void UpdateStatus()
        {
            var decValue = 100.0f / (float)(7 * 24 * 60 * 60);
            GenericValue = Mathf.Clamp(GenericValue - decValue, 0, 100);

            Debug.Log("Hunger : " + decValue);
        }
    }

    public class Status_Thirst : Status
    {
        public Status_Thirst()
        {
            Name = "Thirst";
            GenericValue = 100.0f;
        }

        public override void UpdateStatus()
        {
            var decValue = 100.0f / (float)(3 * 24 * 60 * 60);
            GenericValue = Mathf.Clamp(GenericValue - decValue, 0, 100);

            Debug.Log("Thirst : " + decValue);
        }
    }
}
