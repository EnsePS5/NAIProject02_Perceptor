using System;
using System.Collections.Generic;

namespace NAIProject02_Perceptor
{
    internal sealed class Perceptor
    {
        //Perceptron variables
        static int consLearn;
        double perceptronTarget;
        List<double> perceptorValues = new List<double>();
        List<string> perceptorTypes = new List<string>();

        //Constructor
        private Perceptor(int learningCons)
        {
            consLearn = learningCons;
            Random targetRandom = new Random();

            perceptronTarget = targetRandom.NextDouble()*5;

        }
        //Singletone
        private static Perceptor _instance;

        //Singletone inicialization
        public static Perceptor GetInstance(int learningCons)
        {
            if (_instance == null)
            _instance = new Perceptor(learningCons);

            return _instance;
        }

        //Learning method
        public void Learn(List<string> records)
        {

            while (records.Count != 0)
            {
                Random randomIndex = new Random();
                int nextIndex = randomIndex.Next(records.Count);

                List<double> values = valuesExtraction(records[nextIndex]);
                string correctType = correctTypeExtraction(records[nextIndex]);

                if (!perceptorTypes.Contains(correctType))
                    perceptorTypes.Add(correctType);


                //Chcecks if assigning is correct
                if (this.Assign(values, correctType) == 0)
                {
                    //TODO Learn delta formula
                }

                records.RemoveAt(nextIndex);
            }
            
        }

        //Assigning method
        public string Assign(List<string> records)
        {
            return "";//TODO
        }
        private int Assign(List<double> valuesFromRecord, string correctType)
        {
            double sum = 0;
            for (int i = 0; i < valuesFromRecord.Count; i++)
            {
                sum += perceptorValues[i] * valuesFromRecord[i];
            }

            if (sum >= perceptronTarget)
                return 0;

            return 1;
        }

        //Sets perceptron's deminsion size
        public void setVecSize(List<string> records)
        {
            string[] values = records[0].Split(',');
            
            for (int i = 0; i < values.Length-1; i++)
            {
                Random random = new Random();
                perceptorValues.Add(random.NextDouble());
                //Console.WriteLine(perceptorValues[i]);
            }

        }

        //Extracts values from string
        private static List<double> valuesExtraction(string recordValue)
        {
            string[] recordValues = recordValue.Split(',');
            List<double> doubleValues = new List<double>();

            for (int i = 0; i < recordValues.Length-1; i++)
            {
                doubleValues.Add(Convert.ToDouble(recordValues[i]));
            }

            return doubleValues;
        }

        //Extracts type from string
        private static string correctTypeExtraction(string recordValue)
        {
            string[] typeRecord = recordValue.Split(',');
            return typeRecord[typeRecord.Length];
        }
    }
}