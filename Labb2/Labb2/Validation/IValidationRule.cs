using System;

namespace Labb2.Validation
{
    public interface IValidationRule<T>  
    {  
        string ValidationMessage { get; set; }  
        bool Check(T value);  
    }
}
