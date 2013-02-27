using System;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Enum | AttributeTargets.Method | AttributeTargets.Interface | AttributeTargets.Struct)]

class VersionAttribute : Attribute
{
    private int major;
    private int minor;
    public VersionAttribute(int major, int minor)
    {
        this.major = major;
        this.minor = minor;
    }

    public int Major
    {
        get
        {
            return this.major;
        }
    }

    public int Minor
    {
        get
        {
            return this.minor;
        }
    }
}
