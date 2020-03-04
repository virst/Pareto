using Pareto;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParetoDemo
{
    static class Utils
    {
        public static void PrintAltTable(ComparisonsTypes[] Comparisons, ParetoAlternative[] Alternatives)
        {
            Console.Write("  \t");
            if (Comparisons != null)
                foreach (var c in Comparisons)
                    Console.Write(ParetoEng.ComparisonsTypesToString(c) + "\t");
            Console.WriteLine();

            foreach (var al in Alternatives)
            {
                Console.Write(al.Id + "\t");
                foreach (var v in al.Values)
                    Console.Write(v + "\t");
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}
