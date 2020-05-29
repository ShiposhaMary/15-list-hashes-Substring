using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubstringthroughtHash
{
    class Program
    { 
        public static bool Equals(string text,string substring,int index)
        {
            for(int i=0;i<substring.Length;i++)
                if(text[index+i]!=substring[i]) return false;
            return true;
        }
        private static int IndexOf(string text, string substring)
        {
            if (text.Length < substring.Length) return -1;

            long prime = 1000;
            long maxPower = 1;
            long substringHash = 0;
            long hash = 0;
            for (int i = 0; i < substring.Length; i++)
            {
                hash = hash * prime + text[i];
                substringHash = substringHash * prime + substring[i];
                maxPower *= prime;
            }
            maxPower /= prime;
            for (int i = 0; ; i++)
            {
                if (hash == substringHash)
                {
                    if (Equals(text,substring,i)) return i;
                }
                if (i>=text.Length - substring.Length) break;
                hash -= text[i] * maxPower;
                hash = hash * prime + text[substring.Length+i];
            }
            return -1;
        }
            

        private static void Main()
        {
            Console.WriteLine(IndexOf("abcdefg", "cde"));
            Console.ReadKey();
        }
    }
}
