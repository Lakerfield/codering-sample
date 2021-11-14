using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Codering.Parser;

namespace CoderingSample
{
  public class CoderingCache
  {
    private readonly Coderingen _coderingen;

    public Codering.Vbn.Product[] VbnProduct { get; set; }
    public Codering.Vbn.Application[] VbnApplications { get; set; }
    public Codering.Vbn.Gewas[] VbnGewas { get; set; }
    public Codering.Vbn.Genus[] VbnGenus { get; set; }
    public Codering.Vbn.Species[] VbnSpecies { get; set; }
    public Codering.Vbn.Cultivar[] VbnCultivars { get; set; }
    public Codering.Vbn.ProductFeature[] VbnProductFeatures { get; set; }
    public Codering.Vbn.FeatureType[] VbnFeatureTypes { get; set; }
    public Codering.Vbn.FeatureValue[] VbnFeatureValues { get; set; }
    public Codering.Vbn.FeatureGroup[] VbnFeatureGroups { get; set; }
    public Codering.Vbn.RegularyFeatureType[] VbnRegularyFeatureTypes { get; set; }
    public Codering.Vbn.PrescriptionType[] VbnPrescriptionTypes { get; set; }
    public Codering.Vbn.Translation[] VbnTranslations { get; set; }
    public Codering.Vbn.TranslationType[] VbnTranslationTypes { get; set; }
    public Codering.Vbn.Language[] VbnLanguages { get; set; }
    public Codering.Vbn.ProductGroup[] VbnProductGroups { get; set; }
    public Codering.Vbn.Fust[] VbnFust { get; set; }
    public Codering.Vbn.Fustsoort[] VbnFustsoort { get; set; }
    public Codering.Vbn.Fustmateriaal[] VbnFustmateriaal { get; set; }
    public Codering.Fec.Company[] FecCompanies { get; set; }
    public Codering.Fec.CompanyLevel[] FecCompanyLevels { get; set; }
    public Codering.Fec.CompanyRole[] FecCompanyRoles { get; set; }
    public Codering.Fec.Location[] FecLocations { get; set; }
    public Codering.Fec.LocationType[] FecLocationTypes { get; set; }
    public Codering.Fec.PriceDeliveryTerms[] FecPriceDeliveryTerms { get; set; }
    public Codering.Fec.PackagingMode[] FecPackagingModes { get; set; }
    public Codering.Fec.DataElement[] FecDataElements { get; set; }


    public CoderingCache(Coderingen coderingen)
    {
      _coderingen = coderingen;
    }

    public async Task CacheAll()
    {
      if (VbnProduct == null) VbnProduct = (await _coderingen.VbnProduct()).ToArray();
      Console.WriteLine($"VbnProduct {VbnProduct.Length}");

      if (VbnApplications == null) VbnApplications = (await _coderingen.VbnApplications()).ToArray();
      Console.WriteLine($"VbnApplications {VbnApplications.Length}");

      if (VbnGewas == null) VbnGewas = (await _coderingen.VbnGewas()).ToArray();
      Console.WriteLine($"VbnGewas {VbnGewas.Length}");

      if (VbnGenus == null) VbnGenus = (await _coderingen.VbnGenus()).ToArray();
      Console.WriteLine($"VbnGenus {VbnGenus.Length}");

      if (VbnSpecies == null) VbnSpecies = (await _coderingen.VbnSpecies()).ToArray();
      Console.WriteLine($"VbnSpecies {VbnSpecies.Length}");

      if (VbnCultivars == null) VbnCultivars = (await _coderingen.VbnCultivars()).ToArray();
      Console.WriteLine($"VbnCultivars {VbnCultivars.Length}");

      if (VbnProductFeatures == null) VbnProductFeatures = (await _coderingen.VbnProductFeatures()).ToArray();
      Console.WriteLine($"VbnProductFeatures {VbnProductFeatures.Length}");

      if (VbnFeatureTypes == null) VbnFeatureTypes = (await _coderingen.VbnFeatureTypes()).ToArray();
      Console.WriteLine($"VbnFeatureTypes {VbnFeatureTypes.Length}");

      if (VbnFeatureValues == null) VbnFeatureValues = (await _coderingen.VbnFeatureValues()).ToArray();
      Console.WriteLine($"VbnFeatureValues {VbnFeatureValues.Length}");

      if (VbnFeatureGroups == null) VbnFeatureGroups = (await _coderingen.VbnFeatureGroups()).ToArray();
      Console.WriteLine($"VbnFeatureGroups {VbnFeatureGroups.Length}");

      if (VbnRegularyFeatureTypes == null) VbnRegularyFeatureTypes = (await _coderingen.VbnRegularyFeatureTypes()).ToArray();
      Console.WriteLine($"VbnRegularyFeatureTypes {VbnRegularyFeatureTypes.Length}");

      if (VbnPrescriptionTypes == null) VbnPrescriptionTypes = (await _coderingen.VbnPrescriptionTypes()).ToArray();
      Console.WriteLine($"VbnPrescriptionTypes {VbnPrescriptionTypes.Length}");

      if (VbnTranslations == null) VbnTranslations = (await _coderingen.VbnTranslations()).ToArray();
      Console.WriteLine($"VbnTranslations {VbnTranslations.Length}");

      if (VbnTranslationTypes == null) VbnTranslationTypes = (await _coderingen.VbnTranslationTypes()).ToArray();
      Console.WriteLine($"VbnTranslationTypes {VbnTranslationTypes.Length}");

      if (VbnLanguages == null) VbnLanguages = (await _coderingen.VbnLanguages()).ToArray();
      Console.WriteLine($"VbnLanguages {VbnLanguages.Length}");

      if (VbnProductGroups == null) VbnProductGroups = (await _coderingen.VbnProductGroups()).ToArray();
      Console.WriteLine($"VbnProductGroups {VbnProductGroups.Length}");

      if (VbnFust == null) VbnFust = (await _coderingen.VbnFust()).ToArray();
      Console.WriteLine($"VbnFust {VbnFust.Length}");

      if (VbnFustsoort == null) VbnFustsoort = (await _coderingen.VbnFustsoort()).ToArray();
      Console.WriteLine($"VbnFustsoort {VbnFustsoort.Length}");

      if (VbnFustmateriaal == null) VbnFustmateriaal = (await _coderingen.VbnFustmateriaal()).ToArray();
      Console.WriteLine($"VbnFustmateriaal {VbnFustmateriaal.Length}");

      if (FecCompanies == null) FecCompanies = (await _coderingen.FecCompanies()).ToArray();
      Console.WriteLine($"FecCompanies {FecCompanies.Length}");

      if (FecCompanyLevels == null) FecCompanyLevels = (await _coderingen.FecCompanyLevels()).ToArray();
      Console.WriteLine($"FecCompanyLevels {FecCompanyLevels.Length}");

      if (FecCompanyRoles == null) FecCompanyRoles = (await _coderingen.FecCompanyRoles()).ToArray();
      Console.WriteLine($"FecCompanyRoles {FecCompanyRoles.Length}");

      if (FecLocations == null) FecLocations = (await _coderingen.FecLocations()).ToArray();
      Console.WriteLine($"FecLocations {FecLocations.Length}");

      if (FecLocationTypes == null) FecLocationTypes = (await _coderingen.FecLocationTypes()).ToArray();
      Console.WriteLine($"FecLocationTypes {FecLocationTypes.Length}");

      if (FecPriceDeliveryTerms == null) FecPriceDeliveryTerms = (await _coderingen.FecPriceDeliveryTerms()).ToArray();
      Console.WriteLine($"FecPriceDeliveryTerms {FecPriceDeliveryTerms.Length}");

      if (FecPackagingModes == null) FecPackagingModes = (await _coderingen.FecPackagingModes()).ToArray();
      Console.WriteLine($"FecPackagingModes {FecPackagingModes.Length}");

      if (FecDataElements == null) FecDataElements = (await _coderingen.FecDataElements()).ToArray();
      Console.WriteLine($"FecDataElements {FecDataElements.Length}");
    }

  }
}
