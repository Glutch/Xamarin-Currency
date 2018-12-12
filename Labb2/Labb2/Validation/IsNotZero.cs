using System;
using System.Collections.Generic;
using System.Text;

namespace Labb2.Validation
{
    public class IsNotZero<T> : IValidationRule<T>  
    {  
        public string ValidationMessage { get; set; }  

        public bool Check(T value)  
        {
            float.TryParse(value.ToString(), out var parsed);

            return parsed != 0;
        }
    }
}
