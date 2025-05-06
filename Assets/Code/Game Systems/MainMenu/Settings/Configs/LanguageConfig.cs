using System.Collections.Generic;
using System.Linq;

public static class LanguageConfig
{
    public static readonly Dictionary<Language, string> Languages = new()
    {
        { Language.English, "English"},
        { Language.Russian, "Русский"}
    };

    public static List<Language> OrderedLanguages => Languages.Keys.ToList();
    public static List<string> DisplayNames => Languages.Values.ToList();
}

public enum Language
{
    Russian,
    English
}