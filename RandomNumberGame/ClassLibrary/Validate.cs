using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary.Interfaces;
using ClassLibrary.Enums;

namespace ClassLibrary
{
    public class Validate : IValidate
    {
        public Status ExecuteValidation(string userGuessCode, int randomCode)
        {
            int userCodeInt = Convert.ToInt32(userGuessCode);

            if (userCodeInt == randomCode)
            {
                return Status.CORRECT;
            }
            else if (userCodeInt > randomCode)
            {
                return Status.TOO_HIGH;
            }
            else if (userCodeInt < randomCode)
            {
                return Status.TOO_LOW;
            }
            return Status.READY;
        }
     }
 }
