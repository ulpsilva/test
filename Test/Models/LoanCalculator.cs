using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Test.Models
{
    public class LoanCalculator
    {
        public static double GetMonthlyRepayment(double principleAmount, double percentageRatePerYear, 
            int numberOfYears)
        {
            var rate = percentageRatePerYear / (100 * 12);
            var numberOfPayments = numberOfYears * 12;
            var payment = principleAmount * (rate * Math.Pow(1 + rate, numberOfPayments)) / 
                          (Math.Pow(1 + rate, numberOfPayments) - 1);
            return Math.Round(payment, 2);
        }

        public static int GetNumberOfYears(double principleAmount, double percentageRatePerYear, double payment)
        {
            var rate = percentageRatePerYear / (100 * 12);
            var numberOfYears = Math.Log10(payment / (payment - principleAmount * rate)) / Math.Log10(1 + rate);
            return (int) numberOfYears / 12;
        }

        private static double GetLoanAmount(double percentageRatePerYear, double payment, int numberOfYears)
        {
            var rate = percentageRatePerYear / (100 * 12);
            var numberOfPayments = numberOfYears * 12;
            var amount = payment * (Math.Pow(1 + rate, numberOfPayments) - 1) /
                         (rate * Math.Pow(1 + rate, numberOfPayments));
            return Math.Round(amount, 2);
        }

        /*
         * If loan period exceeds the maxNumberOfYears loan amount will recalculate using
         * the numberOfYearsForRecalculate
         */
        public static double CheckYearsAndGetLoanAmount(double principleAmount, double percentageRatePerYear,
            double payment, int maxNumberOfYears, int numberOfYearsForRecalculate)
        {
            if (GetNumberOfYears(principleAmount, percentageRatePerYear, payment) > maxNumberOfYears)
            {
                return GetLoanAmount(percentageRatePerYear, payment, numberOfYearsForRecalculate);
            }
            else
            {
                return principleAmount;
            }
        }
    }
}