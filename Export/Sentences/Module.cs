using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace Export.Sentences;

public class Module(SentencePack sentencePack)
{
    private readonly List<KeyValuePair<object, object>> _sentenceKeyValue = HashTableToListKeyValuePair(sentencePack.sentences);

    public JObject OutputJson()
    {
        var rj = new JObject();

        foreach (var kvp in _sentenceKeyValue)
        {
            rj[kvp.Key] = kvp.Value.ToString();
        }

        return rj;
    }

    private static List<KeyValuePair<object, object>> HashTableToListKeyValuePair(Hashtable hashtable)
    {
        List<KeyValuePair<object, object>> rl =
        [
            .. from DictionaryEntry dictionaryEntry in hashtable
            select new KeyValuePair<object, object>(dictionaryEntry.Key, dictionaryEntry.Value)
        ];

        return rl;
    }
}