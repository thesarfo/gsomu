using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Somu.Backend.Extensions;

public static class SerializationExtensions
{
    public static string Serialize<T>(this T @object, JsonSerializerSettings? settings = null)
        where T : notnull
    {
        settings ??= new JsonSerializerSettings
        {
            NullValueHandling = NullValueHandling.Ignore,
            Formatting = Formatting.Indented,
            ContractResolver = new CamelCasePropertyNamesContractResolver()
        };
        return JsonConvert.SerializeObject(@object, settings);
    }


    public static T? Deserialize<T>(this string json, JsonSerializerSettings? settings = null)
    {
        if (string.IsNullOrEmpty(json))
            return default;

        return JsonConvert.DeserializeObject<T>(json, settings);
    }

    // Uncomment the following methods if you need to work with RedisValue directly.
    // public static T? Deserialize<T>(this RedisValue json, JsonSerializerSettings? settings = null)
    // {
    //     if (json.IsNull || !json.HasValue)
    //         return default;
    //
    //     return JsonConvert.DeserializeObject<T>(json!, settings);
    // }

    // public static IEnumerable<T> Deserialize<T>(this RedisValue[] jsonArray, JsonSerializerSettings? settings = null)
    // {
    //     if (jsonArray is null || !jsonArray.Any())
    //         return Enumerable.Empty<T>();
    //
    //     var result = new List<T>(jsonArray.Length);
    //     foreach (var jsonItem in jsonArray)
    //     {
    //         if (jsonItem.IsNull || !jsonItem.HasValue)
    //             continue;
    //
    //         var item = Deserialize<T>(jsonItem, settings);
    //
    //         if (item is not null)
    //             result.Add(item);
    //     }
    //
    //     return result;
    // }
}
