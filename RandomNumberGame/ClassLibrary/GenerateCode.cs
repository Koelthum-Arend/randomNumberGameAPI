using System;
using ClassLibrary.Interfaces;

namespace ClassLibrary
{
    public class GenerateCode : IGenerateCode
    {
        public int code { get;  set; }

        public int CreateCode(int Min, int Max)
        {
            Random random = new Random();
            code = random.Next(Min, Max);

            return code;
        }
    }
}
