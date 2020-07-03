using System;
using System.Collections.Generic;
using System.IO;

namespace SimplePayrollSoftware
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Staff> myStaff;
            FileReader fr = new FileReader();
            int month = 0;
            int year = 0;

            while (year == 0)
            {
                Console.WriteLine("\nPlease enter the year: ");

                try
                {
                    // Code to convert the input to an integer
                    Console.WriteLine("Enter the 4 digit year for the pay slip: ");
                    year = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException)
                {
                    // Code to handle the exception
                    year = 0;
                    Console.WriteLine("Please enter a valid 4 digit year to proceed.");
                }
            }

            while (month == 0)
            {
                Console.WriteLine("\nPlease enter the month: ");

                try
                {
                    // try to convert the input to an integer
                    Console.WriteLine("Enter the two digit month: ");
                    month = Convert.ToInt32(Console.ReadLine());
                    if (month < 1 || month > 12)
                    {
                        month = 0;
                        Console.WriteLine("The input is invalid.");
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("You have entered an invalid 2 digit month.");
                }
            }

            myStaff = fr.ReadFile();

            for (int i = 0; i < myStaff.Count; i++)
            {
                try
                {
                    Console.WriteLine("Enter the number of hours worked for {0}: ", myStaff[i].NameOfStaff);
                    myStaff[i].HoursWorked = Convert.ToInt32(Console.ReadLine());
                    myStaff[i].CalculatePay();
                    Console.WriteLine(myStaff[i].ToString());
                }
                catch (Exception e)
                {
                    Console.WriteLine("The entry was invalid. Please try again");
                    i--;
                }
            }

            PaySlip ps = new PaySlip(month, year);
            ps.GeneratePaySlip(myStaff);
            ps.GenerateSummary(myStaff);
            Console.Read();
            

        }
    }
}
