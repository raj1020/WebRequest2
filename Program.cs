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
        //private static DateTime startDate;
        //private static DateTime endDate;

        static void Main(string[] args)
        {
            Console.WriteLine("Hello and Welcome.");
            Console.WriteLine("Here you can get information about the historical exchange rates between different currencies (the data is supplied by the European Central Bank) and contribute by expressing your opinion about the future exchange rate movements. .");
            Console.WriteLine("Please choose one of the option numbers below: ");

            Dictionary<int, string> optionList = new Dictionary<int, string>()
            {
                { 1, "Get the latest foreign exchange rates against a base currency." },
                { 2, "Get the historical foreign exchange rates of two currencies against Euro." },
                { 3, "Get the latest exchange rates of two currencies against Euro." },
                { 4, "Get the historical exchange rates between Euro and a currency of your choice." }
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
                        i = 5;
                        //i has been assigned a value to 4 so that the program exits the while loop.
                        break;
                    case 2:
                        Option2();
                        
                        i = 5;
                        break;
                    case 3:
                        Option3();
                        
                        i = 5;
                        break;
                    case 4:
                        Option4();
                       
                        i = 5;
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
            Console.WriteLine("Do you want to read the opinions of past contributors or contribute with your opinion. Please type 'y' for yes and 'n' for no.");
            string opinion = Console.ReadLine();
            if (opinion.ToLower()== "y")
            {
                Opinion();
            }
        }



        public static string EnterCode()
        {
            Console.WriteLine("Please enter the code of your currency.");
            string baseCurrency;
            return baseCurrency = Console.ReadLine();
        }

        public static string SecondCode()
        {
            Console.WriteLine("Please enter the code of your another currency.");
            string secondCurrency;
            return secondCurrency = Console.ReadLine();
        }

       
            

        public static void Option1()
        {
            CodeList();
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
            CodeList();
            baseCode = EnterCode();
            secondCode = SecondCode();
           

            WebRequest request = WebRequest.Create(
            "https://api.exchangeratesapi.io/history?start_at=2020-03-20&end_at=2020-03-30&symbols="+baseCode+","+secondCode);
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


            CodeList();
            baseCode = EnterCode();
            secondCode = SecondCode();
            

            WebRequest request = WebRequest.Create(
            " https://api.exchangeratesapi.io/latest?symbols=" + baseCode + "," + secondCode);
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
        public static void Option4()
        {
        

            CodeList();
            baseCode = EnterCode();
           


            WebRequest request = WebRequest.Create(
            "  https://api.exchangeratesapi.io/history?start_at=2020-03-20&end_at=2020-03-30&base=" + baseCode);
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


        public static int OptionResponse1()
        {
            Console.WriteLine("Please type your option.");
            int optionResponse2;
            return  optionResponse2 = Convert.ToInt32(Console.ReadLine());
        }

        public static void  CodeList()
        {
            Console.WriteLine("Please choose the currency code as shown below.");
            
                CurrencyCodes();
            

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

            public static void Opinion()
        {
           

            string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\";
            string filename = "Opinion.txt";
            string fullFilePath = docPath + filename;

           


            string[] fileContentsByLine = File.ReadAllLines(fullFilePath);
            foreach (string line in fileContentsByLine)
            {
                Console.WriteLine(line);
            }

            Console.WriteLine("Based on the information you have do you want to provide an opinion how the currencies will be performing against eachother in the near future. Please type 'y' for yes and 'n' for no.");
            string opinionInput = Console.ReadLine();
            if (opinionInput.ToLower() == "y")
            {
                Console.WriteLine("Please Type your name.");
                string name = Console.ReadLine();
                Console.WriteLine("Please type the topic of your opinion.");
                string topic = Console.ReadLine();
                Console.WriteLine("Please type your opinion in a concise manner.");
                string yourOpinion = Console.ReadLine();
                string datetime = DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss");
                string text = name + " wrote about " +topic + " on " + datetime;

                File.AppendAllLines(fullFilePath, new string[] { text });
                File.AppendAllLines(fullFilePath, new string[] { yourOpinion });
            }


        }
        
    }
}









