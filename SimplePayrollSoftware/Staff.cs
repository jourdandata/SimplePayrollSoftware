using System;
namespace SimplePayrollSoftware
{
    public class Staff
    {
        // Parent class fields
        private float hourlyRate;
        private int hWorked;

        // Parent class Properties
        public float TotalPay { get; protected set; }
        public float BasicPay { get; private set; }
        public string NameOfStaff { get; private set; }

        // a class Property with logic
        public int HoursWorked
        {
            get
            {
                return hWorked;
            }
            set
            {
                if (value > 0)
                    hWorked = value;
                else
                    hWorked = 0;
            }
        }

        // Parent class Constructor
        public Staff(string aName, float aRate)
        {
            NameOfStaff = aName;
            hourlyRate = aRate;
        }

        // Parent virtual method to be used by the Child classes
        public virtual void CalculatePay()
        {
            Console.WriteLine("Calculating Pay...");
            BasicPay = hWorked * hourlyRate;
            TotalPay = BasicPay;
        }

        // Parent ToString() method
        public override string ToString()
        {
            return "Staff Name: " + NameOfStaff + "\nHourly Rate: " + hourlyRate +
                "\nHours Worked: " + hWorked + "\nBasic Pay: " + BasicPay +
                "\nTotal Pay: " + TotalPay;
        }
    }
}
