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
            if (Comparisons != null)
                foreach (var c in Comparisons)
                    Console.Write(ParetoEng.ComparisonsTypesToString(c) + "\t");
            Console.WriteLine();

            foreach (var al in Alternatives)
            {
                foreach (var v in al.Values)
                    Console.Write(v + "\t");
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}
