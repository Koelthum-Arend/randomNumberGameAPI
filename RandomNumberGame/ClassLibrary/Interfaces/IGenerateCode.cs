using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Interfaces
{
    public interface IGenerateCode
    {
        int code { get; set; }
        int CreateCode(int Min, int Max);
    }
}
