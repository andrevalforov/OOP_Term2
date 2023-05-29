using System;
namespace lab3
{
  public enum QuadrangleType
  {
    Square,
    Rectangle,
    Rhombus,
    Parallelogram,
    Other
  }

  public static class QuadrangleTypeExtensions
  {
    public static string GetDisplayName(this QuadrangleType type)
    {
      return type switch
      {
        QuadrangleType.Square => "Square",
        QuadrangleType.Rectangle => "Rectangle",
        QuadrangleType.Rhombus => "Rhombus",
        QuadrangleType.Parallelogram => "Parallelogram",
        QuadrangleType.Other => "Convex quadrangle",
        _ => string.Empty,
      };
    }
  }

}

