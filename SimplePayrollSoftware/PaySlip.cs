using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SimplePayrollSoftware
{
    class PaySlip
    {
        private int month;
        private int year;

        enum MonthsOfYear
        {
            JAN, FEB, MAR, APR, MAY, JUN, JUL, AUG, SEP, OCT, NOV, DEC
        }

        public PaySlip(int payMonth, int payYear)
        {
            month = payMonth;
            year = payYear;
        }

        public void GeneratePaySlip(List<Staff> myStaff)
        {
            string path;

            foreach (Staff staffMember in myStaff)
            {
                path = "/Users/emmanuel/Projects/SimplePayrollSoftware/SimplePayrollSoftware/Outputs/" + staffMember.NameOfStaff + ".txt";
                StreamWriter sw = new StreamWriter(path);

                sw.WriteLine("PAYSLIP FOR {0} {1}", (MonthsOfYear)month, year);
                sw.WriteLine("===========================");
                sw.WriteLine("Name of Staff: {0}", staffMember.NameOfStaff);
                sw.WriteLine("Hours Worked: {0}", staffMember.HoursWorked);
                sw.WriteLine("");
                sw.WriteLine("Basic Pay: {0:C}", staffMember.BasicPay);

                // get the runtime type of the current object
                if (staffMember.GetType() == typeof(Manager))
                    sw.WriteLine("Allowance: {0:C}", ((Manager)staffMember).Allowance);
                else if (staffMember.GetType() == typeof(Admin))
                    sw.WriteLine("Overtime: {0:C}", ((Admin)staffMember).Overtime);
                sw.WriteLine("===========================");
                sw.WriteLine("Total Pay: {0:C}", staffMember.TotalPay);
                sw.WriteLine("===========================");
                sw.Close();
            }
        }

        public void GenerateSummary(List<Staff> myStaff)
        {
            var result =
                from staff in myStaff
                where staff.HoursWorked < 10
                orderby staff.NameOfStaff ascending
                select new { staff.NameOfStaff, staff.HoursWorked };

            string path = "/Users/emmanuel/Projects/SimplePayrollSoftware/SimplePayrollSoftware/Outputs/summary.txt";

            StreamWriter sr = new StreamWriter(path);
            sr.WriteLine("Staff with less than 10 working hours");

            foreach(var employee in result)
                sr.WriteLine("Name of Staff: {0}, Hours Worked: {1}: ", employee.NameOfStaff, employee.HoursWorked);

            sr.Close();
        }

        public override string ToString()
        {
            return base.ToString();

        }

    }
}

