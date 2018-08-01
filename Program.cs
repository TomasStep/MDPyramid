using System;
using System.IO;

namespace MDPyramid
{
    class Program
    {
        //Basic check for numbers to assure it's even or odd
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
        //Basic print to console
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
            bool even = false; //a bool of father
            int num; //current number
            int comp1, comp2; //compare numbers, to choose path
            using (TextReader reader = File.OpenText("samples/complexsample.txt"))
            {
                string datasample;
                //while for reading a text file line by line, until an empty line
                while ((datasample = reader.ReadLine()) != null)
                {
                    string[] bits = datasample.Split(' '); //an array of all integers in a line
                    int len = bits.Length; //length of array
                    Console.WriteLine($"Line length = {len}");
                    if(len == 1) //check for binary tree start position
                    {
                        num = Convert.ToInt32(bits[pos]);
                        even = isEven(num); //check converted number if it's even or odd
                        sum += num; //because its only number in line its added to sum
                        infoPrint(even, num, sum, pos); //prints all information
                    }else
                    {
                        comp1 = Convert.ToInt32(bits[pos]);
                        comp2 = Convert.ToInt32(bits[pos+1]);
                        Console.WriteLine($"Childs for compare is {comp1} and {comp2}");
                        //Only 2 possiblities to pick even child or odd, 
                        //based on what father is
                        //Basic if commands to assure that picked child is different 
                        //because we're aiming for maximum sum, if both childs the same
                        //we pick bigger one
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
