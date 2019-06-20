using Kindergarden.Domain.Exceptions;
using Kindergarden.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Kindergarden.Domain.Tests.ValueObjects
{
    public class EmailTests
    {
        [Fact]
        public void ToStringReturnsCorrectFormat()
        {
            const string value = "email@domain.com";

            var email = Email.For(value);

            Assert.Equal(value, email.ToString());
        }

        [Fact]
        public void ShouldThrowEmailInvalidExceptionForInvalidEmail()
        {
            Assert.Throws<EmailInvalidException>(() => Email.For("email"));
        }
    }
}
