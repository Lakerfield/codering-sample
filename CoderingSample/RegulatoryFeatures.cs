using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CoderingSample
{
  public class RegulatoryFeatures : IEnumerable<RegulatoryFeature>
  {
    private readonly List<RegulatoryFeature> _features;
    public const int RegulatoryFeaturesCount = 7;

    public static RegulatoryFeatures Empty = new RegulatoryFeatures(null);

    private RegulatoryFeatures(List<RegulatoryFeature> features)
    {
      _features = features ?? new List<RegulatoryFeature>(0);
    }

    public static RegulatoryFeatures Parse(string data)
    {
      if (string.IsNullOrWhiteSpace(data))
        return Empty;

      var features = new List<RegulatoryFeature>(RegulatoryFeaturesCount);
      var parts = data.Split(';');
      foreach (var part in parts)
        features.Add(RegulatoryFeature.Parse(part));
      return new RegulatoryFeatures(features);
    }

    /// <summary>
    /// Get RegulatoryFeature from display position (from 1 to 7)
    /// </summary>
    /// <param name="index">index starts with 1</param>
    /// <returns></returns>
    public RegulatoryFeature this[int index]
    {
      get
      {
        if (index < 1 || index > _features.Count)
          return RegulatoryFeature.Empty;
        return _features[index - 1];
      }
    }

    public IEnumerator<RegulatoryFeature> GetEnumerator()
    {
      return _features.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
      return GetEnumerator();
    }

    public override string ToString()
    {
      return string.Join(";", _features).TrimEnd(';');
    }

    public static string GenerateData(IEnumerable<RegulatoryFeature> features)
    {
      return string.Join(";", features.Select(f => (f.Prescription == FeaturePrescription.Empty || f.Type == VbnFeatureType.Empty) ? "" : $"{f.Type}:{(int) f.Prescription}")).TrimEnd(';');
    }
  }

  public class RegulatoryFeature
  {
    public VbnFeatureType Type { get; }
    public FeaturePrescription Prescription { get; }

    public static RegulatoryFeature Empty = new RegulatoryFeature(VbnFeatureType.Empty, FeaturePrescription.Empty);

    public RegulatoryFeature(VbnFeatureType type, FeaturePrescription prescription)
    {
      Type = type ?? VbnFeatureType.Empty;
      Prescription = prescription;
    }

    public static RegulatoryFeature Parse(string data)
    {
      if (string.IsNullOrWhiteSpace(data))
        return Empty;

      var parts = data.Split(':');
      return new RegulatoryFeature(parts[0], (FeaturePrescription)Convert.ToInt32(parts[1]));
    }

    public override string ToString()
    {
      if (Prescription == FeaturePrescription.Empty)
        return string.Empty;
      return $@"{Type.Value} {Prescription}";
    }
  }

  public enum FeaturePrescription
  {
    Empty = 0, //Leeg
    Required = 1, //Verplicht
    Recommended = 2, //Geadviseerd
    Allowed = 3, //Toegestaan
  }

}
