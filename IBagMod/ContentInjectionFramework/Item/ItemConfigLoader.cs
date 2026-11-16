using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using UnityEngine;

namespace IBagMod.ContentInjectionFramework.Item;

public static class ItemConfigLoader
{
    private static readonly JsonSerializerSettings SerializerSettings = new()
    {
        ObjectCreationHandling = ObjectCreationHandling.Replace,
        MissingMemberHandling = MissingMemberHandling.Ignore,
        NullValueHandling = NullValueHandling.Ignore,
        Culture = CultureInfo.InvariantCulture,
        Converters = { new StringEnumConverter() }
    };

    public static List<ItemDefinition> Load(string filePath)
    {
        var root = JToken.Parse(File.ReadAllText(filePath));
        var itemTokens = GetItemTokens(root, filePath);
        var serializer = JsonSerializer.Create(SerializerSettings);
        var result = new List<ItemDefinition>();

        foreach (var itemToken in itemTokens)
        {
            try
            {
                var definition = itemToken.ToObject<ItemDefinition>(serializer);
                if (definition is not null)
                {
                    result.Add(definition);
                }
            }
            catch (Exception exception)
            {
                Debug.LogError(
                    $"[IBagMod] 解析物品配置条目失败：{filePath}\n{itemToken}\n{exception}"
                );
            }
        }

        return result;
    }

    private static IEnumerable<JToken> GetItemTokens(JToken root, string filePath)
    {
        if (root is not JObject itemObject)
        {
            throw new JsonException($"物品配置必须是 {{物品名: 物品}} 对象：{filePath}");
        }

        var namedItems = new List<JToken>();
        foreach (var property in itemObject.Properties())
        {
            if (property.Value is not JObject item)
            {
                throw new JsonException(
                    $"物品配置项 \"{property.Name}\" 必须是对象：{filePath}"
                );
            }

            ApplyItemName(item, property.Name);
            namedItems.Add(item);
        }

        if (namedItems.Count == 0)
        {
            throw new JsonException($"物品配置必须是 {{物品名: 物品}} 对象：{filePath}");
        }

        return namedItems;
    }

    private static void ApplyItemName(JObject itemObject, string itemName)
    {
        var nameToken = itemObject.GetValue("Name", StringComparison.OrdinalIgnoreCase);

        if (nameToken is null)
        {
            itemObject["Name"] = itemName;
            return;
        }

        if (string.IsNullOrWhiteSpace(nameToken.Value<string>()))
        {
            nameToken.Replace(new JValue(itemName));
        }
    }
}
