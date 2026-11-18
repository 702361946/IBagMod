using Newtonsoft.Json.Linq;

namespace Export.Sentences;

public static class Export
{
    public static JObject Main(SentencePack sentencePack)
    {
        return new Module(sentencePack).OutputJson();
    }
}