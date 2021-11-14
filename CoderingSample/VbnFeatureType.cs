namespace CoderingSample
{
  using Entity = VbnFeatureType;

  public sealed class VbnFeatureType
  {
    public string Agency { get; }
    public string List { get; }
    public string Value { get; }

    public const string DefaultAgency = "VBN";
    public const string DefaultList = "8";
    public const string DefaultValue = "";

    public static Entity Empty = new Entity(DefaultValue);

    public VbnFeatureType(string value, string agency = null, string list = null)
    {
      Value = (value ?? DefaultValue).Trim().ToUpper();
      Agency = agency ?? DefaultAgency;
      List = list ?? DefaultList;
    }

    public override string ToString()
    {
      if (Agency != DefaultAgency || List != DefaultList)
        return $@"{Value} ({Agency}{List})";
      return Value;
    }


    #region to/from string conversion
    public static implicit operator string(Entity code)
    {
      return code?.Value ?? DefaultValue;
    }

    public static implicit operator Entity(string value)
    {
      return new Entity(value, DefaultAgency, DefaultList);
    }
    #endregion

    #region Equals
    public static bool operator ==(Entity x, Entity y)
    {
      x = x ?? Empty;
      y = y ?? Empty;

      return
        x.Agency == y.Agency &&
        x.List == y.List &&
        x.Value == y.Value;
    }

    public static bool operator !=(Entity x, Entity y)
    {
      return !(x == y);
    }

    public override bool Equals(object obj)
    {
      var type = (Entity)obj ?? Empty;

      return
        Agency == type.Agency &&
        List == type.List &&
        Value == type.Value;
    }

    public override int GetHashCode()
    {
      return Agency.GetHashCode() ^ List.GetHashCode() ^ Value.GetHashCode();
    }
    #endregion

  }
}
