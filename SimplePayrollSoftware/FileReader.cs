using System;
using System.Collections.Generic;
using System.IO;
namespace SimplePayrollSoftware
{
    public class FileReader
    {
        
        public List<Staff> ReadFile()
        {
            // Fields to make the class word
            string filePath = "/Users/emmanuel/Projects/SimplePayrollSoftware/SimplePayrollSoftware/staff.txt";
            string[] separator = { ", " };
            string[] result = new string[2];
            List<Staff> myStaff = new List<Staff>();

            if (File.Exists(filePath)) // Use brackets on all if statements
            {
                using (StreamReader sr = new StreamReader(filePath))
                {
                    while (!sr.EndOfStream)
                    {
                        result = sr.ReadLine().Split(separator,
                            StringSplitOptions.RemoveEmptyEntries);
                        if (result[1] == "Manager")
                            myStaff.Add(new Manager(result[0]));
                        else if (result[1] == "Admin")
                            myStaff.Add(new Admin(result[0]));
                    }
                    sr.Close();
                }
            }
            else
            {
                Console.WriteLine("Error, file does not exist.");
            }
            return myStaff;
            
        }
    }
}
