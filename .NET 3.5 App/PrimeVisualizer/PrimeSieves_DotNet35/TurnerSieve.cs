using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace PrimeSieves_DotNet35
{
    internal class TurnerSieve : ISieve
    {
        protected ICollection<ulong> _knownPrimes = new List<ulong>();
        
        public Prime NextPrime()
        {
            if (_knownPrimes.Count == 0)
            {
                _knownPrimes.Add(2);
            }
            else
            {
                ulong primeToVerify = 0;
                for (primeToVerify = _knownPrimes.Last<ulong>() + 1L;       // Increment the last known prime
                     !_knownPrimes.All<ulong>(p => primeToVerify % p != 0); // Ensure candidate is NOT divisible by all previous primes 
                     ++primeToVerify                                        // Increment candidate if it is divisible
                     );

                _knownPrimes.Add(primeToVerify);
            }

            return new Prime(_knownPrimes.Last<ulong>());
        }

        public void Reset()
        {
            _knownPrimes.Clear();
        }
    }
}
