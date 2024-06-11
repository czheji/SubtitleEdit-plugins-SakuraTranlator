using System.Collections.Generic;
using System.Text;

namespace SubtitleEdit
{
    interface ITranslator
    {
        List<TranslationPair> GetTranslationPairs();
        string GetName();
        string GetUrl();
        string Translate(string sourceLanguage, string targetLanguage, string text, StringBuilder log);
        /// <summary>
        /// Sakura的地址，只需要ip:port
        /// </summary>
        string Url { get; set; }
        /// <summary>
        /// 提示词版本，目前支持 0.9和0.10
        /// </summary>
        string PromptVersion { get; set; }
        /// <summary>
        /// 字典，gpt格式，例如
        /// string[] {
        ///   "源1->目标1 #提示1",
        ///   "源2->目标2 #提示2"}
        /// </summary>
        string[] GptDist { get; set; }

    }
}
