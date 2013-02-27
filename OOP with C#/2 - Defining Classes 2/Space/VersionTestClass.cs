using System;
using System.Text;

namespace Space
{
    [Version(1,123)]
    public class VersionTestClass
    {
        public string GetVersion()
        {
            StringBuilder version = new StringBuilder();
            object[] versionAttributes = typeof(VersionTestClass).GetCustomAttributes(false);
            foreach (VersionAttribute attr in versionAttributes)
            {
                version.Append(attr.Major+".");
                version.Append(attr.Minor);
            }
            return version.ToString();
        }
    }
}
