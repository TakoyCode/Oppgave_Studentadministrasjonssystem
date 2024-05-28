namespace Oppgave_Studentadministrasjonssystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SchoolSystem.LoadSystem();

            while (true)
            {
                SchoolSystem.Menu();
            }
        }
    }
}
