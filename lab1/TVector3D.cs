namespace lab1
{
  public class TVector3D : TVector2D
  {
    protected double Z { get; set; }

    public TVector3D()
    {
      this.X = 0;
      this.Y = 0;
      this.Z = 0;
    }

    public TVector3D(double x, double y, double z)
    {
      this.X = x;
      this.Y = y;
      this.Z = z;
    }

    public TVector3D(TVector3D vector)
    {
      this.X = vector.X;
      this.Y = vector.Y;
      this.Z = vector.Z;
    }

    public void SetZ(double z) => this.Z = z;

    public double GetZ() => this.Z;

    public override string Show() => $"({Math.Round(X, 2)}; {Math.Round(Y, 2)}; {Math.Round(Z, 2)})";

    public override double GetLength() => Math.Round(Math.Sqrt(Math.Pow(this.X, 2) + Math.Pow(this.Y, 2) + Math.Pow(this.Z, 2)), 2);

    public override TVector3D GetNormedVector() => new TVector3D(Math.Round(this.X / GetLength(), 2), Math.Round(this.Y / GetLength(), 2), Math.Round(this.Z / GetLength(), 2));

    public string[] Compare(TVector3D vector)
    {
      string[] res = new string[2];

      if (this.X / vector.GetX() == this.Y / vector.GetY() && this.X / vector.GetX() == this.Z / vector.GetZ())
        res[0] = "Colinear";
      else
        res[0] = "Not colinear";

      if (this.X * vector.GetX() + this.Y * vector.GetY() + this.Z * vector.GetZ() == 0)
        res[1] = "Perpendicular";
      else
        res[1] = "Not perpendicular";

      return res;
    }

    public static TVector3D operator +(TVector3D vector1, TVector3D vector2) => new TVector3D(vector1.X + vector2.X, vector1.Y + vector2.Y, vector1.Z + vector2.Z);

    public static TVector3D operator -(TVector3D vector1, TVector3D vector2) => new TVector3D(vector1.X - vector2.X, vector1.Y - vector2.Y, vector1.Z - vector2.Z);

    public static TVector3D operator *(TVector3D vector1, TVector3D vector2) => new TVector3D(vector1.X * vector2.X, vector1.Y * vector2.Y, vector1.Z * vector2.Z);
  }
}

