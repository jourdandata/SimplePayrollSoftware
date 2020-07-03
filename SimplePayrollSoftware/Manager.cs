using System;
namespace SimplePayrollSoftware
{
    public class Manager : Staff
    {
        // Child Fields
        private const float managerHourlyRate = 50;

        // Child Properties
        public int Allowance { get; private set; }

        // Child Constructor
        public Manager(string name) : base(name, managerHourlyRate)
        {
        }

        // Child method
        public override void CalculatePay()
        {
            base.CalculatePay(); // to gain access to the Parent members
            Allowance = 1000;
            if (HoursWorked > 160)
                TotalPay = BasicPay + Allowance;

        }

        public override string ToString()
        {
            return "Staff Name: " + NameOfStaff + "\nHourly Rate: " + managerHourlyRate +
                "\nHours Worked: " + HoursWorked + "\nBasic Pay: " + BasicPay +
                "\nAllowance: " + Allowance + "\nTotal Pay: " + TotalPay;
        }
    }
}
