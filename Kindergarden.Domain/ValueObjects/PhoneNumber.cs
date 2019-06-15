using Kindergarden.Domain.Exceptions;
using Kindergarden.Domain.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Kindergarden.Domain.ValueObjects
{
    public class PhoneNumber : ValueObject
    {
        public string Number { get; private set; }

        private PhoneNumber() { }

        public static PhoneNumber For(string value)
        {
            try
            {
                var phoneNumber = new PhoneNumber();

                if (Regex.Matches(value, @"[a-zA-Z]").Count > 0) throw new Exception("Phone number contains letters.");
                phoneNumber.Number = value.Trim();

                return phoneNumber;

            } catch (Exception ex)
            {
                throw new PhoneNumberInvalidException(value, ex);
            }
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Number;
        }
    }
}
