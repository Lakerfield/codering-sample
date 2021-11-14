using System;
using System.Collections.Generic;

namespace CoderingSample
{
  public class Article
  {
    public Guid Id { get; set; }

    public int Vbn { get; set; }
    public string GroupCode { get; set; }
    public string GroupLevel1 { get; set; }
    public string GroupLevel2 { get; set; }
    public string GroupLevel3 { get; set; }
    public string GroupLevel4 { get; set; }

    public string Name { get; set; }
    public string TradeName { get; set; }

    public PlantRegistration PlantRegistration { get; set; }

    public string Genus { get; set; }
    public string Species { get; set; }
    public string Cultivar { get; set; }

    private RegulatoryFeatures _regulatoryFeatures;
    public RegulatoryFeatures RegulatoryFeatures =>
      _regulatoryFeatures ?? (_regulatoryFeatures = RegulatoryFeatures.Parse(RegulatoryData));

    private string _regulatoryData;
    public string RegulatoryData
    {
      get => _regulatoryData;
      set
      {
        if (_regulatoryData == value)
          return;
        _regulatoryData = value;
        _regulatoryFeatures = null;
      }
    }

    private string _featureData;
    public string FeatureData
    {
      get => _featureData;
      set
      {
        if (_featureData == value)
          return;
        _featureData = value;
      }
    }

    public DateTime CreatedAt { get; set; }
    public DateTime ModifiedAt { get; set; }
  }
}
