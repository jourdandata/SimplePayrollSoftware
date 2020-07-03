using System;
namespace SimplePayrollSoftware
{
    public class Admin : Staff
    {
        // Child field
        private const float overtimeRate = 15.5f;
        private const float adminHourlyRate = 30f;

        // Child Properties
        public float Overtime { get; private set; }

        // Child Constructor
        public Admin(string name) : base(name, adminHourlyRate)
        {
        }

        // Child method
        public override void CalculatePay()
        {
            base.CalculatePay();
            if (HoursWorked > 160)
                Overtime = overtimeRate * (HoursWorked - 160);
                TotalPay = BasicPay + Overtime;
        }

        public override string ToString()
        {
            return "Staff Name: " + NameOfStaff + "\nHourly Rate: " + adminHourlyRate +
            "\nHours Worked: " + HoursWorked + "\nBasic Pay: " + BasicPay +
            "\nOvertime: " + Overtime + "\nTotal Pay: " + TotalPay;
        }
    }
}
