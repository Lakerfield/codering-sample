namespace CoderingSample
{
  using Entity = PlantRegistration;

  public class PlantRegistration
  {
    public int Value { get; }
    public int Registrator { get; }

    public const int DefaultRegistrator = 1;
    public const int DefaultValue = 0;

    public static Entity Empty = new Entity(DefaultValue, DefaultRegistrator);

    public PlantRegistration(int value, int registrator)
    {
      Value = value;
      Registrator = registrator;
    }

    public static PlantRegistration FromStrings(string value, string registrator)
    {
      return new PlantRegistration(value.ToInt(DefaultValue), registrator.ToInt(DefaultRegistrator));
    }

    public override string ToString()
    {
      return $"{Value} ({Registrator})";
    }



    public static implicit operator int(Entity code)
    {
      return code?.Value ?? DefaultValue;
    }

    public static implicit operator Entity(int value)
    {
      return new Entity(value, DefaultRegistrator);
    }



    public static bool operator ==(Entity x, Entity y)
    {
      x = x ?? Empty;
      y = y ?? Empty;

      return
        x.Registrator == y.Registrator &&
        x.Value == y.Value;
    }

    public static bool operator !=(Entity x, Entity y)
    {
      return !(x == y);
    }

    public override bool Equals(object obj)
    {
      var text = (Entity)obj ?? Empty;

      return
        Registrator == text.Registrator &&
        Value == text.Value;
    }

    public override int GetHashCode()
    {
      return (Registrator, Value).GetHashCode();
    }

  }
}
