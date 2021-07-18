using System;
using ClassLibrary;
using ClassLibrary.Enums;
using ClassLibrary.Interfaces;
using Xunit;
namespace RandomNumberGame.Tests
{
    public class TestHints
    {
        [Theory]
        [InlineData(3, 10)]
        [InlineData(1, 7)]
        [InlineData(1, 23)]


        public void checkDivisibilityRange_returnsCorrectRangeLength_usingInlineData(int ExpectedRange, int code)
        {
            IHints hints = new Hints();

            var range = hints.checkDivisibitlyRange(code);

            Assert.Equal(ExpectedRange, range);
        }

        [Theory]
        [InlineData(Response.NOT_PRIME, 10)]
        [InlineData(Response.PRIME, 1)]

        public void IsPrime_returnsCorrectResponse_UsingInlineData(Response ExpectedResponse, int range)
        {
            IHints hints = new Hints();

            var response = hints.IsPrime(range);

            Assert.Equal(ExpectedResponse, response);
        }

        [Theory]
        [InlineData(Response.EVEN, 88)]
        [InlineData(Response.ODD, 159)]
        [InlineData(Response.EVEN, 70)]


        public void checkParity_(Response ExpectedResponse, int code) 
        {
            IHints hints = new Hints();

            var response = hints.checkParity(code);

            Assert.Equal(ExpectedResponse, response);
        }
    }
}
