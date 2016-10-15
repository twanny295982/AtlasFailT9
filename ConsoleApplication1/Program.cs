using System;
using System.Collections.Generic;
using System.Linq;

namespace AtlasTMobileProblem
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var tAssocs = new List<TAssoc>
            {
                new TAssoc(2, new[] {'a', 'b', 'c'}),
                new TAssoc(3, new[] {'d', 'e', 'f'}),
                new TAssoc(4, new[] {'g', 'h', 'i'}),
                new TAssoc(5, new[] {'j', 'k', 'l'}),
                new TAssoc(6, new[] {'m', 'n', 'o'}),
                new TAssoc(7, new[] {'p', 'q', 'r', 's'}),
                new TAssoc(8, new[] {'t', 'u', 'v'}),
                new TAssoc(9, new[] {'w', 'x', 'y', 'z'})
            };

            var outP = "";
            var clist = SplitToChars("hello this is me");

            for (var i = 0; i < clist.Count; i++)
            {
                //if the character is not an empty space we want to return its cell numeric representation
                if (clist[i] != ' ')
                {
                    // if its not a space we need to check if there should be a pause between one and the other.
                    for (var j = 0;
                        j <= tAssocs.Find(a => a.CharAssoc.Contains(clist[i]))
                            .ReturnOldCellCharSequenceForChar(clist[i]);
                        j++)
                    {
                        outP += tAssocs.Find(a => a.CharAssoc.Contains(clist[i])).AssocNumber;
                    }

                    if (i + 1 < clist.Count)
                    {
                        if (tAssocs.Find(a => a.CharAssoc.Contains(clist[i])) ==
                            tAssocs.Find(a => a.CharAssoc.Contains(clist[i + 1])))
                        {
                            outP += " ";
                        }
                    }
                }
                else
                {
                    //otherwise we just append the space to the sequence
                    outP += " ";
                }
            }

            Console.WriteLine(outP);

            Console.ReadKey();
        }

        public static List<char> SplitToChars(string phrase)
        {
            var words = phrase.ToCharArray();

            return words.ToList();
        }
    }

    internal class TAssoc
    {
        public TAssoc(int assocNumber, char[] assoc)
        {
            AssocNumber = assocNumber;
            CharAssoc = assoc;
        }

        public int AssocNumber { get; }
        public char[] CharAssoc { get; }

        public int ReturnOldCellCharSequenceForChar(char c)
        {
            return Array.FindIndex(CharAssoc, a => a == c);
        }
    }
}