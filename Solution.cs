// See https://aka.ms/new-console-template for more information
//write a program that parses a sentence and replaces each word with the following: 
//first letter, number of distinct characters between first and last character, and last letter.
//Words are separated by spaces or non-alphabetic characters and these separators should be maintained in their original form and location in the answer. 

//Examples: 
//“Smooth” becomes “S3h”
//“Space separated” becomes “S3e s5d”
//“Dash-separated” becomes “D2h-s5d”
//“Number2separated” becomes “N4r2s5d” 

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
                //string input = "Space-Spaces-Space";
                //string input = "sos-sos-sos";
                //string input = "ss-ss-ss";
                string input = "Space###SpacesSpaces###Space";
                string result = ParseSentence(input);
                Console.WriteLine(result);
            }
            catch(Exception ex)
            {
                Console.WriteLine("Exception in Main - Message :" + ex.Message);
                if(ex.InnerException!=null)
                    Console.WriteLine("Inner Exception : " + ex.InnerException);

            }
           
        }

        static string getDelimiter(string s)
        {
            StringBuilder sbdel = new StringBuilder();
            var delimlocated=false;
            try
            {
                for(int index=0;index<s.Length;index++)
                {
                    if(isalphabet(s[index])&& !delimlocated) continue;
                    else if(isalphabet(s[index])&& delimlocated) break;
                    else if(!isalphabet(s[index]) && !delimlocated) {delimlocated=true;sbdel.Append(s[index]);}
                    else if(!isalphabet(s[index]) && delimlocated) {sbdel.Append(s[index]);}
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception in getDelimiter - Message :" + ex.Message);
                if(ex.InnerException!=null)
                    Console.WriteLine("Inner Exception : " + ex.InnerException);
            }

            return sbdel.ToString();
        }
        
        static string ParseSentence(string s)
        {
            StringBuilder result = new StringBuilder();
           
            try
            {
                string delimiter = getDelimiter(s);
                string[] words = s.Split(delimiter).ToArray();
                foreach(var word in words)
                {
                    HashSet<char> hs = new HashSet<char>();
                    for(int index=1;index<word.Length-1;index++)
                    {
                        hs.Add(word[index]);
                    }

                    result.Append(word[0]);
                    result.Append(hs.Count);
                    result.Append(word[word.Length-1]);
                    result.Append(delimiter);
                }
                result.Remove(result.Length-delimiter.Length,delimiter.Length);
            }
            catch(Exception ex)
            {
                Console.WriteLine("ParseSentence - Error Message :" + ex.Message);
                Console.WriteLine("Inner Exception : " + ex.InnerException);
            }
            
            return result.ToString();
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
                Console.WriteLine("Exception in isalphabet - Message :" + ex.Message);
                if(ex.InnerException!=null)
                    Console.WriteLine("Inner Exception : " + ex.InnerException);
            }
            return isalpha;
        }

        static string mapsentence(string s)
        {
            string delim = getDelimiter(s);

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
                        result.Append(delim);
                        getlen = false;
                        hs = new HashSet<char>();
                        index+=delim.Length-1;
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
                Console.WriteLine("Exception in mapsentence - Message :"+ ex.Message);
                if(ex.InnerException!=null)
                    Console.WriteLine("Inner Exception : " + ex.InnerException);
            }
            return result.ToString();
        }
     }
}


