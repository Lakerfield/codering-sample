using System;
using System.Collections.Generic;
using System.Text;

namespace CoderingSample
{
  public class VbnFeature
  {
    public Guid Id { get; set; }
    public string Code { get; set; }
    public string Description { get; set; }

    private List<VbnFeatureValue> _numbers;
    public List<VbnFeatureValue> Values
    {
      get => _numbers ?? (_numbers = new List<VbnFeatureValue>());
      set => _numbers = value;
    }

    public class VbnFeatureValue
    {
      public string Value { get; set; }
      public string Description { get; set; }
    }
  }
}
