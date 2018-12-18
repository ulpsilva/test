using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Test.Controllers
{
    public class Sort
    {
        public static string cyclicSort(char[] input, int ordering)
        {
            return cyclicSort(input, ordering, ordering);
        }

        private static string cyclicSort(char[] input, int ordering, int originalOrdering)
        {
            if (input.Length <= 1)
            {
                return new string(input);
            }

            int currentOrdering;
            if (input.Length < ordering)
            {
                currentOrdering = ordering % input.Length;
            }
            else
            {
                currentOrdering = ordering;
            }

            if (currentOrdering == 0)
            {
                currentOrdering = input.Length - 1;
            }
            else
            {
                currentOrdering--;
            }

            var outputChar = input[currentOrdering];

            input = input.Where((source, index) => index != currentOrdering).ToArray();

            var output = cyclicSort(input, currentOrdering + originalOrdering, originalOrdering);

            return (outputChar + output); ;
        }

        public static string cyclicSortReverse(char[] input, int ordering)
        {
            char[] output = new char[input.Length];
            int currentOrdering = 0;
            while (input.Length > 0)
            {
                var i = 0;
                while (i < ordering)
                {
                    if (output.Length > currentOrdering && output[currentOrdering] != '\0')
                    {
                        currentOrdering++;
                    }
                    else
                    {
                        if (output.Length <= currentOrdering)
                        {
                            currentOrdering = currentOrdering % output.Length;
                        }
                        else
                        {
                            currentOrdering++;
                            i++;
                        }
                    }
                }

                output[currentOrdering - 1] = input[0];
                
                
                input = input.Where((source, index) => index != 0).ToArray();
            }

            return new string(output);
        }

    }
}