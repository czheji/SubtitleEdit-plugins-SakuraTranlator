using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace SubtitleEdit
{

    public class SakuraTranslator : ITranslator
    {
        public string Url {  get; set; }
        public string AppToken { get; set; }

        public string GetName()
        {
            return "sakura";
        }

        public string GetUrl()
        {
            return "https://github.com/SakuraLLM/Sakura-13B-Galgame";
        }

        public List<TranslationPair> GetTranslationPairs()
        {
            return new List<TranslationPair>
            {
                new TranslationPair { Code = "zh-CN", Name = "Chinese(simplified)", IsoCode = "zh-CN" },
                new TranslationPair { Code = "jp", Name = "Japanese", IsoCode = "jp" },
            };
        }

        public string Translate(string sourceLanguage, string targetLanguage, string text, StringBuilder log)
        {
            if (string.IsNullOrEmpty(text))
                return string.Empty;

            string url = Url.StartsWith("http://")?Url: "http://" + Url;
            url = url.EndsWith("/")? url+"completion": url + "/completion";
            var client = new HttpClient();
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");

            var request = new HttpRequestMessage(HttpMethod.Post, url) { Content = new JsonContent(MakeRequestJson(text)) };
            var res = client.SendAsync(request).Result;
            if (res.IsSuccessStatusCode)
            {
                string s = res.Content.ReadAsStringAsync().Result;
                log.AppendLine("Result from Sakura: " + s);
                s = ParseResponse(text, s);
                log.AppendLine();
                return s;
            }
            else
            {
                try
                {
                    log.AppendLine("Status code: " + res.StatusCode);
                    log.AppendLine("Error result from Sakura: " + res.Content.ReadAsStringAsync().Result);
                }
                catch (Exception ex)
                {
                    log.AppendLine(ex.Message + ": " + ex.StackTrace);
                }
            }
            log.AppendLine();
            return null;
        }

        private string ParseResponse(string line, string responseText)
        {
            // 手动解析JSON响应
            var startIndex = responseText.IndexOf("\"content\":") + 10;
            var endIndex = responseText.IndexOf(",", startIndex);
            var translatedLine = responseText.Substring(startIndex, endIndex - startIndex).Trim('\"', ' ', '\r', '\n');
            if (translatedLine.EndsWith("<|im_end|>"))
            {
                translatedLine = translatedLine.Substring(0, translatedLine.Length - "<|im_end|>".Length);
            }
            if (translatedLine.EndsWith("。") && !line.Trim().EndsWith("。"))
            {
                translatedLine = translatedLine.Substring(0, translatedLine.Length - "。".Length);
            }
            if (translatedLine.EndsWith("。」") && !line.Trim().EndsWith("。」"))
            {
                translatedLine = translatedLine.Substring(0, translatedLine.Length - "。」".Length) + "」";
            }
            return translatedLine;
        }

        private class JsonContent : HttpContent
        {
            private byte[] _data;
            public JsonContent(string json)
            {
                this._data = Encoding.UTF8.GetBytes(json);
            }
            protected override Task SerializeToStreamAsync(Stream stream, TransportContext context)
            {
                return stream.WriteAsync(_data,0,_data.Length);
            }

            protected override bool TryComputeLength(out long length)
            {
                length = _data.Length;
                return true;
            }
        }

        private string MakeRequestJson(string line)
        {
            string json;
                json = $"{{\"prompt\":\"<|im_start|>system\\n你是一个轻小说翻译模型，可以流畅通顺地以日本轻小说的风格将日文翻译成简体中文，" +
                $"并联系上下文正确使用人称代词，不擅自添加原文中没有的代词。<|im_end|>\\n<|im_start|>user\\n将下面的日文文本翻译成中文：" +
                $"{EscapeJsonString(line)}<|im_end|>\\n<|im_start|>assistant\\n\",\"n_predict\":1024,\"temperature\":0.1,\"top_p\":0.3,\"repeat_penalty\":1," +
                $"\"frequency_penalty\":0.2,\"top_k\":40,\"seed\":-1}}";

            return json;
        }

        private string SerializePromptMessages(List<PromptMessage> messages)
        {
            string result = "[";
            result += string.Join(",", messages.Select(x => $"{{\"role\":\"{x.Role}\"," +
                $"\"content\":\"{EscapeJsonString(x.Content)}\"}}").ToArray());
            result += "]";
            return result;
        }

        private string EscapeJsonString(string str)
        {
            return str
                .Replace("\\", "\\\\")
                .Replace("/", "\\/")
                .Replace("\b", "\\b")
                .Replace("\f", "\\f")
                .Replace("\n", "\\n")
                .Replace("\r", "\\r")
                .Replace("\t", "\\t")
                .Replace("\v", "\\v")
                .Replace("\"", "\\\"");
        }

        class PromptMessage
        {
            public string Role { get; set; }
            public string Content { get; set; }
        }

        private string Encode(string text)
        {
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(text));
        }

    }
}
