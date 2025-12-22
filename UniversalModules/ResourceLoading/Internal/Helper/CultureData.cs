using System.IO;
using System.Collections.Generic;
using Microsoft.CodeAnalysis;
using snowcoreBlog.ResourceLoading.Implementations.Interfaces;

namespace snowcoreBlog.ResourceLoading.Implementations.Internal.Helper;

internal class CultureData
{
    public const string InvariantKeyName = "invariant";
    
    public string Key { get; private set; }
    public string NormalizedKey { get; private set; }
    public TranslationData Translations { get; private set; }

    private CultureData() { }

    public static IReadOnlyList<CultureData> Initialize(string neutralCulture, IReadOnlyList<AdditionalText> additionalTexts, ITranslationReader translationReader) =>
        additionalTexts.Select(at => ResolveCulture(neutralCulture, at, translationReader)).ToList();


    private static CultureData ResolveCulture(string neutralCulture, AdditionalText additionalText, ITranslationReader translationReader)
    {
        var cultureId = TryGetCultureIdFromPath(additionalText.Path);

        if (cultureId == neutralCulture)
            cultureId = InvariantKeyName;
        
        return new()
        {
            Key = cultureId, 
            NormalizedKey = NormalizeCultureIdentifier(cultureId), 
            Translations = translationReader.Read(additionalText)
        };
    }

    private static string NormalizeCultureIdentifier(string cultureId) =>
        cultureId.ToLower().Replace('-', '_');

    private static string? TryGetCultureIdFromPath(string path)
    {
        var fileName = Path.GetFileNameWithoutExtension(path);
        if (string.IsNullOrEmpty(fileName))
            return null;

        ReadOnlySpan<char> span = fileName.AsSpan();
        var firstUnderscore = span.IndexOf('_');
        if (firstUnderscore < 0)
            return null;

        var lastUnderscore = span.LastIndexOf('_');
        var culture = span.Slice(lastUnderscore + 1);
        if (culture.Length == 0)
            return null;

        return culture.ToString();
    }
}