using System;
using System.IO;

namespace MDPyramid
{
    class Program
    {
        static bool isEven(int number)
        {
            if((number % 2) == 0)
            {
                return true;
            }else
            {
                return false;
            }
        }
        static void infoPrint(bool e, int n, long s, int p)
        {
            if(e) Console.WriteLine($"{n} is even");
            else Console.WriteLine($"{n} is  not even");
            Console.WriteLine($"Current sum is {s}");
            Console.WriteLine($"Current position is {++p}");
        }
        static void Main(string[] args)
        {
            int start = 0; //the position where binary tree starts
            int pos = start; //the current position to find it childs
            long sum = 0; //sum of binary tree
            bool even = false; //a bool
            int num;
            int comp1, comp2;
            using (TextReader reader = File.OpenText("samples/advancedsample.txt"))
            {
                string datasample;
                while ((datasample = reader.ReadLine()) != null)
                {
                    string[] bits = datasample.Split(' ');
                    int len = bits.Length;
                    Console.WriteLine($"Line length = {len}");
                    if(len == 1)
                    {
                        num = Convert.ToInt32(bits[pos]);
                        even = isEven(num);
                        sum += num;
                        infoPrint(even, num, sum, pos);
                    }else
                    {
                        comp1 = Convert.ToInt32(bits[pos]);
                        comp2 = Convert.ToInt32(bits[pos+1]);
                        Console.WriteLine($"Childs for compare is {comp1} and {comp2}");
                        if(!even)
                        {
                            if(comp1 % 2 == 0 && comp2 % 2 == 0)
                            {
                                if(comp1 > comp2)
                                {
                                    sum += comp1;
                                    even = isEven(comp1);
                                    infoPrint(even, comp1, sum, pos);
                                }else
                                {
                                    sum += comp2;
                                    pos++;
                                    even = isEven(comp2);
                                    infoPrint(even, comp2, sum, pos);
                                }
                            }else if(comp1 % 2 == 0)
                            {
                                sum += comp1;
                                even = isEven(comp1);
                                infoPrint(even, comp1, sum, pos);
                            }else if(comp2 % 2 == 0)
                            {
                                sum += comp2;
                                pos++;
                                even = isEven(comp2);
                                infoPrint(even, comp2, sum, pos);
                            }
                        }else
                        {
                            if(comp1 % 2 != 0 && comp2 % 2 != 0)
                            {
                                if(comp1 > comp2)
                                {
                                    sum += comp1;
                                    even = isEven(comp1);
                                    infoPrint(even, comp1, sum, pos);
                                }else
                                {
                                    sum += comp2;
                                    pos++;
                                    even = isEven(comp2);
                                    infoPrint(even, comp2, sum, pos);
                                }
                            }else if(comp1 % 2 != 0)
                            {
                                sum += comp1;
                                even = isEven(comp1);
                                infoPrint(even, comp1, sum, pos);
                            }else if(comp2 % 2 != 0)
                            {
                                sum += comp2;
                                pos++;
                                even = isEven(comp2);
                                infoPrint(even, comp2, sum, pos);
                            }
                        }
                    }   
                    Console.WriteLine("------------------------------");     
                }
                Console.WriteLine($"The final output of Sum is {sum}");
            }
        }
    }
}
