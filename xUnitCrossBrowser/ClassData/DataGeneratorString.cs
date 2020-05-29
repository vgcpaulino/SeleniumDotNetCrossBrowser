using System.Collections;
using System.Collections.Generic;

namespace xUnitCrossBrowser.ClassData
{
    public class DataGeneratorString : IEnumerable<object[]>
    {
        private readonly List<object[]> browserList;

        public DataGeneratorString()
        {
            browserList = new List<object[]>() { };
            browserList.Add(new object[] { "Chrome", "81" });
            browserList.Add(new object[] { "Chrome", "75" });
            browserList.Add(new object[] { "Firefox", "75" });
        }

        public IEnumerator<object[]> GetEnumerator() => browserList.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}