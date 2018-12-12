using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Labb2.Validation
{
    public class ValidatableObject<T> : ViewModels.BaseViewModel, IValidity
    {
        T _value;
        List<string> _errors;
        public List<IValidationRule<T>> _validations { get; }

        public T Value
        {
            get => _value;
            set => SetProperty(ref _value, value);
        }

        public List<string> Errors
        {
            get { return _errors; }
            set { SetProperty(ref _errors, value); }
        }

        public bool IsValid { get; set; }

        public ValidatableObject()
        {
            IsValid = true;
            _errors = new List<string>();
            _validations = new List<IValidationRule<T>>();
        }

        public bool Validate()
        {
            Errors.Clear();
            IEnumerable<string> errors = _validations
                .Where(v => !v.Check(Value))
                .Select(v => v.ValidationMessage);
            Errors = errors.ToList();
            IsValid = !Errors.Any();
            return IsValid;
        }
    }
}
