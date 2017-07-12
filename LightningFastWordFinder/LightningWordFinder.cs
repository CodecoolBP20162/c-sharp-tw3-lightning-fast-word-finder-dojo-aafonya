using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace LightningFastWordFinder
{
    class LightningWordFinder
    {
        public static string thelongest;

        public string GetLongestWord(string text)
        {
            int begin = 0;
            int end = 0;
            int beginIndex = 0;
            int endIndex = 0;
            bool beginOrEnd = true;
            

            int longest = 0;

            List<string> longestWords = new List<string>();
            for(int i = 0; i < text.Length; i++)
            {
                if (char.IsWhiteSpace(text[i]) || text[i].Equals(@"\s") )
                {
                    if (beginOrEnd)
                    {
                        begin = i + 1;
                        beginOrEnd = !beginOrEnd;

                    } else
                    {
                        end = i;
                        beginOrEnd = !beginOrEnd;

                        if (end - begin > longest)
                        {
                            longest = end - begin;
                            beginIndex = begin;
                            endIndex = end;
                            string longestWord = text.Substring(beginIndex, (endIndex - beginIndex));
                            longestWords.Add(longestWord);
                        }

                    }
                }
            }

            
            for (int i = longestWords.Count - 1; i > 0; i--)
            {
                if(Regex.IsMatch(longestWords[i], @"^[a-zA-Z]+$")){
                    thelongest = longestWords[i];
                    break;
                }

            }
            
            return thelongest;
        }
    }
}
