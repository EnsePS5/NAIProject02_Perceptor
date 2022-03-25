using System;
using System.Collections.Generic;

namespace NAIProject02_Perceptor
{
    internal sealed class Perceptor
    {
        //Perceptron variables
        static double consLearn;
        double perceptronTarget;
        List<double> perceptorValues = new List<double>();
        List<string> perceptorTypes = new List<string>();

        //Constructor
        private Perceptor(double learningCons)
        {
            consLearn = learningCons;
            Random targetRandom = new Random();

            perceptronTarget = targetRandom.NextDouble()*2;

        }
        //Singletone
        private static Perceptor _instance;

        //Singletone inicialization
        public static Perceptor GetInstance(double learningCons)
        {
            if (_instance == null)
            _instance = new Perceptor(learningCons);

            return _instance;
        }

        //Learning method
        public void Learn(List<string> data)
        {
            List<string> records = new List<string>();
            records.AddRange(data);

            string correctType = string.Empty;

            //Assigning all(2) available types
            for (int i = 0; i < records.Count; i++)
            {
                correctType = correctTypeExtraction(records[i]);

                if (!perceptorTypes.Contains(correctType))
                    perceptorTypes.Add(correctType);
            }

            while (records.Count != 0)
            {
                Random randomIndex = new Random();
                int nextIndex = randomIndex.Next(records.Count);

                List<double> values = valuesExtraction(records[nextIndex]);
                correctType = correctTypeExtraction(records[nextIndex]);

                //Chcecks if assigning is correct
                if (correctType == perceptorTypes[Assign(values,correctType)])
                {
                    Console.Write("Vector ");

                    foreach (double value in values)
                    {
                        Console.Write(value + " ");
                    }

                    Console.WriteLine("has been assigned correctly to " + correctType);
                }
                else
                {
                    Console.Write("Vector ");

                    foreach (double value in values)
                    {
                        Console.Write(value + " ");
                    }

                    Console.WriteLine("has been assigned incorrectly. Perceptor values has been modified! ");

                    //TODO learning
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
            {
                if (correctType == perceptorTypes[0])
                    return 0;
                else if (correctType == perceptorTypes[1])
                    return 1;
            }
            else 
            {
                if (correctType == perceptorTypes[0])
                    return 1;
                else if (correctType == perceptorTypes[1])
                    return 0;
            }

            return -1;

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
                double temp;

                if (Double.TryParse(recordValues[i], out temp))
                    doubleValues.Add(temp);
            }

            return doubleValues;
        }

        //Extracts type from string
        private static string correctTypeExtraction(string recordValue)
        {
            string[] typeRecord = recordValue.Split(',');
            return typeRecord[typeRecord.Length-1];
        }
    }
}