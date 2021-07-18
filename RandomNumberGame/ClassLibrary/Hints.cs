using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary.Enums;
using ClassLibrary.Interfaces;

namespace ClassLibrary
{
    public class Hints : IHints
    {
        //used for checking primality of number
        public int checkDivisibitlyRange(int code)
        {
            int count = 0;
            for (int i = 2; i <= code; i++)
            {
                if (code % i == 0)
                {
                    count += 1;
                }
            }
            return count;
        }

        // checks if generated code is even or odd
        public Response checkParity(int code)
        {
            if (code % 2 == 0)
            {
                return Response.EVEN;
            }
            else
            {
                return Response.ODD;
            }
        }

        public Response IsPrime(int counter)
        {
            if (counter >= 2)
            {
                return Response.NOT_PRIME;
            }

            else
            {
                return Response.PRIME;
            }
        }
    }
}
