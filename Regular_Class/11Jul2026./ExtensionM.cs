using System;

static class ExtensionM
{
    public static string ProperCase(this string name)
    {
        return char.ToUpper(name[0]) +
        name.Substring(1).ToLower();
    }
}