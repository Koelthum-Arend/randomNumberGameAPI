using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary.Enums;

namespace ClassLibrary.Interfaces
{
    public interface IValidate
    {
        Status ExecuteValidation(string userGuessCode, int randomCode);
    }
}
