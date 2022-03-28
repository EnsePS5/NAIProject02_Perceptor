using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace NAIProject02_Perceptor
{
    public class Program
    {
        static string filePath;
        // C:...\Programowanie_C#_Visual_Studio\APBD\NAIProject02_Perceptor\Data\tranigVal.csv
        // - Default Path for trainingFile

        // C:...\Programowanie_C#_Visual_Studio\APBD\NAIProject02_Perceptor\Data\testVal.csv
        // - Default Path for testFile
        public static void Main(string[] args)
        {
            //Record list variable
            List<string> records = new List<string>();

            //Introduction commands
            Console.WriteLine("Proszę wprowadzić stałą uczenia(int+): ");

            double learningCons = 0;
            {
                NumberFormatInfo provider = new NumberFormatInfo();
                provider.NumberDecimalSeparator = ".";
                provider.NumberGroupSeparator = ",";

                learningCons = Convert.ToDouble(Console.ReadLine(), provider);
            }

            Console.WriteLine("Proszę wprowadzić ścieżkę do pliku treningowego: ");
            filePath = Console.ReadLine();

            if (!File.Exists(filePath)) 
                throw new Exception("Plik nieistnieje. ");

            //Reading csv file and adding them into List 
            records = dataReader(filePath);

            //Learning process in loop, setting perceptor
            string anwser = string.Empty;
            Perceptor perceptor = Perceptor.GetInstance(learningCons);
            perceptor.setVecSize(records);

            do
            {
                Console.WriteLine("Rozpoczęto proces nauczania.");

                perceptor.Learn(records);

                Console.WriteLine("Zakończono proces nauczania. Czy chcesz powtórzyć nauczanie? Y/N: ");
                anwser = Console.ReadLine();

            } while (anwser == "Y");

            //Perceptron testing

            Console.WriteLine("Proszę wprowadzić ścieżkę do pliku testowego: ");
            filePath = Console.ReadLine();

            if (!File.Exists(filePath))
                throw new Exception("Plik nieistnieje. ");

            //Reading csv file and adding them into List
            records = dataReader(filePath);

            //Testing process in loop
            do
            {
                Console.WriteLine("Rozpoczęto proces przypisywania.");

                perceptor.Assign(records);

                Console.WriteLine("Zakończono przypisywanie. Czy chesz wprowadzić dodatkowy rekord? Y/N: ");
                anwser = Console.ReadLine();

                if (anwser != "Y") return;

                Console.WriteLine("Proszę wprowadzić wektor: ");

                records.Clear();
                records.Add(Console.ReadLine());

            } while (anwser == "Y");

        }

        //file data extraction method
        private static List<string> dataReader(string fileName)
        {
            string[] lines = File.ReadAllLines(fileName);
            List<string> records = new List<string>();

            foreach (string line in lines)
            {
                records.Add(line);
            }

            return records;
        }
    }
}
