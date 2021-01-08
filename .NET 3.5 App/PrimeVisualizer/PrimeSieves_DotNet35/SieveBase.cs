using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PrimeSieves_DotNet35
{
    public interface ISieve
    {
        Prime NextPrime();
        void Reset();
    }

    public class Prime
    {
        internal Prime(ulong p)
        {
            Value = p;
        }

        protected ulong Value
        {
            get;
            set;
        }

        public override string ToString()
        {
            return String.Format("{0}", Value);
        }

        public static implicit operator ulong(Prime p)
        {
            return p.Value;
        }
    }

    public enum SieveType
    {
        Turner
    };

    public class SieveFactory
    {
        public static ISieve GetSieve(SieveType sieve = SieveType.Turner)
        {
            switch (sieve)
            {
                case SieveType.Turner: // Default
                default:
                    return new TurnerSieve();
            }
        }
    }
}
