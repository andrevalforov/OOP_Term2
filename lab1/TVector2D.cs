namespace lab1
{
  public class TVector2D
  {
    protected double X { get; set; }
    protected double Y { get; set; }

    public TVector2D()
    {
      this.X = 0;
      this.Y = 0;
    }

    public TVector2D(double x, double y)
    {
      this.X = x;
      this.Y = y;
    }

    public TVector2D(double x1, double y1, double x2, double y2)
    {
      this.X = x2 - x1;
      this.Y = y2 - y1;
    }

    public TVector2D(TVector2D vector)
    {
      this.X = vector.X;
      this.Y = vector.Y;
    }

    public void SetX(double x) => this.X = x;
    public void SetY(double y) => this.Y = y;

    public double GetX() => this.X;
    public double GetY() => this.Y;

    public virtual string Show() => $"({Math.Round(X, 2)}; {Math.Round(Y, 2)})";

    public virtual double GetLength() => Math.Round(Math.Sqrt(Math.Pow(this.X, 2) + Math.Pow(this.Y, 2)), 2);

    public virtual TVector2D GetNormedVector() => new TVector2D(Math.Round(this.X / GetLength(), 2), Math.Round(this.Y / GetLength(), 2));

    public string[] Compare(TVector2D vector)
    {
      string[] res = new string[2];

      if (this.X / vector.GetX() == this.Y / vector.GetY())
        res[0] = "Colinear";
      else
        res[0] = "Not colinear";

      if (this.X * vector.GetX() + this.Y * vector.GetY() == 0)
        res[1] = "Perpendicular";
      else
        res[1] = "Not perpendicular";

      return res;
    }

    public static string[] Compare(TVector2D vector1, TVector2D vector2)
    {
      string[] res = new string[2];

      if (vector1.X / vector2.GetX() == vector1.Y / vector2.GetY())
        res[0] = "Colinear";
      else
        res[0] = "Not colinear";

      if (vector1.X * vector2.GetX() + vector1.Y * vector2.GetY() == 0)
        res[1] = "Perpendicular";
      else
        res[1] = "Not perpendicular";

      return res;
    }

    public static TVector2D operator +(TVector2D vector1, TVector2D vector2) => new TVector2D(vector1.X + vector2.X, vector1.Y + vector2.Y);

    public static TVector2D operator -(TVector2D vector1, TVector2D vector2) => new TVector2D(vector1.X - vector2.X, vector1.Y - vector2.Y);

    public static TVector2D operator *(TVector2D vector1, TVector2D vector2) => new TVector2D(vector1.X * vector2.X, vector1.Y * vector2.Y);
  }
}

