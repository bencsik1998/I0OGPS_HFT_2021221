namespace GPA48P_HFT_2021221.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Threading.Thread.Sleep(5000);

            RestService rest = new RestService("http://localhost:62480");

            ConsoleMenu.MainMenu();
        }
    }
}
