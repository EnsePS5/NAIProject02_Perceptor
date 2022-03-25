using System;
using System.Collections.Generic;

namespace NAIProject02_Perceptor
{
    internal sealed class Perceptor
    {
        static int consLearn;

        List<double> perceptorValues = new List<double>();
        private Perceptor(int learningCons)
        {
            consLearn = learningCons;
        }

        private static Perceptor _instance;

        public static Perceptor GetInstance(int learningCons)
        {
            if (_instance == null)
            _instance = new Perceptor(learningCons);

            return _instance;
        }

        public void Learn(List<string> records)
        {
            //TODO
        }

        public string Assign(List<string> records)
        {
            return "";//TODO
        }

        public void setVecSize(List<string> records)
        {
            string[] values = records[0].Split(',');
            
            for (int i = 0; i < values.Length-1; i++)
            {
                Random random = new Random();
                perceptorValues.Add(random.NextDouble());
                Console.WriteLine(perceptorValues[i]);
            }

        }
        private List<double> valuesExtraction(string recordValue)
        {
            string[] recordValues = recordValue.Split(',');
            List<double> doubleValues = new List<double>();

            for (int i = 0; i < recordValues.Length-1; i++)
            {
                doubleValues.Add(Convert.ToDouble(recordValues[i]));
            }

            return doubleValues;
        }
    }
}