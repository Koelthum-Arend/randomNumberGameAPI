using System;
using ClassLibrary;
using ClassLibrary.Interfaces;
using Xunit;

namespace RandomNumberGame.Tests
{
    public class TestGenerateCode
    {

        [Theory]
        [InlineData(0,100)]
        [InlineData(5,50)]
        [InlineData(-100,10)]
        public void GeneratedCode_IsWithinRange_WithInlineData(int Min, int Max)
        {
            IGenerateCode generateCode = new GenerateCode();

            var code = generateCode.CreateCode(Min,Max);

            Assert.InRange(code, Min, Max);
        }
    }
}
