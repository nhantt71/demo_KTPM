using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class Polynomial
    {
        private int n;
        private List<int> a;

        public Polynomial(int n, List<int> a) 
        {
            if (a.Count() != n + 1)
                throw new ArgumentException("Invalid Data");

            this.n = n;
            this.a = a;
        }

        public int getN{ get { return n; } }

        public List<int> getA { get { return a; } }



        public int Cal(double x)
        {
            if (double.IsNaN(x)) { return 0; } // nếu x = NaN thì trả về 0

            if (double.IsInfinity(x)) { return 1; } // nếu x = Infinity thì trả về 1

            int result = 0;
            for(int i = 0; i <= this.n; i++) 
            { 
                result += (int)(a[i] * Math.Pow(x, i));
            }
            
            return result;
        }
    }
}
