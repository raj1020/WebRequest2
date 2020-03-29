using System;
using System.Collections.Generic;
using System.IO;

namespace WebRequest2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello and Welcome.");
            Console.WriteLine("Here you can get information about the historical exchange rates between different currencies (the data is supplied by the European Central Bank) and contribute by expressing your opinion about the future exchange rate movements. .");
            Console.WriteLine("Please choose one of the option numbers below: ");

            Dictionary<int, string> optionList = new Dictionary<int, string>()
            {
                { 1, "Get the latest foreign exchange rates." },
                { 2, "Get the historical foreign exchange rates." },
                { 3, "Get the latest exchange rates between any two currencies." },
                { 4, "Get the historical exchange rates between any two currencies." }
        };

            foreach (KeyValuePair<int, string> kvp in optionList)
            {
               
                Console.WriteLine("{0}: {1}", kvp.Key, kvp.Value);
            }





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

            Console.WriteLine("Please select the option about the information you want to view.");


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

        public static void InformationOption()
        {
            string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\";
            string filename = "InfoOpt.txt";
            string fullFilePath = docPath + filename;



            string[] fileContentsByLine = File.ReadAllLines(fullFilePath);
            foreach (string line in fileContentsByLine)
            {
                Console.WriteLine(line);
            }
        }
    }
}
