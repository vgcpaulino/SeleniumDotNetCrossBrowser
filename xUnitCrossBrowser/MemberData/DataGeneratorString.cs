using System.Collections.Generic;

namespace xUnitCrossBrowser.MemberData
{
    public class DataGeneratorString
    {
        public static IEnumerable<object[]> GetDriversFromAnotherClass()
        {
            yield return new object[] { "Chrome", "81" };
            yield return new object[] { "Chrome", "75" };
            yield return new object[] { "Firefox", "75" };
        }
    }
}