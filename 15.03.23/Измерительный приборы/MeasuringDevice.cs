using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Измерительный_приборы
{
    internal class MeasuringDevice
    {
        string type;
        string unit;
        string producer;
        string accuracy;
        string maxOfMeasure;
        string minOfMeasure;

        public MeasuringDevice(string type, string producer, string accuracy, string maxOfMeasure, string minOfMeasure, string unit)
        {
            this.type = type;
            this.unit = unit;
            this.producer = producer;
            this.accuracy = accuracy;
            this.maxOfMeasure = maxOfMeasure;
            this.minOfMeasure = minOfMeasure;
            this.unit = unit;
        }

        public string Type { get { return type; } }
        public string Unit { get { return unit; } }
        public string Producer { get { return producer; } }
        public string Accuracy { get { return accuracy; } }
        public string MaxOfMeasure { get { return maxOfMeasure; } }
        public string MinOfMeasure { get { return minOfMeasure; } }
    }
}
