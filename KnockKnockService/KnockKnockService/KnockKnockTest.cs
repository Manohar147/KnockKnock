using System;
using NUnit.Framework;

namespace knockknock.readify.net
{
    /// <summary>
    /// This is a Test class to test the operations in wcf service
    /// </summary>
    [TestFixture]
    public class KnockKnockTest
    {
        private IRedPill _redPill;

        [SetUp]
        public void SetUp()
        {
            _redPill = new RedPill();
        }

        [Test]
        [TestCase(0, 0)]
        [TestCase(-1, 1)]
        [TestCase(-2, -1)]
        [TestCase(-13, 233)]
        [TestCase(-14, -377)]
        [TestCase(14, 377)]
        [TestCase(23, 28657)]
        [TestCase(92, 7540113804746346429)]
        [TestCase(-92, -7540113804746346429)]
        public void FibonacciNumberTest(long fibonacciNumberPosition, long expectedfibonacciNumber)
        {
            var fibonacciNumber = _redPill.FibonacciNumber(fibonacciNumberPosition);
            Assert.That(fibonacciNumber.Equals(expectedfibonacciNumber));
        }

        [Test]
        [TestCase("Manohar is the King of Kings!", "rahonaM si eht gniK fo !sgniK")]
        [TestCase(" Manohar is. the King of Kings! ", " rahonaM .si eht gniK fo !sgniK ")]
        [TestCase(" Manohar is t.h.e King of Kings!  ", " rahonaM si e.h.t gniK fo !sgniK  ")]
        [TestCase(" Manohar   is the    King of Kings!   ", " rahonaM   si eht    gniK fo !sgniK   ")]
        [TestCase("","")]
        public void ReverseWordsTest(string sentenceToBeReveresed, string expectedReversedWords)
        {
            var reversedWords = _redPill.ReverseWords(sentenceToBeReveresed);
            Assert.That(reversedWords.Equals(expectedReversedWords));
        }

        [Test]
        public void WhatIsYourTokenTest()
        {
            var myToken = _redPill.WhatIsYourToken();
            Assert.That(myToken.Equals(new Guid("140c281d-786d-45f4-9a08-a827e3db93ce")));
        }

        [Test]
        [TestCase(14,14,14,Shapes.TriangleType.Equilateral)]
        [TestCase(14, 7, 8, Shapes.TriangleType.Scalene)]
        [TestCase(14, 8, 8, Shapes.TriangleType.Isosceles)]
        [TestCase(14, 114, 1114, Shapes.TriangleType.Error)]
        public void WhatShapeIsThisTest(int a, int b, int c, Shapes.TriangleType expectedtriangleType)
        {
            var triangleType = _redPill.WhatShapeIsThis(a,b,c);
            Assert.That(triangleType.Equals(expectedtriangleType));
        }
    }
}