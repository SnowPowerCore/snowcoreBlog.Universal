using System;
using System.IO;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Diagnostics;

namespace snowcoreBlog.ResourceLoading.Implementations.Internal.Helper;

internal class NamesResolver
{
    private readonly AdditionalText originFile;
    private readonly string fallBackRootNamespace;
    private readonly AnalyzerConfigOptionsProvider optionsProvider;

    public NamesResolver(AdditionalText originFile, string fallBackRootNamespace, AnalyzerConfigOptionsProvider optionsProvider)
    {
        this.originFile = originFile;
        this.fallBackRootNamespace = fallBackRootNamespace;
        this.optionsProvider = optionsProvider;
    }

    public string ResolveGeneratedClassName()
    {
        if (optionsProvider.GetOptions(originFile).TryGetValue("build_metadata.AdditionalFiles.ClassName", out var className) && !string.IsNullOrWhiteSpace(className))
            return className;
        return Path.GetFileNameWithoutExtension(originFile.Path);
    }
    
    public string ResolveGeneratedFileName() => $"{ResolveGeneratedClassName()}.g.cs";

    public string ResolveNamespace()
    {
        if (optionsProvider.GetOptions(originFile).TryGetValue("build_metadata.AdditionalFiles.NamespaceName", out var namespaceName) && !string.IsNullOrWhiteSpace(namespaceName))
            return namespaceName;

        if (!optionsProvider.GlobalOptions.TryGetValue("build_property.rootnamespace", out var rootNamespace))
            rootNamespace = fallBackRootNamespace;

        if (optionsProvider.GlobalOptions.TryGetValue("build_property.projectdir", out var projectDir))
        {
            var fromPath = EnsurePathEndsWithDirectorySeparator(projectDir);
            var toPath = EnsurePathEndsWithDirectorySeparator(Path.GetDirectoryName(originFile.Path));
            var relativPath = GetRelativePath(fromPath, toPath);

            return $"{rootNamespace}.{relativPath.Replace(Path.DirectorySeparatorChar, '.')}".TrimEnd('.');
        }

        return rootNamespace;
    }

    private string GetRelativePath(string fromPath, string toPath)
    {
        var relativeUri = new Uri(fromPath).MakeRelativeUri(new(toPath));
        return Uri.UnescapeDataString(relativeUri.ToString())
            .Replace(Path.AltDirectorySeparatorChar, Path.DirectorySeparatorChar);
    }

    private string EnsurePathEndsWithDirectorySeparator(string path) =>
        path.TrimEnd(Path.DirectorySeparatorChar) + Path.DirectorySeparatorChar;
}