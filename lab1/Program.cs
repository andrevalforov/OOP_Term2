
namespace lab1;
class Program
{
  static void Main(string[] args)
  {
    List<TVector2D> vector2Ds = new List<TVector2D>();
    List<TVector3D> vector3Ds = new List<TVector3D>();
    bool tag = true, _tag;

    while (tag)
    {
      Console.Clear();
      ShowVectorList(vector2Ds);
      ShowVectorList(vector3Ds);

      Console.WriteLine($"[1] - Add new 2D vector");
      Console.WriteLine($"[2] - Make copy from existing 2D vector" + (vector2Ds.Any() ? string.Empty : "\t--NOT ENOUGH VECTORS"));
      Console.WriteLine($"[3] - Remove 2D vector" + (vector2Ds.Any() ? string.Empty : "\t--NOT ENOUGH VECTORS"));
      Console.WriteLine($"[4] - Operations with 2D vectors" + (vector2Ds.Any() ? string.Empty : "\t--NOT ENOUGH VECTORS"));
      Console.WriteLine($"[5] - Add new 3D vector");
      Console.WriteLine($"[6] - Make copy from existing 3D vector" + (vector3Ds.Any() ? string.Empty : "\t--NOT ENOUGH VECTORS"));
      Console.WriteLine($"[7] - Remove 3D vector" + (vector3Ds.Any() ? string.Empty : "\t--NOT ENOUGH VECTORS"));
      Console.WriteLine($"[8] - Operations with 3D vectors" + (vector3Ds.Any() ? string.Empty : "\t--NOT ENOUGH VECTORS"));
      Console.WriteLine("[0] - Exit");

      if (!int.TryParse(Console.ReadLine(), out int input))
        continue;

      int index, _index;

      switch (input)
      {
        case 1:
          Console.WriteLine("Input semicolon separated coordinates (X;Y):");
          double[] res = (Console.ReadLine() ?? "0;0").Split(';').Select(double.Parse).ToArray();
          vector2Ds.Add(new TVector2D(res[0], res[1]));
          break;
        case 2:
          if (vector2Ds.Any())
          {
            Console.WriteLine($"Input existing vector index (1-{vector2Ds.Count}):");
            index = int.Parse(Console.ReadLine()) - 1;
            vector2Ds.Add(new TVector2D(vector2Ds[index]));
          }
          break;
        case 3:
          if (vector2Ds.Any())
          {
            Console.WriteLine($"Input existing vector index (1-{vector2Ds.Count}):");
            vector2Ds.RemoveAt(int.Parse(Console.ReadLine()) - 1);
          }
          break;
        case 4:
          _tag = true;
          while (_tag)
          {
            Console.Clear();
            ShowVectorList(vector2Ds);

            Console.WriteLine("[1] - Get length" + (vector2Ds.Any() ? string.Empty : "\t--NOT ENOUGH VECTORS"));
            Console.WriteLine("[2] - Get normed vector" + (vector2Ds.Any() ? string.Empty : "\t--NOT ENOUGH VECTORS"));
            Console.WriteLine("[3] - Compare vectors" + (vector2Ds.Count > 1 ? string.Empty : "\t--NOT ENOUGH VECTORS"));
            Console.WriteLine("[4] - Sum (+) vectors" + (vector2Ds.Count > 1 ? string.Empty : "\t--NOT ENOUGH VECTORS"));
            Console.WriteLine("[5] - Substract (-) vectors" + (vector2Ds.Count > 1 ? string.Empty : "\t--NOT ENOUGH VECTORS"));
            Console.WriteLine("[6] - Multiply (*) vectors" + (vector2Ds.Count > 1 ? string.Empty : "\t--NOT ENOUGH VECTORS"));
            Console.WriteLine("[0] - Back");

            if (!int.TryParse(Console.ReadLine(), out input))
              continue;

            switch (input)
            {
              case 1:
                if (vector2Ds.Any())
                {
                  Console.WriteLine($"Input existing vector index (1-{vector2Ds.Count}):");
                  index = int.Parse(Console.ReadLine()) - 1;
                  Console.WriteLine("Length: " + vector2Ds[index].GetLength());
                  Console.ReadKey();
                }
                break;
              case 2:
                if (vector2Ds.Any())
                {
                  Console.WriteLine($"Input existing vector index (1-{vector2Ds.Count}):");
                  index = int.Parse(Console.ReadLine()) - 1;
                  Console.WriteLine("Normed vector: " + vector2Ds[index].GetNormedVector().Show());
                  Console.ReadKey();
                }
                break;
              case 3:
                if (vector2Ds.Count > 1)
                {
                  Console.WriteLine($"Input existing vector first index (1-{vector2Ds.Count}):");
                  index = int.Parse(Console.ReadLine()) - 1;
                  Console.WriteLine($"Input existing vector second index (1-{vector2Ds.Count}):");
                  _index = int.Parse(Console.ReadLine()) - 1;

                  Console.WriteLine($"Vector {vector2Ds[index].Show()} and vector {vector2Ds[_index].Show()} are: "
                    + String.Join(", ", vector2Ds[index].Compare(vector2Ds[_index])));
                  Console.ReadKey();
                }
                break;
              case 4:
                if (vector2Ds.Count > 1)
                {
                  Console.WriteLine($"Input existing vector first index (1-{vector2Ds.Count}):");
                  index = int.Parse(Console.ReadLine()) - 1;
                  Console.WriteLine($"Input existing vector second index (1-{vector2Ds.Count}):");
                  _index = int.Parse(Console.ReadLine()) - 1;

                  Console.WriteLine($"{vector2Ds[index].Show()} + {vector2Ds[_index].Show()} = {(vector2Ds[index] + vector2Ds[_index]).Show()}");
                  Console.ReadKey();
                }
                break;
              case 5:
                if (vector2Ds.Count > 1)
                {
                  Console.WriteLine($"Input existing vector first index (1-{vector2Ds.Count}):");
                  index = int.Parse(Console.ReadLine()) - 1;
                  Console.WriteLine($"Input existing vector second index (1-{vector2Ds.Count}):");
                  _index = int.Parse(Console.ReadLine()) - 1;

                  Console.WriteLine($"{vector2Ds[index].Show()} - {vector2Ds[_index].Show()} = {(vector2Ds[index] - vector2Ds[_index]).Show()}");
                  Console.ReadKey();
                }
                break;
              case 6:
                if (vector2Ds.Count > 1)
                {
                  Console.WriteLine($"Input existing vector first index (1-{vector2Ds.Count}):");
                  index = int.Parse(Console.ReadLine()) - 1;
                  Console.WriteLine($"Input existing vector second index (1-{vector2Ds.Count}):");
                  _index = int.Parse(Console.ReadLine()) - 1;

                  Console.WriteLine($"{vector2Ds[index].Show()} * {vector2Ds[_index].Show()} = {(vector2Ds[index] * vector2Ds[_index]).Show()}");
                  Console.ReadKey();
                }
                break;
              case 0:
                _tag = false;
                break;
              default:
                continue;
            }
          }
          break;
        case 5:
          Console.WriteLine("Input semicolon separated coordinates (X;Y;Z):");
          res = (Console.ReadLine() ?? "0;0;0").Split(';').Select(double.Parse).ToArray();
          vector3Ds.Add(new TVector3D(res[0], res[1], res[2]));
          break;
        case 6:
          if (vector3Ds.Any())
          {
            Console.WriteLine($"Input existing vector index (1-{vector3Ds.Count}):");
            index = int.Parse(Console.ReadLine()) - 1;
            vector3Ds.Add(new TVector3D(vector3Ds[index]));
          }
          break;
        case 7:
          if (vector3Ds.Any())
          {
            Console.WriteLine($"Input existing vector index (1-{vector3Ds.Count}):");
            vector3Ds.RemoveAt(int.Parse(Console.ReadLine()) - 1);
          }
          break;
        case 8:
          _tag = true;
          while (_tag)
          {
            Console.Clear();
            ShowVectorList(vector3Ds);

            Console.WriteLine("[1] - Get length" + (vector3Ds.Any() ? string.Empty : "\t--NOT ENOUGH VECTORS"));
            Console.WriteLine("[2] - Get normed vector" + (vector3Ds.Any() ? string.Empty : "\t--NOT ENOUGH VECTORS"));
            Console.WriteLine("[3] - Compare vectors" + (vector3Ds.Count > 1 ? string.Empty : "\t--NOT ENOUGH VECTORS"));
            Console.WriteLine("[4] - Sum (+) vectors" + (vector3Ds.Count > 1 ? string.Empty : "\t--NOT ENOUGH VECTORS"));
            Console.WriteLine("[5] - Substract (-) vectors" + (vector3Ds.Count > 1 ? string.Empty : "\t--NOT ENOUGH VECTORS"));
            Console.WriteLine("[6] - Multiply (*) vectors" + (vector3Ds.Count > 1 ? string.Empty : "\t--NOT ENOUGH VECTORS"));
            Console.WriteLine("[0] - Back");

            if (!int.TryParse(Console.ReadLine(), out input))
              continue;

            switch (input)
            {
              case 1:
                if (vector3Ds.Any())
                {
                  Console.WriteLine($"Input existing vector index (1-{vector3Ds.Count}):");
                  index = int.Parse(Console.ReadLine()) - 1;
                  Console.WriteLine("Length: " + vector3Ds[index].GetLength());
                  Console.ReadKey();
                }
                break;
              case 2:
                if (vector3Ds.Any())
                {
                  Console.WriteLine($"Input existing vector index (1-{vector3Ds.Count}):");
                  index = int.Parse(Console.ReadLine()) - 1;
                  Console.WriteLine("Normed vector: " + vector3Ds[index].GetNormedVector().Show());
                  Console.ReadKey();
                }
                break;
              case 3:
                if (vector3Ds.Count > 1)
                {
                  Console.WriteLine($"Input existing vector first index (1-{vector3Ds.Count}):");
                  index = int.Parse(Console.ReadLine()) - 1;
                  Console.WriteLine($"Input existing vector second index (1-{vector3Ds.Count}):");
                  _index = int.Parse(Console.ReadLine()) - 1;

                  Console.WriteLine($"Vector {vector3Ds[index].Show()} and vector {vector3Ds[_index].Show()} are: "
                    + String.Join(", ", vector3Ds[index].Compare(vector3Ds[_index])));
                  Console.ReadKey();
                }
                break;
              case 4:
                if (vector3Ds.Count > 1)
                {
                  Console.WriteLine($"Input existing vector first index (1-{vector3Ds.Count}):");
                  index = int.Parse(Console.ReadLine()) - 1;
                  Console.WriteLine($"Input existing vector second index (1-{vector3Ds.Count}):");
                  _index = int.Parse(Console.ReadLine()) - 1;

                  Console.WriteLine($"{vector3Ds[index].Show()} + {vector3Ds[_index].Show()} = {(vector3Ds[index] + vector3Ds[_index]).Show()}");
                  Console.ReadKey();
                }
                break;
              case 5:
                if (vector3Ds.Count > 1)
                {
                  Console.WriteLine($"Input existing vector first index (1-{vector3Ds.Count}):");
                  index = int.Parse(Console.ReadLine()) - 1;
                  Console.WriteLine($"Input existing vector second index (1-{vector3Ds.Count}):");
                  _index = int.Parse(Console.ReadLine()) - 1;

                  Console.WriteLine($"{vector3Ds[index].Show()} - {vector3Ds[_index].Show()} = {(vector3Ds[index] - vector3Ds[_index]).Show()}");
                  Console.ReadKey();
                }
                break;
              case 6:
                if (vector3Ds.Count > 1)
                {
                  Console.WriteLine($"Input existing vector first index (1-{vector3Ds.Count}):");
                  index = int.Parse(Console.ReadLine()) - 1;
                  Console.WriteLine($"Input existing vector second index (1-{vector3Ds.Count}):");
                  _index = int.Parse(Console.ReadLine()) - 1;

                  Console.WriteLine($"{vector3Ds[index].Show()} * {vector3Ds[_index].Show()} = {(vector3Ds[index] * vector3Ds[_index]).Show()}");
                  Console.ReadKey();
                }
                break;
              case 0:
                _tag = false;
                break;
              default:
                continue;
            }
          }
          break;
        case 0:
          tag = false;
          break;
        default:
          continue;
      }
    }
  }

  private static void ShowVectorList(IEnumerable<TVector2D> vectors)
  {
    if (vectors.Any() && vectors.First().GetType().Equals(typeof(TVector3D)))
      Console.WriteLine($"3D vectors ({vectors.Count()}):");
    else if (vectors.Any())
      Console.WriteLine($"2D vectors ({vectors.Count()}):");

    for (int i = 0; i < vectors.Count(); i++)
      Console.WriteLine($"{i + 1}. " + vectors.ToList()[i].Show());

    Console.WriteLine();
  }
}

