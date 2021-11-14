using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoderingSample
{
  using Source = Codering.Vbn.FeatureType;
  using Entity = VbnFeature;

  public class VbnFeatureImport
  {
    private readonly CoderingCache _cache;
    private Dictionary<string, IGrouping<string, Codering.Vbn.FeatureValue>> _values;

    public VbnFeatureImport(CoderingCache cache)
    {
      _cache = cache;
      _values = cache.VbnFeatureValues.GroupBy(e => e.feature_type_id).ToDictionary(e => e.Key);
    }

    public Source[] LoadSource()
    {
      return _cache.VbnFeatureTypes;
    }

    public Task<Entity> GetNew(Source rawEntity)
    {
      var result = new Entity()
      {
        Code = rawEntity.feature_type_id,
        Description = rawEntity.dutch_feature_type_description,
      };
      
      if (_values.TryGetValue(rawEntity.feature_type_id, out var items))
        foreach (var item in items)
          result.Values.Add(new Entity.VbnFeatureValue()
          {
            Value = item.feature_value,
            Description = item.dutch_feature_value_description,
          });

      return Task.FromResult(result);
    }

  }

  
}
