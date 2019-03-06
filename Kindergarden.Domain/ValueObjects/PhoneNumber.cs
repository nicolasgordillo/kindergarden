using Kindergarden.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Kindergarden.Domain.ValueObjects
{
    public class PhoneNumber
    {
        private PhoneNumber() { }

        public PhoneNumber(string value)
        {
            try
            {
                value = value.Trim();

                if (Regex.Matches(value, @"[a-zA-Z]").Count > 0) throw new Exception("Phone number contains letters.");

            } catch (Exception ex)
            {
                throw new PhoneNumberInvalidException(value, ex);
            }
        }
    }
}
