using System;
using ClassLibrary;
using ClassLibrary.Interfaces;
using ClassLibrary.Enums;
using Xunit;

namespace RandomNumberGame.Tests
{
    public class TestValidate
    {

        [Theory]
        [InlineData(Status.CORRECT,"1234", 1234)]
        [InlineData(Status.TOO_LOW, "12", 1234)]
        [InlineData(Status.TOO_HIGH, "5879", 10)]

        public void ExecuteValidation_ReturnsCorrectStatus_WithInlineData(Status ExpectedStatus, string userCode, int code)
        {
            IValidate validate = new Validate();

            var status = validate.ExecuteValidation(userCode, code);

            Assert.Equal(ExpectedStatus, status);
        }
    }
}
