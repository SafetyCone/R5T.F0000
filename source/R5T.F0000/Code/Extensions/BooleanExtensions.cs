using System;

using Instances = R5T.F0000.Instances;



public static class BooleanExtensions
{
    public static string ToString_Lower(this bool value)
    {
        var representation = Instances.BooleanOperator.ToString_Lower(value);
        return representation;
    }

    public static string ToString_Upper(this bool value)
    {
        var representation = Instances.BooleanOperator.ToString_Upper(value);
        return representation;
    }

    /// <inheritdoc cref="R5T.F0000.IBooleanOperator.ToString_PascalCase(bool)"/>
    public static string ToString_PascalCase(this bool value)
    {
        var representation = Instances.BooleanOperator.ToString_PascalCase(value);
        return representation;
    }
}
