using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Codering.Ai2;
using Codering.Flc;
using Codering.Vbn;

namespace CoderingSample
{
  using Source = Codering.Vbn.Product;
  using Entity = Article;

  public class ArticleImport
  {
    private readonly CoderingCache _cache;

    private Dictionary<string, IGrouping<string, RegularyFeatureType>> _regularyFeatures;
    private Dictionary<string, IGrouping<string, ProductFeature>> _productFeatures;
    private Dictionary<PlantRegistration, Gewas> _gewassen;
    private Dictionary<string, Genus> _genera;
    private Dictionary<string, Species> _specieses;
    private Dictionary<string, Cultivar> _cultivars;
    private Dictionary<string, ProductGroup> _productGroups;

    public ArticleImport(CoderingCache cache)
    {
      _cache = cache;
      _regularyFeatures = cache.VbnRegularyFeatureTypes.GroupBy(e => e.product_id).ToDictionary(e => e.Key);
      _productFeatures = cache.VbnProductFeatures.GroupBy(e => e.product_id).ToDictionary(e => e.Key);
      _gewassen = cache.VbnGewas.ToDictionary(e => PlantRegistration.FromStrings(e.plant_registration_number, e.registrator_id));
      _genera = cache.VbnGenus.ToDictionary(e => e.genus_id);
      _specieses = cache.VbnSpecies.ToDictionary(e => e.species_id);
      _cultivars = cache.VbnCultivars.ToDictionary(e => e.cultivar_id);
      _productGroups = cache.VbnProductGroups.ToDictionary(e => e.group_code);
    }

    public Source[] LoadSource()
    {
      return _cache.VbnProduct;
    }

    public Task<Entity> GetNew(Source rawEntity)
    {
      var result = new Entity()
      {
        Vbn = int.Parse(rawEntity.product_id),
        Name = rawEntity.VBN_product_name,
        TradeName = rawEntity.short_product_name,
        CreatedAt = rawEntity.EntryDate.ToDateTime(),
        ModifiedAt = rawEntity.ChangeDateTime.ToDateTime(),
      };
      
      var features = Enumerable
        .Repeat(RegulatoryFeature.Empty, RegulatoryFeatures.RegulatoryFeaturesCount)
        .ToArray();
      if (_regularyFeatures.TryGetValue(rawEntity.product_id, out var regFeature))
        foreach (var reg in regFeature)
          features[int.Parse(reg.presentation_order) - 1] = new RegulatoryFeature(reg.feature_type_id, GetFeaturePrescription(reg.regulation_type_id));
      result.RegulatoryData = RegulatoryFeatures.GenerateData(features);

      result.PlantRegistration = PlantRegistration.FromStrings(rawEntity.plant_registration_number, rawEntity.registrator_id);
      if (_gewassen.TryGetValue(result.PlantRegistration, out var gewas))
      {
        if (!string.IsNullOrWhiteSpace(gewas.genus_id) && _genera.TryGetValue(gewas.genus_id, out var genus))
          result.Genus = genus.latin_genus_name;
        if (!string.IsNullOrWhiteSpace(gewas.species_id) && _specieses.TryGetValue(gewas.species_id, out var specie))
          result.Species = specie.latin_species_name;
        if (!string.IsNullOrWhiteSpace(gewas.cultivar_id) && _cultivars.TryGetValue(gewas.cultivar_id, out var cultivar))
          result.Cultivar = cultivar.cultivar_name;
      }

      result.GroupCode = rawEntity.group_code;
      if (!string.IsNullOrWhiteSpace(rawEntity.group_code))
      {
        if (_productGroups.TryGetValue(rawEntity.group_code, out var productGroup4))
          result.GroupLevel4 = productGroup4.dutch_group_description;

        if (_productGroups.TryGetValue(rawEntity.group_code.Substring(0, 6) + "00", out var productGroup3))
          result.GroupLevel3 = productGroup3.dutch_group_description;

        if (_productGroups.TryGetValue(rawEntity.group_code.Substring(0, 3) + "00000", out var productGroup2))
          result.GroupLevel2 = productGroup2.dutch_group_description;

        if (_productGroups.TryGetValue(rawEntity.group_code.Substring(0, 1) + "0000000", out var productGroup1))
          result.GroupLevel1 = productGroup1.dutch_group_description;
      }

      if (_productFeatures.TryGetValue(rawEntity.product_id, out var productFeature))
        result.FeatureData = string.Join(";", productFeature.Select(e => $"{e.feature_type_id}:{e.feature_value}"));

      return Task.FromResult(result);

      FeaturePrescription GetFeaturePrescription(string id)
      {
        switch (id)
        {
          case "1":
            return FeaturePrescription.Required;

          case "2":
            return FeaturePrescription.Recommended;

          case "3":
            return FeaturePrescription.Allowed;

          default:
            return FeaturePrescription.Empty;
        }
      }

    }

  }

  public static class StringExtensions
  {

    public static DateTime ToDateTime(this string input, DateTime @default = default(DateTime))
    {
      if (string.IsNullOrWhiteSpace(input))
        return @default;

      switch (input.Length)
      {
        case 8: //yyyyMMdd
          return new DateTime(
            input.Substring(0, 4).ToInt(),
            input.Substring(4, 2).ToInt(),
            input.Substring(6, 2).ToInt());

        case 12: //yyyyMMddHHmm
          return new DateTime(
            input.Substring(0, 4).ToInt(),
            input.Substring(4, 2).ToInt(),
            input.Substring(6, 2).ToInt(),
            input.Substring(8, 2).ToInt(),
            input.Substring(10, 2).ToInt(),
            0);
      }

      return @default;
    }
    public static int ToInt(this string input, int @default = 0)
    {
      int result;
      return int.TryParse(input, out result) ? result : @default;
    }

  }

}
