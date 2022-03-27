using System;
using System.Collections.Generic;
using System.Globalization;

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

            perceptronTarget = targetRandom.NextDouble()*10;

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

                int resulOfAssign = Assign(values, correctType);

                //Chcecks if assigning is correct
                if (correctType == perceptorTypes[resulOfAssign])
                {
                    Console.Write("Vector ");

                    for (int i = 0; i < values.Count; i++)
                    {
                        Console.Write(values[i] + " / ");
                    }

                    Console.WriteLine("has been assigned correctly to " + correctType);
                }
                else
                {

                    Console.Write("Vector ");

                    for (int i = 0; i < values.Count; i++)
                    {
                        Console.Write(values[i] + " / ");
                    }

                    Console.WriteLine("has been assigned incorrectly. ");

                    //learning process
                    List<double> calculatingVec = new List<double>();
                    int correctIndex;

                    if (resulOfAssign == 1)
                        correctIndex = 0;
                    else
                        correctIndex = 1;

                    double learningConstantPart = (correctIndex - resulOfAssign) * consLearn;

                    for (int i = 0; i < values.Count; i++)
                    {
                        calculatingVec.Add(learningConstantPart*values[i]);
                        perceptorValues[i] = perceptorValues[i] + calculatingVec[i];
                    }
                    perceptronTarget = perceptronTarget + -1;

                    //output of learning
                    if (correctType == perceptorTypes[Assign(values, correctType)])
                        Console.WriteLine("Perceptron has addapted. ");
                    else
                        Console.WriteLine("Perceptron has not addapted enough. ");

                }

                records.RemoveAt(nextIndex);

                /*foreach (double vale in perceptorValues)
                {
                    Console.Write(vale + " ");
                }
                Console.WriteLine("Ptarget -> " + perceptronTarget);*/
            }
            
        }

        //Assigning method
        public void Assign(List<string> records)
        {
            double counterOfGoodAssignments = 0;

            if (records.Count > 1)
            {
                foreach (string record in records)
                {
                    List<double> valuesFromRecord = valuesExtraction(record);
                    string correctType = correctTypeExtraction(record);

                    int result = Assign(valuesFromRecord, correctType);

                    if (correctType == perceptorTypes[result])
                    {
                        Console.Write("Vector ");

                        for (int i = 0; i < valuesFromRecord.Count; i++)
                        {
                            Console.Write(valuesFromRecord[i] + " / ");
                        }

                        Console.WriteLine("has been assigned correctly to " + correctType);
                        counterOfGoodAssignments++;
                    }
                    else
                    {
                        Console.Write("Vector ");

                        for (int i = 0; i < valuesFromRecord.Count; i++)
                        {
                            Console.Write(valuesFromRecord[i] + " / ");
                        }

                        Console.WriteLine("has been assigned incorrectly. ");
                    }
                }
            }
            else
            {
                List<double> valuesFromRecord = valuesExtraction(records[0]);

                int result = Assign(valuesFromRecord, null);

                if (result == 1)
                    Console.WriteLine("Przypisano do " + perceptorTypes[result]);
                else
                    Console.WriteLine("Przypisano do " + perceptorTypes[result]);

                return;

            }

            Console.WriteLine("Accuracy has reached " + (double)(counterOfGoodAssignments/(double)records.Count)*100 + "%");
        }
        private int Assign(List<double> valuesFromRecord, string correctType)
        {
            double sum = 0;

                for (int i = 0; i < valuesFromRecord.Count; i++)
                {
                    sum += perceptorValues[i] * valuesFromRecord[i];
                }
            if (correctType != null) { 
                if (sum >= perceptronTarget)//TODO CHANGE CONDITIONS IF NEEDED
                {
                    /*if (correctType == perceptorTypes[0])
                        return 0;
                    else if (correctType == perceptorTypes[1])*/
                        return 1;
                }
                else
                {
                    /*if (correctType == perceptorTypes[0])
                        return 1;
                    else if (correctType == perceptorTypes[1])*/
                        return 0;
                }

                //return -1;
            }
            else
            {
                if (sum >= perceptronTarget)//ANALYZE
                    return 1;

                return 0;
            }
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
                NumberFormatInfo provider = new NumberFormatInfo();
                provider.NumberDecimalSeparator = ".";
                provider.NumberGroupSeparator = ",";

                doubleValues.Add(Convert.ToDouble(recordValues[i], provider));
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