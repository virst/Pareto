using System;
using Pareto;
using static ParetoDemo.Utils;

namespace ParetoDemo
{
    class Program
    {
        const int CountParametrs = 3;
        const int Alternatives = 7;
        static Random rnd = new Random(1);

        static void Main(string[] args)
        {
            ParetoEng p = new ParetoEng(CountParametrs);
            p.Comparisons[0] = ComparisonsTypes.More;
            p.Comparisons[1] = ComparisonsTypes.Less;
            p.Comparisons[2] = ComparisonsTypes.More;

            for(int i=0;i< Alternatives;i++)
            {
                var alt = p.AddAlternative();
                for (int j = 0; j < alt.Values.Length;j++)
                {
                    alt.Values[j] = rnd.Next(999);
                }
            }
            Console.WriteLine("All Alrernatives");
            PrintAltTable(p.Comparisons, p.AlternativesArray);
            Console.WriteLine("Best Alrernatives");
            PrintAltTable(p.Comparisons, p.GetBestAlternatives());
            Console.WriteLine("done!");
        }       

    }
}
