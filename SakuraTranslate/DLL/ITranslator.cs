﻿using System.Collections.Generic;
using System.Text;

namespace SubtitleEdit
{
    interface ITranslator
    {
        List<TranslationPair> GetTranslationPairs();
        string GetName();
        string GetUrl();
        string Translate(string sourceLanguage, string targetLanguage, string text, StringBuilder log);

        string Url { get; set; }
        string AppToken { get; set; }

    }
}
