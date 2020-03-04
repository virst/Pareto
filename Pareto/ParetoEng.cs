using System;
using System.Collections.Generic;
using System.Text;

namespace Pareto
{
    public class ParetoEng
    {
        public int CountParametrs { get; }
        public ComparisonsTypes[] Comparisons { get; }
        private List<ParetoAlternative> _alternatives;

        public ParetoAlternative[] AlternativesArray => _alternatives.ToArray();

        public ParetoEng(int CountParametrs)
        {
            this.CountParametrs = CountParametrs;
            Comparisons = new ComparisonsTypes[CountParametrs];
            _alternatives = new List<ParetoAlternative>();
        }

        public ParetoAlternative[] GetBestAlternatives()
        {
            var alt = new List<ParetoAlternative>(_alternatives);

            for (int i = 0; i < alt.Count - 1; i++)
                for (int j = i + 1; j < alt.Count; j++)
                {
                    int a = alt[i].CompareTo(alt[j]);
                    switch (a)
                    {
                        case -1:
#if DEBUG
                            Console.WriteLine("{0} removed by {1}", alt[i], alt[j]);
#endif
                            alt.RemoveAt(i);
                            i--;
                            break;
                        case 1:
#if DEBUG
                            Console.WriteLine("{0} removed by {1}", alt[j], alt[i]);
#endif
                            alt.RemoveAt(j);
                            break;
                    }
                    if (a != 0)
                        break;
                }

            return alt.ToArray();
        }

        public ParetoAlternative AddAlternative(string AlternativeId)
        {
            var a = new ParetoAlternative(this, AlternativeId);
            _alternatives.Add(a);
            return a;
        }

        public void RemoveAlternativeAt(int n)
        {
            _alternatives.RemoveAt(n);
        }

        public void RemoveAlternative(ParetoAlternative n)
        {
            _alternatives.Remove(n);
        }

        public void ClearAlternative()
        {
            _alternatives.Clear();
        }

        public static string ComparisonsTypesToString(ComparisonsTypes t)
        {
            switch (t)
            {
                case ComparisonsTypes.Less: return "v";
                case ComparisonsTypes.More: return "^";
            }
            return null;
        }
    }
}
