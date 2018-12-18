using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Test.Models
{
    public class CheckDigit
    {
        public static int GetCheckDigit(string numberString, int[] multipliers)
        {
            int[] numArray = numberString.ToCharArray().Select(x => (int)Char.GetNumericValue(x)).ToArray();
            int[] resultArray = new int[multipliers.Length];

            for (int i = 0, j = 0; i < numArray.Length; i++)
            {
                resultArray[j] = resultArray[j] + (numArray[i] * multipliers[j]);
                j++;

                if (j == multipliers.Length)
                {
                    j = 0;
                }
                
            }

            return GetTotal(resultArray);
        }

        private static int GetTotal(int[] numArray)
        {
            int sum = numArray.Sum();
            int[] sumArray = sum.ToString().ToCharArray().Select(x => (int)Char.GetNumericValue(x)).ToArray();
            if (sumArray.Length > 1)
            {
                return GetTotal(sumArray);
            }

            return sum;
        }

    }
}