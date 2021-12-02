using System;

namespace StructConsoleApp.Containers
{
    public class WeatherClass
    {
        /// <summary>
        /// Time recorded
        /// </summary>
        public DateTime RecordedAt { get; init; }
        /// <summary>
        /// Unit of temperature on the Celsius scale
        /// </summary>
        public decimal TemperatureInCelsius { get; init; }
        /// <summary>
        /// One thousandth of a bar, the cgs unit of atmospheric pressure equivalent to 100 pascals.
        /// </summary>
        public decimal PressureInMillibars { get; init; }

        public override string ToString() =>
            $"At {RecordedAt:h:mm tt} on {RecordedAt:M/d/yyyy}: " +
            $"Temp = {TemperatureInCelsius}, with {PressureInMillibars} pressure";
    }
}
