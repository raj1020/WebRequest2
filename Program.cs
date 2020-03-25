using System;
using System.IO;

namespace WebRequest2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello and Welcome.");
            Console.WriteLine("Here you can get information about the historical exchange rates between different currencies.");
            Console.WriteLine("The data is supplied by the European Central Bank.");
            LatestExchangeRates();

            



        }

        public static void LatestExchangeRates()
        {
            Console.WriteLine("Do you know the currency code for your base currency? Type 'Y' for yes and 'N' for no.");
            string response = Console.ReadLine();

            if (response.ToLower()=="n")
            {
                CurrencyCodes();
            }

            Console.WriteLine("Please enter the currency code of your base currency.");
            string baseCurrency = Console.ReadLine();

        }

        public static void CurrencyCodes()
        {
            string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\";
            string filename = "CurrencyCode.txt";
            string fullFilePath = docPath + filename;

            

            string[] fileContentsByLine = File.ReadAllLines(fullFilePath);
            foreach (string line in fileContentsByLine)
            {
                Console.WriteLine(line);
            }
        }
    }
}
