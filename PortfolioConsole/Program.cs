using System;
using DAL;

namespace PortfolioConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Context context = new Context();
            context.execquery("select * from Gebruiker;");
            Console.ReadLine();

        }
    }
}
