using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp7
{
    interface Number
    {
        
    }

    class Rational
    {
        int n;
        uint m;

        public void Set(int nominator, uint denominator = 1)
        {
            n = nominator;
            m = denominator;
        }
        public void Set(string number)
        {
            m = 1;
            for(int i = 0, startDenominator = 0; i < number.Length;i++)
            {
                if((number[i] == '.')||(number[i] == ','))
                {
                    startDenominator = 1;
                }
                else
                {
                    n = n * 10 + Int32.Parse(number[i].ToString());
                    if (startDenominator == 1)
                    {
                        m = m * 10;
                    }
                }
            }
        }
        public void Set(double number)
        {
            Set(number.ToString());
        }

        public override string ToString()
        {
            return String.Format("{0}/{1}", n, m);
        }

        public static Rational operator + (Rational a, Rational b)
        {
            Normalize(ref a, ref b);
            Rational result = new Rational();
            result.n = a.n + b.n;
            result.m = a.m;
            result.Normalize();
            return result;
        }
        public static Rational operator * (Rational a, Rational b)
        {
            Rational result = new Rational();
            result.n = a.n * b.n;
            result.m = a.m * b.m;
            result.Normalize();
            return result;
        }
        public static bool operator == (Rational a, Rational b)
        {
            Normalize(ref a, ref b);
            if (a.n == b.n)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool operator != (Rational a, Rational b)
        {
            Normalize(ref a, ref b);
            if (a.n != b.n)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool operator > (Rational a, Rational b)
        {
            Normalize(ref a, ref b);
            if (a.n > b.n)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool operator < (Rational a, Rational b)
        {
            Normalize(ref a, ref b);
            if (a.n < b.n)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        static Stack<int> Multipliers(long a)
        {
            Stack<int> multipliers = new Stack<int>();
            for (int i = 2; i <= a; )
            {
                if (a % i == 0)
                {
                    multipliers.Push(i);
                    a /= i;
                }
                else
                {
                    i++;
                }
            }
            return multipliers;
        }

        void Normalize()
        {
            for (int i = 2; i <= m; )
            {
                if ((n % i == 0) && (m % i == 0))
                {
                    n /= i;
                    m /= (uint) i;
                }
                else
                {
                    i++;
                }
            }
        }
        static void Normalize(ref Rational a, ref Rational b)
        {
            int[] multA = Multipliers(a.m).ToArray();
            int[] multB = Multipliers(b.m).ToArray();
            for (int i = 0; i < multA.Length; i++)
            {
                for (int j = 0; j < multB.Length; j++)
                {
                    if (multA[i] == multB[j])
                    {
                        multA[i] = 1;
                        multB[j] = 1;
                    }
                }
            }
            for (uint i = 0; i < multA.Length; i++)
            {
                a.n *= multA[i];
                a.m *= (uint)multA[i];
            }
            for (uint i = 0; i < multB.Length; i++)
            {
                b.n *= multB[i];
                b.m *= (uint)multB[i];
            }
        }
    }
}
