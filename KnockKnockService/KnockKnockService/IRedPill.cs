using System;
using System.ServiceModel;

namespace knockknock.readify.net
{
    [ServiceContract(Namespace = "http://KnockKnock.readify.net")]
    public interface IRedPill
    {
        [OperationContract]
        [FaultContract(typeof(ArgumentOutOfRangeException))]
        long FibonacciNumber(long n);

        [OperationContract]
        Guid WhatIsYourToken();


        [OperationContract]
        [FaultContract(typeof(ArgumentNullException))]
        string ReverseWords(string s);

        [OperationContract]
        Shapes.TriangleType WhatShapeIsThis(int a, int b, int c);

    }
}