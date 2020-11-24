using System;

namespace Driver_AutoTests.Utils.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class RelativePagePathAttribute: Attribute

    {
        public string RelativePath { get; }

        public RelativePagePathAttribute(string relativePath)
        {
            RelativePath = relativePath;
        }
    }
}
