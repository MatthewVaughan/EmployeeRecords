using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project12
{
    class Employees
    {
        //Declare the fields of the class
        private int 
            hoursWorked,
            employeeNumber;
        private string
            name,
            streetAddress;
        private double hourlyWage;

        /// <summary>
        /// Employee Constructor
        /// </summary>
        /// <param name="eNumber"></param>
        /// <param name="eName"></param>
        /// <param name="eAddress"></param>
        /// <param name="hWorked"></param>
        /// <param name="hWage"></param>
        public Employees(int eNumber, string eName, string eAddress, int hWorked, double hWage)
        {
            //Assign the parameters to the correct fields
            employeeNumber = eNumber;
            name = eName;
            streetAddress = eAddress;
            hoursWorked = hWorked;
            hourlyWage = hWage;
        }

        /// <summary>
        /// Get Name Method
        /// </summary>
        /// <returns></returns>
        public string GetEmployeeName()
        {
            return name;
        }

        /// <summary>
        /// Get Address Method
        /// </summary>
        /// <returns></returns>
        public string GetStreetAddress()
        {
            return streetAddress;
        }

        /// <summary>
        /// Get pay method
        /// </summary>
        /// <returns></returns>
        public double GetPay()
        {
            //Return the product of the hours worked and the hourly wage
            return hourlyWage * hoursWorked;
        }
    }
}
