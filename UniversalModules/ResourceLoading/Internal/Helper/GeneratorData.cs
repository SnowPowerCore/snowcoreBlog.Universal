using System.Collections.Generic;
using System.Linq;

namespace snowcoreBlog.ResourceLoading.Implementations.Internal.Helper;

internal class GeneratorData  
{
    public IReadOnlyList<CultureData> CultureData { get; set; }
    public TranslationData InvariantTranslationData =>
        CultureData.Single(cd => cd.Key == Helper.CultureData.InvariantKeyName).Translations;
    
    public string Namespace { get; set; }
    public string GeneratedFileName { get; set; }
    public string GeneratedClassName { get; set; }
}