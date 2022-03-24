using System;
using System.IO;

namespace NAIProject02_Perceptor
{
    public class Program
    {
        static string trainingFilePath;
        public static void Main(string[] args)
        { 

            //Introduction commands
            Console.WriteLine("Proszę wprowadzić stałą uczenia(int+): ");
            int learningCons = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Proszę wprowadzić ścieżkę do pliku treningowego: ");
            trainingFilePath = Console.ReadLine();

            if (!File.Exists(trainingFilePath)) 
                throw new Exception("Plik nieistnieje.");



            //Learning process in loop
            string anwser = string.Empty;
            Perceptor perceptor = Perceptor.GetInstance();

            do
            {

                Console.WriteLine("Rozpoczęto proces nauczania.");

                

                Console.WriteLine("Zakończono proces nauczania. Czy chcesz powtórzyć nauczanie? Y/N: ");
                anwser = Console.ReadLine();

            } while (anwser == "Y");
        }

        //file data extraction method
        private void dataReader(string fileName)
        {
            string[] lines = File.ReadAllLines(fileName);

            foreach (string line in lines)
            {
                //TODO do smth
            }
        }
    }
}
