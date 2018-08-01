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
        static void Main(string[] args)
        {
            int start = 0; //the position where binary tree starts
            int pos = start;
            long sum = 0;
            bool even = false;
            int num;
            int comp1, comp2;
            using (TextReader reader = File.OpenText("sample.txt"))
            {
                string datasample;
                while ((datasample = reader.ReadLine()) != null)
                {
                    string[] bits = datasample.Split(' ');
                    int len = bits.Length;
                    Console.WriteLine($"len = {len}");
                    if(len == 1)
                    {
                        num = Convert.ToInt32(bits[pos]);
                        even = isEven(num);
                        if(even) Console.WriteLine($"{num} is even");
                        else Console.WriteLine($"{num} is  not even");
                        sum += num;
                        Console.WriteLine($"sum = {sum}");
                    }else
                    {
                        comp1 = Convert.ToInt32(bits[pos]);
                        comp2 = Convert.ToInt32(bits[pos+1]);
                        if(even) Console.WriteLine("last number even");
                        else Console.WriteLine("last number !even");
                        Console.WriteLine($"here, comp1 = {comp1} and comp2 = {comp2}");
                        if(!even)
                        {
                            if(comp1 % 2 == 0 && comp2 % 2 == 0)
                            {
                                if(comp1 > comp2)
                                {
                                    sum += comp1;
                                    even = isEven(comp1);
                                    Console.WriteLine($"sum = {sum}, pos = {pos}");
                                }else
                                {
                                    sum += comp2;
                                    pos++;
                                    even = isEven(comp2);
                                    Console.WriteLine($"sum = {sum}, pos = {pos}");
                                }
                            }else if(comp1 % 2 == 0)
                            {
                                sum += comp1;
                                even = isEven(comp1);
                                Console.WriteLine($"sum = {sum}, pos = {pos}");
                            }else if(comp2 % 2 == 0)
                            {
                                sum += comp2;
                                pos++;
                                even = isEven(comp2);
                                Console.WriteLine($"sum = {sum}, pos = {pos}");
                            }
                            //bits[next] bits[next+1]

                        }else
                        {
                            if(comp1 % 2 != 0 && comp2 % 2 != 0)
                            {
                                if(comp1 > comp2)
                                {
                                    sum += comp1;
                                    even = isEven(comp1);
                                    Console.WriteLine($"sum = {sum}, pos = {pos}");
                                }else
                                {
                                    sum += comp2;
                                    pos++;
                                    even = isEven(comp2);
                                    Console.WriteLine($"sum = {sum}, pos = {pos}");
                                }
                            }else if(comp1 % 2 != 0)
                            {
                                sum += comp1;
                                even = isEven(comp1);
                                Console.WriteLine($"sum = {sum}, pos = {pos}");
                            }else if(comp2 % 2 != 0)
                            {
                                sum += comp2;
                                pos++;
                                even = isEven(comp2);
                                Console.WriteLine($"sum = {sum}, pos = {pos}");
                            }
                        }
                        //start = next;
                    }   
                    Console.WriteLine("-------------------------");     
                }
                Console.WriteLine($"sum = {sum}");
            }
        }
    }
}
