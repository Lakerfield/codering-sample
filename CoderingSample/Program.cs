using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Codering.Parser;

namespace CoderingSample
{
  class Program
  {
    static async Task Main(string[] args)
    {
      Console.WriteLine("Sample of a vbn product import...");

      var url = "";
      var username = "";
      var password = "";

      var coderingen = new Coderingen(url, username, password);

      var cache = new CoderingCache(coderingen);
      await cache.CacheAll();

      var articleImport = new ArticleImport(cache);

      var rawEntities = articleImport.LoadSource();

      Console.WriteLine($"Start import of {rawEntities.Length} articles");
      foreach (var rawEntity in rawEntities.Take(10))
      {
        var article = await articleImport.GetNew(rawEntity);

        Console.WriteLine(JsonSerializer.Serialize(article, new JsonSerializerOptions(){ WriteIndented = true}));
        Console.WriteLine();
      }

      Console.WriteLine("Done");
    }

  }
}
