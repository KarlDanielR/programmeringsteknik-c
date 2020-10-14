using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeSheet.Common;
using TimeSheet.Common.Models;


// Please note - THIS IS A BAD APPLICATION - DO NOT REPLICATE WHAT IT DOES
// This application was designed to simulate a poorly-built application that
// you need to support. Do not follow any of these practices. This is for 
// demonstration purposes only. You have been warned.
namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            string workDone;
            int hourDone;
            int timeTotal;

            List<TimeSheetEntryModel> timeSheetEntries = new List<TimeSheetEntryModel>();
            List<CustomerModel> customer = new List<CustomerModel>
            {
                new CustomerModel { Name = "Acme", HourlyRate = 150 },
                new CustomerModel { Name = "ABC", HourlyRate = 125 }
            };


            bool continueEntering;
            do
            {
                Console.Write("Enter what you did: ");
                workDone = Console.ReadLine();

                Console.Write("How long did you do it for(in hours): ");
                hourDone = int.Parse(Console.ReadLine());

                TimeSheetEntryModel entry = new TimeSheetEntryModel
                {
                     HoursWorked = hourDone,
                     WorkDone = workDone
                };
                timeSheetEntries.Add(entry);

                Console.Write("Do you want to enter more time:");
                continueEntering = Console.ReadLine().ToLower() == "yes";
                //continueEntering = Console.ReadLine().Equals("yes", StringComparison.OrdinalIgnoreCase);
            }
            while (continueEntering == true);

            


            timeTotal = TimeSheetProcessor.CalculateTimeForCustomer(timeSheetEntries, "Acme");
            Console.WriteLine("Simulating Sending email to Acme");
            Console.WriteLine("Your bill is $" + timeTotal * 150 + " for the hours worked.");

            timeTotal = TimeSheetProcessor.CalculateTimeForCustomer(timeSheetEntries, "ABC");
            Console.WriteLine("Simulating Sending email to ABC");
            Console.WriteLine("Your bill is $" + timeTotal * 125 + " for the hours worked.");
            for (int i = 0; i < timeSheetEntries.Count; i++)
            {
                timeTotal += timeSheetEntries[i].HoursWorked;
            }
            if (timeTotal > 40)
            {
                Console.WriteLine("You will get paid $" + timeTotal * 15 + " for your work.");
            }
            else
            {
                Console.WriteLine("You will get paid $" + timeTotal * 10 + " for your time.");
            }
            Console.WriteLine();
            Console.Write("Press any key to exit application...");
            Console.ReadKey();
        }

        static void SimulateSendingMail(String customerName, int hours, decimal hourlyRate)
        {
            decimal amountToBill = hours * hourlyRate;

            Console.WriteLine($"Simulating Sending email to {customerName}");
            Console.WriteLine($"Your bill is {amountToBill} for the hours worked.");
        }


    }
       
}
