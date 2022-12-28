using ATEATECHNICAL.Utils.Extensions;
using NUnit.Framework;

namespace ATEATECHNICAL.Tests
{
    [TestFixture]
    public class ArgumentExtensionTests
    {
        [Test]
        [TestCase("1", "1", "2")]
        [TestCase("-1", "1", "0")]
        [TestCase("-200", "100", "-100")]
        public void AddArgument_AddIntegers_ResultIsCorrectIntSum(string arg1, string arg2, string expectedResult)
        {
            string actualResult = arg1.AddArgument(arg2);

            Assert.AreEqual(actualResult, expectedResult);
        }

        [Test]
        [TestCase("1.5", "1", "2.5")]
        [TestCase("2f", "1.7f", "3.7")]
        [TestCase("5.0", "1", "6")]
        public void AddArgument_AddFloats_ResultIsCorrectFloatSum(string arg1, string arg2, string expectedResult)
        {
            string actualResult = arg1.AddArgument(arg2);

            Assert.AreEqual(actualResult, expectedResult);
        }

        [Test]
        [TestCase("1.5789", "1.0001", "2.579")]
        [TestCase("2f", "1.7m", "3.7")]
        [TestCase("5.005m", "-1", "4.005")]
        public void AddArgument_AddDecimals_ResultIsCorrectDecimalSum(string arg1, string arg2, string expectedResult)
        {
            string actualResult = arg1.AddArgument(arg2);

            Assert.AreEqual(actualResult, expectedResult);
        }

        [Test]
        [TestCase("first", "second", "firstsecond")]
        [TestCase("string", "1", "string1")]
        [TestCase("20f", "string", "20fstring")]
        public void AddArgument_AddStringOrStringAndNumber_ResultIsCorrectConcatString(string arg1, string arg2, string expectedResult)
        {
            string actualResult = arg1.AddArgument(arg2);

            Assert.AreEqual(actualResult, expectedResult);
        }


    }
}
