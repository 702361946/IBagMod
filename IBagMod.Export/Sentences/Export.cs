using Newtonsoft.Json.Linq;

namespace IBagMod.Export.Sentences;

public static class Export
{
    public static JObject Main(SentencePack sentencePack)
    {
        return new Module(sentencePack).OutputJson();
    }
}