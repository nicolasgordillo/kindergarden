using Kindergarden.Domain.Entities;
using Kindergarden.Domain.Exceptions;
using Kindergarden.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Kindergarden.Domain.Tests.ValueObjects
{
    public class IndividualTests
    {
        [Fact]
        public void ShouldReturnNotAuthorizedToSendMessages()
        {
            var individual = new Individual()
            {
                Id = 1,
                FirstName = "Test FirstName",
                LastName = "Test LastName"
            };

            Assert.False(individual.CanSendMessage());
        }
    }
}
