namespace _023_property
{
  class Rectangle
  {
    private double width;
    private double height;

    public double GetWidth()
    {
      return width;
    }
    public void SetWidth(double width)
    {
      if (width > 0)
      {
        this.width = width;
      }
    }
    public double GetHeight()
    {
      return height;
    }
    public void SetHeight(double height)
    {
      if (height > 0)
      {
        this.height = height;
      }
    }

    public double GetArea()
    { 
      return width * height; 
    }
  }

  class RectWithProp
  {
    public double Width { get; set; } 
    public double Height { get; set; }
    public double GetArea()
    {
      return Width * Height;
    }
  }

  class RectWithPropFull
  {
    private int width;

    public int Width
    {
      get { return width; }
      set { if(value > 0) width = value; }
    }

    private int height;

    public int Height
    {
      get { return height; }
      set { if(value > 0) height = value; }
    }

    public double GetArea()
    {
      return Width * Height;
    }
  }

  internal class Program
  {
    static void Main(string[] args)
    {
      Rectangle r = new Rectangle();
      r.SetWidth(10);
      r.SetHeight(10);
      Console.WriteLine(r.GetArea());

      RectWithProp r1 = new RectWithProp();
      r1.Width = 10;
      r1.Height = 10;
      Console.WriteLine(r1.GetArea());

      RectWithPropFull r2 = new RectWithPropFull();
      r2.Width = 10;
      r2.Height = 10;
      Console.WriteLine(r2.GetArea());

    }
  }
}