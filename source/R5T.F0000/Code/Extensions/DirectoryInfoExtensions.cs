using System;
using System.IO;

using Instances = R5T.F0000.Instances;


public static class DirectoryInfoExtensions
{
    /// <inheritdoc cref="R5T.F0000.IDirectoryInfoOperator.GetDirectoryPath(DirectoryInfo)"/>
    public static string GetDirectoryPath(this DirectoryInfo directoryInfo)
    {
        var directoryPath = Instances.DirectoryInfoOperator.GetDirectoryPath(directoryInfo);
        return directoryPath;
    }

    public static DirectoryInfo GetParentDirectoryInfo(this DirectoryInfo directoryInfo)
    {
        var parentDirectoryInfo = Instances.DirectoryInfoOperator.GetParentDirectoryInfo(directoryInfo);
        return parentDirectoryInfo;
    }

    public static string GetParentDirectoryPath(this DirectoryInfo directoryInfo)
    {
        var parentDirectoryPath = Instances.DirectoryInfoOperator.GetParentDirectoryPath(directoryInfo);
        return parentDirectoryPath;
    }

    public static bool IsRoot(this DirectoryInfo directoryInfo)
    {
        var output = Instances.DirectoryInfoOperator.IsRootDirectory(directoryInfo);
        return output;
    }
}

