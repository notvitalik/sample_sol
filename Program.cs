﻿// See https://aka.ms/new-console-template for more information
using System;
using System.Text;
using System.Collections.Generic;

namespace mapSentence
{

    class mapper
    {
        static void Main(string[] args)        
        {
            try
            {
                //Console.WriteLine("Enter sentence : ");
                //string input = Console.ReadLine();
                //string input = "Space2Separated2Space";
                string input = "";
                string result = mapsentence(input);
                Console.WriteLine(result);
            }
            catch(Exception ex)
            {
                Console.WriteLine("Message :" + ex.Message);
                Console.WriteLine("Inner Exception : " + ex.InnerException);

            }
           
        }

        static bool isalphabet(char c)
        {
            bool isalpha = false;
            try
            {
                int ascival = (int)c;
                if ((ascival >= 65 && ascival <= 90) || (ascival >= 97 && ascival <= 122)) { isalpha = true; }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Message :" + ex.Message);
                Console.WriteLine("Inner Exception : " + ex.InnerException);
            }
            return isalpha;
        }

        static string mapsentence(string s)
        {
            StringBuilder result = new StringBuilder();
            bool getlen = false;
            HashSet<char> hs = new HashSet<char>();
            int len = 0;
            try
            {
                for (var index = 0; index < s.Length; index++)
                {
                    char c = s[index];
                    if (isalphabet(c) && !getlen)
                    {
                        result.Append(c);
                        getlen = true;
                    }
                    else if (isalphabet(c) && getlen)
                    {
                        hs.Add(c);
                        len++;
                    }
                    else if (!isalphabet(c))
                    {
                        result.Append(hs.Count-1);
                        result.Append(s[index - 1]);
                        result.Append(c);
                        getlen = false;
                        hs = new HashSet<char>();
                    }
                    //end of sentence
                    if (index == s.Length - 1)
                    {
                        result.Append(hs.Count - 1);
                        result.Append(c);
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Message :"+ ex.Message);
                Console.WriteLine("Inner Exception : " + ex.InnerException);
            }

            return result.ToString();
        }

    }

}


