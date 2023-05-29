using System;
namespace lab3
{
  public class SideQuadrangle : IQuadrangle
  {
    public double Side1 { get; set; }
    public double Side2 { get; set; }
    public double Side3 { get; set; }
    public double Side4 { get; set; }

    public double Angle1 { get; set; }
    public double Angle2 { get; set; }
    public double Angle3 { get; set; }
    public double Angle4 { get; set; }

    private bool AnglesAdded { get; set; } = false;

    public SideQuadrangle()
    {
      this.Side1 = 1;
      this.Side2 = 1;
      this.Side3 = 1;
      this.Side4 = 1;
    }

    public SideQuadrangle(double side1, double side2, double side3, double side4)
    {
      if (side1 > side2 + side3 + side4
        || side2 > side1 + side3 + side4
        || side3 > side1 + side2 + side4
        || side4 > side1 + side2 + side3)
        throw new Exception("The quadrangle must be convex");

      this.Side1 = side1;
      this.Side2 = side2;
      this.Side3 = side3;
      this.Side4 = side4;
    }

    public SideQuadrangle(double side1, double side2, double side3, double side4,
      double angle1, double angle2, double angle3, double angle4)
    {
      if (side1 > side2 + side3 + side4
        || side2 > side1 + side3 + side4
        || side3 > side1 + side2 + side4
        || side4 > side1 + side2 + side3)
        throw new Exception("The quadrangle must be convex");

      if (angle1 + angle2 + angle3 + angle4 != 360)
        throw new Exception("Sum of angles must be equal 360");

      this.Side1 = side1;
      this.Side2 = side2;
      this.Side3 = side3;
      this.Side4 = side4;

      this.Angle1 = angle1;
      this.Angle2 = angle2;
      this.Angle3 = angle3;
      this.Angle4 = angle4;
      this.AnglesAdded = true;
    }

    public SideQuadrangle(SideQuadrangle quadrangle)
    {
      this.Side1 = quadrangle.Side1;
      this.Side2 = quadrangle.Side2;
      this.Side3 = quadrangle.Side3;
      this.Side4 = quadrangle.Side4;

      this.Angle1 = quadrangle.Angle1;
      this.Angle2 = quadrangle.Angle2;
      this.Angle3 = quadrangle.Angle3;
      this.Angle4 = quadrangle.Angle4;
      this.AnglesAdded = true;
    }

    public void AddAngles(double angle1, double angle2, double angle3, double angle4)
    {
      if (angle1 + angle2 + angle3 + angle4 != 360)
        throw new Exception("Sum of angles must be equal 360");

      this.Angle1 = angle1;
      this.Angle2 = angle2;
      this.Angle3 = angle3;
      this.Angle4 = angle4;
      this.AnglesAdded = true;
    }

    public double GetSquare()
    {
      if (!AnglesAdded)
        return double.NaN;

      double radAngle1 = ConvertToRadians(Angle1);
      double radAngle2 = ConvertToRadians(Angle2);
      double radAngle3 = ConvertToRadians(Angle3);
      double radAngle4 = ConvertToRadians(Angle4);

      double semiPerimeter = (Side1 + Side2 + Side3 + Side4) / 2;

      //S = √((p - a) * (p - b) * (p - c) * (p - d) - (a * b * c * d * cos²(α + γ) / 4))
      //формула площі Брахмагупти

      double area = Math.Sqrt(
          (semiPerimeter - Side1) *
          (semiPerimeter - Side2) *
          (semiPerimeter - Side3) *
          (semiPerimeter - Side4) -
          (Side1 * Side3 * Math.Sin(radAngle2) * Math.Sin(radAngle4)) -
          (Side2 * Side4 * Math.Sin(radAngle1) * Math.Sin(radAngle3)));

      return Math.Round(area, 2);
    }

    public double GetPerimeter() => Math.Round(Side1 + Side2 + Side3 + Side4, 2);

    public QuadrangleType GetQuadrangleType()
    {
      if (Side1 == Side2 && Side2 == Side3 && Side3 == Side4)
      {
        if (AnglesAdded && Angle1 == Angle2 && Angle2 == Angle3 && Angle3 == Angle4)
          return QuadrangleType.Square;
        else
          return QuadrangleType.Rhombus;
      }
      else if (Side1 == Side3 && Side2 == Side4 || Side1 == Side2 && Side3 == Side4)
      {
        if (AnglesAdded && Angle1 == 90)
          return QuadrangleType.Rectangle;
        else
          return QuadrangleType.Parallelogram;
      }
      else
        return QuadrangleType.Other;
    }

    public string Show() => $"a={Side1}  b={Side2}  c={Side3}  d={Side4}"
      + (AnglesAdded ? $"\n  ∠A: {Angle1}°  ∠B: {Angle2}°  ∠C: {Angle3}°  ∠D: {Angle4}°" : string.Empty);

    public bool HasAngles() => AnglesAdded;

    private static double ConvertToRadians(double degrees)
    {
      return degrees * Math.PI / 180;
    }
  }
}

