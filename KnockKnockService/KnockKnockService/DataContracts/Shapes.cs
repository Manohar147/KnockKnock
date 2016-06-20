using System.Runtime.Serialization;

namespace knockknock.readify.net
{
    /// <summary>
    /// This class holds the various shapes
    /// </summary>
    public class Shapes
    {
        /// <summary>
        /// Traiangle Type Enum exposed by the WCF Service as a DataContract to consumers
        /// </summary>
        [DataContract(Namespace = "http://KnockKnock.readify.net")]
        public enum TriangleType
        {
            [EnumMember] Error = 0,
            [EnumMember] Equilateral = 1,
            [EnumMember] Isosceles = 2,
            [EnumMember] Scalene = 3
        }
    }
}