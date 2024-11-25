using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int outPInt = 0;
            bool intOut = false;
            Console.WriteLine("What is your First Number?");
            double firstNum = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine(firstNum);
            Console.WriteLine("1.) +");
            Console.WriteLine("2.) -");
            Console.WriteLine("3.) *");
            Console.WriteLine("4.) /");
            int Opp = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("What is your Second Number?");
            double secNum = Convert.ToDouble(Console.ReadLine());
            if (Opp == 1)
            {
                double outP = firstNum + secNum;
                if ((outP % 1) == 0)
                {
                    outPInt = Convert.ToInt32(outP);
                    intOut = true;
                }
                if (intOut == true)
                {
                    Console.WriteLine(outPInt);
                }
                else
                {
                    Console.WriteLine(outP);
                }
            }
            if (Opp == 2)
            {
                double outP = firstNum - secNum;
                if ((outP % 1) == 0)
                {
                    outPInt = Convert.ToInt32(outP);
                    intOut = true;
                }
                if (intOut == true)
                {
                    Console.WriteLine(outPInt);
                }
                else
                {
                    Console.WriteLine(outP);
                }
            }
            if (Opp == 3)
            {
                double outP = firstNum * secNum;
                if ((outP % 1) == 0)
                {
                    outPInt = Convert.ToInt32(outP);
                    intOut = true;
                }
                if (intOut == true)
                {
                    Console.WriteLine(outPInt);
                }
                else
                {
                    Console.WriteLine(outP);
                }
            }
            if (Opp == 4)
            {
                double outP = firstNum / secNum;
                if ((outP % 1) == 0)
                {
                    outPInt = Convert.ToInt32(outP);
                    intOut = true;
                }
                if (intOut == true)
                {
                    Console.WriteLine(outPInt);
                }
                else
                {
                    Console.WriteLine(outP);
                }
            }

        }
    }
}
