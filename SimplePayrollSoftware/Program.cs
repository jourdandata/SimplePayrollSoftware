using System;
using System.Collections.Generic;
using System.IO;

namespace SimplePayrollSoftware
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create class fields
            List<Staff> myStaff;
            int month = 0;
            int year = 0;

            // FileReader reads names and positions from a text file
            // and returns a list of Staff objects.
            FileReader fr = new FileReader();

            // Get 4 digit year from user input.
            while (year == 0)
            {
                Console.WriteLine("\nPlease enter the year: ");

                try
                {
                    // Code to convert the input to an integer
                    Console.Write("Enter the 4 digit year for the pay slip: ");
                    year = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException)
                {
                    // Code to handle the exception
                    year = 0;
                    Console.WriteLine("Please enter a valid 4 digit year to proceed.");
                }
            }

            // Get 2 digit month from user input.
            while (month == 0)
            {
                Console.WriteLine("\nPlease enter the month: ");

                try
                {
                    // try to convert the input to an integer
                    Console.Write("Enter the two digit month: ");
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

            // Assign the returned list of Staff objects to variable myStaff
            myStaff = fr.ReadFile();

            // Ask the user for the hours worked for each Staff object in myStaff
            // Calculate the hours worked for each person
            // Print the information for each Staff person
            for (int i = 0; i < myStaff.Count; i++)
            {
                try
                {
                    Console.Write("Enter the number of hours worked for {0}: ", myStaff[i].NameOfStaff);
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

            // Create a new payslips for each person in the List for the period
            // Create a new summary report for the period
            PaySlip ps = new PaySlip(month, year);
            ps.GeneratePaySlip(myStaff);
            ps.GenerateSummary(myStaff);
            Console.Read();
            
        }
    }
}
