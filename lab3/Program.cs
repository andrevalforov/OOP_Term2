using System;

namespace lab3;
class Program
{
  static void Main(string[] args)
  {
    List<SideQuadrangle> sideQuadrangles = new();
    List<PointQuadrangle> pointQuadrangles = new();

    bool tag = true, _tag = true;

    while (tag)
    {
      Console.Clear();
      ShowQuadrangleList(sideQuadrangles);
      ShowQuadrangleList(pointQuadrangles);

      Console.WriteLine("[1] - Add side quadrangle");
      Console.WriteLine("[2] - Add point quadrangle");
      Console.WriteLine("[3] - Operations with side quadrangles" + (sideQuadrangles.Any() ? string.Empty : " NOT ENOUGH SIDE QUADRANGLES"));
      Console.WriteLine("[4] - Operations with point quadrangles" + (pointQuadrangles.Any() ? string.Empty : " NOT ENOUGH POINT QUADRANGLES"));

      if (!int.TryParse(Console.ReadLine(), out int input))
        continue;

      switch (input)
      {
        case 1:
          Console.WriteLine("Input 4 sides separated with space (1 1...):");
          double[] res = (Console.ReadLine() ?? "1 1 1 1").Split(' ').Select(double.Parse).ToArray();
          SideQuadrangle quadrangle = new SideQuadrangle(res[0], res[1], res[2], res[3]);

          Console.WriteLine("Would you like to add angles? (y/n)");
          if (Console.ReadLine().Equals("y", StringComparison.CurrentCultureIgnoreCase))
          {
            Console.WriteLine("Input 4 angles (°) separated with space (90 90...):");
            res = (Console.ReadLine() ?? "90 90 90 90").Split(' ').Select(double.Parse).ToArray();

            quadrangle.AddAngles(res[0], res[1], res[2], res[3]);
          }

          sideQuadrangles.Add(quadrangle);
          break;

        case 2:
          Console.WriteLine("Input coordinates of 4 points separated with space (0;0 1;1...):");
          string[] result = (Console.ReadLine() ?? "0;0 0;1 1;1 1;0").Split(' ').ToArray();
          pointQuadrangles.Add(new PointQuadrangle(
            (double.Parse(result[0].Split(';').ToArray()[0]), double.Parse(result[0].Split(';').ToArray()[1])),
            (double.Parse(result[1].Split(';').ToArray()[0]), double.Parse(result[1].Split(';').ToArray()[1])),
            (double.Parse(result[2].Split(';').ToArray()[0]), double.Parse(result[2].Split(';').ToArray()[1])),
            (double.Parse(result[3].Split(';').ToArray()[0]), double.Parse(result[3].Split(';').ToArray()[1]))
            ));
          break;

        case 3:
          {
            if (sideQuadrangles.Any())
              while (_tag)
              {
                Console.Clear();
                ShowQuadrangleList(sideQuadrangles);

                Console.WriteLine("[1] - Get perimeter");
                Console.WriteLine("[2] - Get type");
                if (sideQuadrangles.Any(q => q.HasAngles()))
                  Console.WriteLine("[3] - Get square");
                Console.WriteLine("[0] - Back");

                if (!int.TryParse(Console.ReadLine(), out input))
                  continue;

                switch (input)
                {
                  case 1:
                    Console.WriteLine($"Input existing quadrangle index (1-{sideQuadrangles.Count}):");
                    int index = int.Parse(Console.ReadLine()) - 1;
                    Console.WriteLine("Perimeter: " + sideQuadrangles[index].GetPerimeter());
                    Console.ReadKey();
                    break;
                  case 2:
                    Console.WriteLine($"Input existing quadrangle index (1-{sideQuadrangles.Count}):");
                    index = int.Parse(Console.ReadLine()) - 1;
                    Console.WriteLine("Type: " + sideQuadrangles[index].GetQuadrangleType().GetDisplayName());
                    Console.ReadKey();
                    break;
                  case 3:
                    Console.WriteLine($"Input existing quadrangle index (1-{sideQuadrangles.Count}):");
                    index = int.Parse(Console.ReadLine()) - 1;
                    SideQuadrangle quadrangle1 = sideQuadrangles[index];

                    if (!quadrangle1.HasAngles())
                    {
                      Console.WriteLine("Choose another quadrangle with angles");
                      Console.ReadKey();
                      continue;
                    }

                    Console.WriteLine("Square: " + quadrangle1.GetSquare());
                    Console.ReadKey();
                    break;
                  case 0:
                    _tag = false;
                    break;
                  default:
                    _tag = false;
                    break;
                }
              }
            break;
          }

        case 4:
          {
            if (pointQuadrangles.Any())
            {
              _tag = true;
              while (_tag)
              {
                Console.Clear();
                ShowQuadrangleList(pointQuadrangles);

                Console.WriteLine("[1] - Get perimeter");
                Console.WriteLine("[2] - Get type");
                Console.WriteLine("[3] - Get square");
                Console.WriteLine("[0] - Back");

                if (!int.TryParse(Console.ReadLine(), out input))
                  continue;

                switch (input)
                {
                  case 1:
                    Console.WriteLine($"Input existing quadrangle index (1-{pointQuadrangles.Count}):");
                    int index = int.Parse(Console.ReadLine()) - 1;
                    Console.WriteLine("Perimeter: " + pointQuadrangles[index].GetPerimeter());
                    Console.ReadKey();
                    break;
                  case 2:
                    Console.WriteLine($"Input existing quadrangle index (1-{pointQuadrangles.Count}):");
                    index = int.Parse(Console.ReadLine()) - 1;
                    Console.WriteLine("Type: " + pointQuadrangles[index].GetQuadrangleType().GetDisplayName());
                    Console.ReadKey();
                    break;
                  case 3:
                    Console.WriteLine($"Input existing quadrangle index (1-{pointQuadrangles.Count}):");
                    index = int.Parse(Console.ReadLine()) - 1;
                    Console.WriteLine("Square: " + pointQuadrangles[index].GetSquare());
                    Console.ReadKey();
                    break;
                  case 0:
                    _tag = false;
                    break;
                  default:
                    _tag = false;
                    break;
                }
              }
            }
            break;
          }

        default:
          tag = false;
          break;
      }
    }
  }

  private static void ShowQuadrangleList(IEnumerable<IQuadrangle> quadrangles)
  {
    if (quadrangles.Any() && quadrangles.First().GetType().Equals(typeof(SideQuadrangle)))
      Console.WriteLine($"Side quadrangles ({quadrangles.Count()}):");
    else if (quadrangles.Any())
      Console.WriteLine($"Point quadrangles ({quadrangles.Count()}):");

    for (int i = 0; i < quadrangles.Count(); i++)
      Console.WriteLine($"{i + 1}. " + quadrangles.ToList()[i].Show());

    Console.WriteLine();
  }
}