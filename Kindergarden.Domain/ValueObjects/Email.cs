using Kindergarden.Domain.Exceptions;
using Kindergarden.Domain.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kindergarden.Domain.ValueObjects
{
    public class Email : ValueObject
    {
        public string Address { get; private set; }

        private Email() { }

        public static Email For(string value)
        {
            try
            {
                var email = new Email();

                if (!value.Contains('@')) throw new Exception("Email does not contains @ sign.");

                email.Address = value.Trim();

                return email;

            }
            catch (Exception ex)
            {
                throw new EmailInvalidException(value, ex);
            }
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Address;
        }

        public override string ToString()
        {
            return this.Address.ToString();
        }
    }
}
