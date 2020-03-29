using System;
using System.Collections.Generic;
using System.IO;
using System.Net;

namespace WebRequest2
{
    class Program
    {
        private static string baseCode;
        private static string secondCode;
        private static DateTime startDate;
        private static DateTime endDate;

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

            //int optionResponse = OptionResponse1();
            int i = 0;
            while (i<=3)
            {

            

                switch (OptionResponse1())
                {
                    case 1:
                        Option1();
                        i = 4;
                        //i has been assigned a value to 4 so that the program exits the while loop.
                        break;
                    case 2:
                        Option2();
                        
                        i = 4;
                        break;
                    case 3:
                        Option3();
                        
                        i = 4;
                        break;
                    case 4:
                        Option4();
                       
                        i = 4;
                        break;

                    default:
                        Console.WriteLine("Invalid Choice.");
                        i++;
                        break;
                }

                if ( i == 4)
                {
                    Console.WriteLine("Please try again later.");
                    System.Environment.Exit(0);
                }
            }

        }



        public static string EnterCode()
        {
            Console.WriteLine("Please enter the code of your base currency.");
            string baseCurrency;
            return baseCurrency = Console.ReadLine();
        }

        public static string SecondCode()
        {
            Console.WriteLine("Please enter the code of your another currency.");
            string secondCurrency;
            return secondCurrency = Console.ReadLine();
        }

        public static  string StartDate()
        {
            DateTime dob;

            // print out instruction to user
            Console.WriteLine("Please enter student date of birth by yyyy-mm-dd:");

            // get user input
            var userInputDOB = Console.ReadLine();

            // try to parse in userinput into variable created above
            DateTime.TryParse(userInputDOB, out dob);

            // print out userinput and convert it to string as well as removing the Time portion
            return dob.ToString("yyyy’-‘MM’-‘dd");

                //(dob.ToString("yyyy/MM/dd"));

        }
        public static string  EndDate()
        {

            // print out instruction to user
            Console.WriteLine("Please enter end date of birth by yyyy-mm-dd:");

            // get user input
            var endDateDOB = Console.ReadLine();

            // try to parse in userinput into variable created above
            DateTime.TryParse(endDateDOB, out endDate);

            // print out userinput and convert it to string as well as removing the Time portion
            string interimDate= endDate.ToString("yyyy’-‘MM’-‘dd"); 
            return endDate = DateTime.TryParse(interimDate, out endDate);

        }

        public static void Option1()
        {
            CodeQuestion();
            baseCode = EnterCode();

            WebRequest request = WebRequest.Create(
            "https://api.exchangeratesapi.io/latest?base=" + 
            baseCode);
            // Get the response.  
            WebResponse response = request.GetResponse();
            // Display the status.  
            Console.WriteLine(((HttpWebResponse)response).StatusDescription);

            // Get the stream containing content returned by the server. 
            // The using block ensures the stream is automatically closed. 
            using (Stream dataStream = response.GetResponseStream())
            {
                // Open the stream using a StreamReader for easy access.  
                StreamReader reader = new StreamReader(dataStream);
                // Read the content.  
                string responseFromServer = reader.ReadToEnd();
                // Display the content.  
                Console.WriteLine(responseFromServer);
            }

            // Close the response.  
            response.Close();
        }
        public static void Option2()
        {
            CodeQuestion();
            baseCode = EnterCode();
            secondCode = SecondCode();
            startDate = StartDate();
            endDate = EndDate();

            WebRequest request = WebRequest.Create(
            "https://api.exchangeratesapi.io/history?start_at=" + startDate+"&end_at="+endDate+"&symbols="+baseCode+","+secondCode);
            // Get the response.  
            WebResponse response = request.GetResponse();
            // Display the status.  
            Console.WriteLine(((HttpWebResponse)response).StatusDescription);

            // Get the stream containing content returned by the server. 
            // The using block ensures the stream is automatically closed. 
            using (Stream dataStream = response.GetResponseStream())
            {
                // Open the stream using a StreamReader for easy access.  
                StreamReader reader = new StreamReader(dataStream);
                // Read the content.  
                string responseFromServer = reader.ReadToEnd();
                // Display the content.  
                Console.WriteLine(responseFromServer);
            }

            // Close the response.  
            response.Close();
        }
        public static void Option3()
        {
            Console.WriteLine("Here is your Option 3");
        }
        public static void Option4()
        {
            Console.WriteLine("Here is your Option 4");
        }


        public static int OptionResponse1()
        {
            Console.WriteLine("Please type your option.");
            int optionResponse2;
            return  optionResponse2 = Convert.ToInt32(Console.ReadLine());
        }

        public static void  CodeQuestion()
        {
            Console.WriteLine("Do you know the currency code for your base currency? Type 'Y' for yes and 'N' for no.");
            string response = Console.ReadLine();

            if (response.ToLower() == "n")
            {
                CurrencyCodes();
            }

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

           /* public static void InformationOption()
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
        */
    }
}









