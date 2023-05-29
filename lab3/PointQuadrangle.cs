using System;
namespace lab3
{
  public class PointQuadrangle : IQuadrangle
  {
    public (double, double) Point1 { get; set; }
    public (double, double) Point2 { get; set; }
    public (double, double) Point3 { get; set; }
    public (double, double) Point4 { get; set; }

    public PointQuadrangle()
    {
      this.Point1 = (0, 0);
      this.Point2 = (1, 0);
      this.Point3 = (1, 1);
      this.Point4 = (0, 1);
    }

    public PointQuadrangle((double, double) p1, (double, double) p2, (double, double) p3, (double, double) p4)
    {
      this.Point1 = p1;
      this.Point2 = p2;
      this.Point3 = p3;
      this.Point4 = p4;
    }

    public PointQuadrangle(PointQuadrangle quadrangle)
    {
      this.Point1 = quadrangle.Point1;
      this.Point2 = quadrangle.Point2;
      this.Point3 = quadrangle.Point3;
      this.Point4 = quadrangle.Point4;
    }

    public double GetSquare()
    {
      double side1 = Math.Sqrt(Math.Pow(Point2.Item1 - Point1.Item1, 2) + Math.Pow(Point2.Item2 - Point1.Item2, 2));
      double side2 = Math.Sqrt(Math.Pow(Point3.Item1 - Point2.Item1, 2) + Math.Pow(Point3.Item2 - Point2.Item2, 2));
      double side3 = Math.Sqrt(Math.Pow(Point4.Item1 - Point3.Item1, 2) + Math.Pow(Point4.Item2 - Point3.Item2, 2));
      double side4 = Math.Sqrt(Math.Pow(Point1.Item1 - Point4.Item1, 2) + Math.Pow(Point1.Item2 - Point4.Item2, 2));

      double alpha = Math.Atan2(Point2.Item2 - Point1.Item2, Point2.Item1 - Point1.Item1);
      double gamma = Math.Atan2(Point4.Item2 - Point1.Item2, Point4.Item1 - Point1.Item1);

      double s = (side1 + side2 + side3 + side4) / 2;
      double cosSquared = Math.Pow(Math.Cos(alpha + gamma), 2);

      double area = Math.Sqrt((s - side1) * (s - side2) * (s - side3) * (s - side4) - (side1 * side2 * side3 * side4 * cosSquared / 4));

      return Math.Round(area, 2);
    }

    public double GetPerimeter()
    {
      double side1 = Math.Sqrt(Math.Pow(Point2.Item1 - Point1.Item1, 2) + Math.Pow(Point2.Item2 - Point1.Item2, 2));
      double side2 = Math.Sqrt(Math.Pow(Point3.Item1 - Point2.Item1, 2) + Math.Pow(Point3.Item2 - Point2.Item2, 2));
      double side3 = Math.Sqrt(Math.Pow(Point4.Item1 - Point3.Item1, 2) + Math.Pow(Point4.Item2 - Point3.Item2, 2));
      double side4 = Math.Sqrt(Math.Pow(Point1.Item1 - Point4.Item1, 2) + Math.Pow(Point1.Item2 - Point4.Item2, 2));

      return Math.Round(side1 + side2 + side3 + side4, 2);
    }

    public QuadrangleType GetQuadrangleType()
    {
      double side1 = Math.Sqrt(Math.Pow(Point2.Item1 - Point1.Item1, 2) + Math.Pow(Point2.Item2 - Point1.Item2, 2));
      double side2 = Math.Sqrt(Math.Pow(Point3.Item1 - Point2.Item1, 2) + Math.Pow(Point3.Item2 - Point2.Item2, 2));
      double side3 = Math.Sqrt(Math.Pow(Point4.Item1 - Point3.Item1, 2) + Math.Pow(Point4.Item2 - Point3.Item2, 2));
      double side4 = Math.Sqrt(Math.Pow(Point1.Item1 - Point4.Item1, 2) + Math.Pow(Point1.Item2 - Point4.Item2, 2));

      if (side1 == side2 && side2 == side3 && side3 == side4)
      {
        double angle1 = CalculateAngle(Point2.Item1 - Point1.Item1, Point2.Item2 - Point1.Item2, Point4.Item1 - Point1.Item1, Point4.Item2 - Point1.Item2);
        //double angle2 = CalculateAngle(Point1.Item1 - Point2.Item1, Point1.Item2 - Point2.Item2, Point3.Item1 - Point3.Item1, Point3.Item2 - Point2.Item2);
        //double angle3 = CalculateAngle(Point2.Item1 - Point3.Item1, Point2.Item2 - Point3.Item2, Point4.Item1 - Point3.Item1, Point4.Item2 - Point3.Item2);
        //double angle4 = CalculateAngle(Point3.Item1 - Point4.Item1, Point3.Item2 - Point4.Item2, Point1.Item1 - Point4.Item1, Point1.Item2 - Point4.Item2);

        if (angle1 == 90)
          return QuadrangleType.Square;
        else
          return QuadrangleType.Rhombus;
      }
      else if (side1 == side3 && side2 == side4 || side1 == side2 && side3 == side4)
      {
        double angle1 = Math.Atan2(Point2.Item2 - Point1.Item2, Point2.Item1 - Point1.Item1);

        if (angle1 * (180.0 / Math.PI) == 90)
          return QuadrangleType.Rectangle;
        else
          return QuadrangleType.Parallelogram;
      }
      else
        return QuadrangleType.Other;
    }

    public string Show() =>
      $"A({Point1.Item1}; {Point1.Item2})  B({Point2.Item1}; {Point2.Item2})  C({Point3.Item1}; {Point3.Item2})  D({Point4.Item1}; {Point4.Item2})";

    private double CalculateAngle(double x1, double y1, double x2, double y2)
    {
      double dotProduct = x1 * x2 + y1 * y2;
      double magnitude1 = Math.Sqrt(x1 * x1 + y1 * y1);
      double magnitude2 = Math.Sqrt(x2 * x2 + y2 * y2);

      double cosTheta = dotProduct / (magnitude1 * magnitude2);
      double theta = Math.Acos(cosTheta);
      double angleInDegrees = theta * (180.0 / Math.PI);

      return angleInDegrees;
    }
  }
}

