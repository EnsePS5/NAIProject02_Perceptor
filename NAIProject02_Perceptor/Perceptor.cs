using System.Collections.Generic;

namespace NAIProject02_Perceptor
{
    internal sealed class Perceptor
    {
        private Perceptor()
        {

        }

        private static Perceptor _instance;

        public static Perceptor GetInstance(int learningCons)
        {
            if (_instance == null)
            _instance = new Perceptor();

            return _instance;
        }

        public void Learn(List<string> records)
        {

        }

        public string Assign(List<string> records)
        {
            return "";
        }
    }
}