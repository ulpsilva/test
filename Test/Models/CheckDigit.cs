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

        public static string CheckEvenlyDistributed(int startNumber, int endNumber, int[] multipliers)
        {
            List<int> checkDigits = new List<int>();

            for (int i = startNumber; i <= endNumber; i++)
            {
                checkDigits.Add(GetCheckDigit(i.ToString(), multipliers));
            }

            Dictionary<int, int> counts = checkDigits.GroupBy(x => x).ToDictionary(g => g.Key, g => g.Count());

            bool isEvenlyDistributed = true;
            int maxfrqz = counts.First().Value;
            int minfrqz = counts.First().Value;
            int lastValue = counts.First().Value;

            List<int> maxDigits = new List<int>();
            List<int> minDigits = new List<int>();

            foreach (KeyValuePair<int, int> entry in counts)
            {
                if (lastValue != entry.Value)
                {
                    isEvenlyDistributed = false;
                }

                if (maxfrqz < entry.Value)
                {
                    maxfrqz = entry.Value;
                    maxDigits = new List<int>();
                }

                if (maxfrqz == entry.Value)
                {
                    maxDigits.Add(entry.Key);
                }

                if (minfrqz > entry.Value)
                {
                    minfrqz = entry.Value;
                    minDigits = new List<int>();
                }

                if (minfrqz == entry.Value)
                {
                    minDigits.Add(entry.Key);
                }
            }

            if (isEvenlyDistributed)
            {
                return "The occurrence of the check digits is evenly distributed between " + startNumber +" to " + endNumber;
            }
            else
            {
                return "The occurrence of the check digits is not evenly distributed between " + startNumber + " to " + endNumber + " and " +
                       "Highest frequency check digits is " + string.Join(", ", maxDigits) + " and " +
                       "Lowest frequency check digits is " + string.Join(", ", minDigits);
            }

        }

    }
}