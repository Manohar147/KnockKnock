using System;
using System.Text;
using System.Linq;
using System.ServiceModel;

namespace knockknock.readify.net
{
    /// <summary>
    /// This class has the implementation for all operations in the WCF Service
    /// </summary>
    [ServiceBehavior(Namespace = "http://KnockKnock.readify.net")]
    public class RedPill : IRedPill
    {
        /// <summary>
        /// This method returns the  nth fibonacci Number 
        /// </summary>
        /// <param name="n">Fibonacci Number Position</param>
        /// <returns>FibonacciNumber</returns>
        public long FibonacciNumber(long n)
        {
            long previousNumber = 1;
            long currentNumber = 1;
            long result = 0;
            var absNumber = Math.Abs(n);
            if (absNumber != 0)
            {
                if (absNumber == 1 || absNumber == 2)
                {
                    return n == -2 ? -1 : 1;
                }
                if (absNumber > 92)
                {
                    throw n < -92
                        ? new FaultException("Fib(<92) will cause a 64-bit integer overflow.")
                        : new FaultException("Fib(>92) will cause a 64-bit integer overflow.");
                }
                for (var i = 2; i < absNumber; i++)
                {
                    result = previousNumber + currentNumber;
                    currentNumber = previousNumber;
                    previousNumber = result;
                }
                return (n < -9 && n%2 == 0) || ((n > -10 && n < 0) && n%2 == 0) ? result*-1 : result;
            }
            return 0;
        }

        /// <summary>
        /// This Method returns a Unique Token to identify the user
        /// </summary>
        /// <returns>Unique Token to Identify the user</returns>
        public Guid WhatIsYourToken()
        {
            return new Guid("140c281d-786d-45f4-9a08-a827e3db93ce");
        }

        /// <summary>
        /// This Method reverses the words in a sentence 
        /// </summary>
        /// <param name="input">Sentence to be reversed</param>
        /// <returns>Reversed Sentence</returns>
        public string ReverseWords(string input)
        {
            var words = input.Split(' ');
            var sb = new StringBuilder();
            foreach (var word in words)
            {
                if (!string.IsNullOrEmpty(word))
                {
                    sb.Append(word.ToCharArray().Reverse().ToArray());
                    sb.Append(" ");
                }
                else
                {
                    sb.Append(" ");
                }
            }

            return sb.ToString().Remove(sb.ToString().Length - 1);
        }

        /// <summary>
        /// This Method determines the type of triangle based on the side lengths
        /// </summary>
        /// <param name="a">Side Length 1</param>
        /// <param name="b">Side Length 2</param>
        /// <param name="c">Side Length3</param>
        /// <returns>Type of the triangle</returns>
        public Shapes.TriangleType WhatShapeIsThis(int a, int b, int c)
        {
            const Shapes.TriangleType shape = Shapes.TriangleType.Error;
            if (!(a > (b - c) && a < (b + c)) || !(b > (a - c) && b < (a + c)) || !(c > (a - b) && c < (a + b)))
                return shape;
            if (a == b && b == c)
            {
                return Shapes.TriangleType.Equilateral;
            }
            if (a != b && b != c && c != a)
            {
                return Shapes.TriangleType.Scalene;
            }
            if ((a == b) || (b == c) || (c == a))
            {
                return Shapes.TriangleType.Isosceles;
            }
            return shape;
        }
    }
}