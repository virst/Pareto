using System;
using System.Collections.Generic;
using System.Text;

namespace Pareto
{
    public class ParetoAlternative : IComparable, IComparable<ParetoAlternative>
    {
        private ParetoEng Parent { get; }
        public double[] Values { get; }

        internal ParetoAlternative(ParetoEng p)
        {
            Parent = p;
            Values = new double[p.CountParametrs];
        }

        public int CompareTo(object obj)
        {
            return CompareTo(obj as ParetoAlternative);
        }

        public int CompareTo(ParetoAlternative other)
        {
            if (other == null)
                throw new NullReferenceException();
            if (other.Parent != Parent)
                throw new ArgumentException("Not equal parents");
            int df=0;
            for (int i = 0; i < Parent.CountParametrs; i++)
                df += Values[i].CompareTo(other.Values[i]) * (Parent.Comparisons[i]==ComparisonsTypes.Less?-1:1);
            if (Math.Abs(df) != Parent.CountParametrs)
                return 0;
            return Math.Sign(df);
        }
    }
}
