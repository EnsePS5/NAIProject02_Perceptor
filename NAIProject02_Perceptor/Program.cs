using System;

namespace NAIProject02_Perceptor
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Introduction commands
            Console.WriteLine("Proszę wprowadzić stałą uczenia(int): ");
            int learningCons = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Proszę wprowadzić ścieżkę do pliku treningowego: ");
            string traningFilePath = Console.ReadLine();


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
    }
}
