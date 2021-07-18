using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary.Enums;

namespace ClassLibrary.Interfaces
{
    public interface IHints
    {
        Response IsPrime(int counter);
        int checkDivisibitlyRange(int code);
        Response checkParity(int code);
    }
}
