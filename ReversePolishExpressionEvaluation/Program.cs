using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ReversePolishExpressionEvaluation
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] expressionArray = new string[] {"15", "7", "1", "1", "+", "-", "/", "3", "*", "2", "1", "1", "+", "+", "-" };
            //To mimick the stack concept
            List<int> valArray = new List<int>();

            int exp = 0;

            for(int i= 0; i < expressionArray.Length; i++)
            {
                //Checking if the item is a operand or an operator
                if(Regex.IsMatch(expressionArray[i], @"^[0-9]+$")) {
                    valArray.Add(Convert.ToInt32(expressionArray[i]));
                }
                else
                {   //Determining the current length of the valArray
                    int valArrayCurrentLength = valArray.Count;
                    switch (expressionArray[i])
                    {
                        case "+": //Performing the operation on the top 2 elements of the list (imagine as a stack)
                            exp =  (valArray[valArray.Count - 2] + valArray[valArray.Count - 1]);
                            valArray.RemoveAt(valArrayCurrentLength - 1);
                            valArray.RemoveAt(valArrayCurrentLength - 2);
                            valArray.Add(exp);
                            break;
                        case "*":
                            exp = (valArray[valArray.Count - 2] * valArray[valArray.Count - 1]);
                            valArray.RemoveAt(valArrayCurrentLength - 1);
                            valArray.RemoveAt(valArrayCurrentLength - 2);
                            valArray.Add(exp);
                            break;
                        case "-":
                            exp =  (valArray[valArray.Count - 2] - valArray[valArray.Count - 1]);
                            valArray.RemoveAt(valArrayCurrentLength - 1);
                            valArray.RemoveAt(valArrayCurrentLength - 2);
                            valArray.Add(exp);
                            break;
                        case "/":
                            exp = (valArray[valArray.Count - 2] / valArray[valArray.Count - 1]);
                            valArray.RemoveAt(valArrayCurrentLength - 1);
                            valArray.RemoveAt(valArrayCurrentLength - 2);
                            valArray.Add(exp);
                            break;
                    } 
                }

            }

            Console.WriteLine("Given Expression Evaluated to {0}", exp);
            Console.ReadKey();

        }
    }
}
