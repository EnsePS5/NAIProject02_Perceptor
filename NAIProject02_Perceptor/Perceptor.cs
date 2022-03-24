namespace NAIProject02_Perceptor
{
    internal sealed class Perceptor
    {
        private Perceptor()
        {

        }

        private static Perceptor _instance;

        public static Perceptor GetInstance()
        {
            if (_instance == null)
            _instance = new Perceptor();

            return _instance;
        }

        public void Learn()
        {

        }

        public string Assign()
        {
            return "";
        }
    }
}