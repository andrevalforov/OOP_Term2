namespace lab2;
class Program
{
  static void Main(string[] args)
  {
    bool tag = true;
    while (tag)
    {
      Console.Clear();
      Console.WriteLine("[1] - Task 1.1");
      Console.WriteLine("[2] - Task 1.2");
      Console.WriteLine("[3] - Task 1.3");
      Console.WriteLine("[4] - Task 2.1");
      Console.WriteLine("[5] - Task 2.2");
      Console.WriteLine("[6] - Task 2.3");
      Console.WriteLine("[0] - Exit");
      if (!int.TryParse(Console.ReadLine(), out int input))
        continue;

      switch (input)
      {
        case 1:
          Task1_1();
          Console.ReadKey();
          break;
        case 2:
          Task1_2();
          Console.ReadKey();
          break;
        case 3:
          Task1_3();
          Console.ReadKey();
          break;
        case 4:
          Task2_1();
          Console.ReadKey();
          break;
        case 5:
          Task2_2();
          Console.ReadKey();
          break;
        case 6:
          Task2_3();
          Console.ReadKey();
          break;
        case 0:
          tag = false;
          break;
        default:
          tag = false;
          break;
      }
    }
  }

  static void Task1_1()
  {
    Console.WriteLine("Input numbers separated with space (1 2 3...):");
    double[] input = Console.ReadLine()
      .Split(' ', StringSplitOptions.RemoveEmptyEntries)
      .Select(x => double.Parse(x))
      .ToArray();

    if (!input.Any())
      return;

    Console.WriteLine($"Average value is: {input.Sum() / (double)input.Length}");
  }

  static void Task1_2()
  {
    (double, double)[] vectors = new (double, double)[2];

    Console.WriteLine("Input first vector coordinates separated with space (x y):");

    double[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(x => double.Parse(x)).ToArray();
    if (input.Length != 2)
      return;
    vectors[0] = (input[0], input[1]);

    Console.WriteLine("Input second vector coordinates separated with space (x y):");

    input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(x => double.Parse(x)).ToArray();
    if (input.Length != 2)
      return;
    vectors[1] = (input[0], input[1]);

    Console.WriteLine($"({vectors[0].Item1}; {vectors[0].Item2}) + ({vectors[1].Item1}; {vectors[1].Item2}) = ({vectors[0].Item1 + vectors[1].Item1}; {vectors[0].Item2 + vectors[1].Item2})");
  }

  static void Task1_3()
  {
    Console.WriteLine("Input elements separated with space (1 2 3...):");
    double[] input = Console.ReadLine()
      .Split(' ', StringSplitOptions.RemoveEmptyEntries)
      .Select(x => double.Parse(x))
      .ToArray();

    if (!input.Any())
      return;

    for (int i = 0; i < input.Length; i++)
    {
      for (int j = i + 1; j < input.Length; j++)
      {
        if (input[i] > input[j])
          (input[i], input[j]) = (input[j], input[i]);
      }
    }

    Console.WriteLine(string.Join(", ", input));
  }

  static void Task2_1()
  {
    Console.Write("Input row/column count: ");
    int rows = int.Parse(Console.ReadLine());

    double[,] input = new double[rows, rows];

    for (int i = 0; i < rows; i++)
    {
      Console.WriteLine($"Fill row [{i + 1}] values separated with space:");
      double[] row = Console.ReadLine()
                     .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                     .Select(x => double.Parse(x))
                     .Take(rows)
                     .ToArray();

      for (int j = 0; j < rows; j++)
      {
        input[i, j] = row[j];
      }
    }

    for (int i = 1; i < rows; i += 2)
    {
      for (int j = 0; j < rows; j++)
      {
        for (int k = j + 1; k < rows; k++)
        {
          if (input[i, j] > input[i, k])
            (input[i, j], input[i, k]) = (input[i, k], input[i, j]);
        }
      }
    }

    Console.WriteLine("Result: ");
    for (int i = 0; i < rows; i++)
    {
      double[] row = Enumerable.Range(0, input.GetLength(1))
                .Select(x => input[i, x])
                .ToArray();

      Console.WriteLine(string.Join(' ', row));
    }
  }

  static void Task2_2()
  {
    Console.Write("Input row count: ");
    int rows = int.Parse(Console.ReadLine());
    Console.Write("Input column count: ");
    int columns = int.Parse(Console.ReadLine());

    double[,] input = new double[rows, columns];

    for (int i = 0; i < rows; i++)
    {
      Console.WriteLine($"Fill row [{i + 1}] values separated with space:");
      double[] row = Console.ReadLine()
                     .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                     .Select(x => double.Parse(x))
                     .Take(columns)
                     .ToArray();

      for (int j = 0; j < columns; j++)
      {
        input[i, j] = row[j];
      }
    }

    int count = 0;

    for (int i = 0; i < rows; i++)
    {
      bool isChecked = false;
      for (int j = 0; j < columns; j++)
      {
        if (input[i, j] == 0 && !isChecked)
          isChecked = true;
      }
      if (!isChecked)
        count++;
    }

    Console.WriteLine("Non-zero row count: " + count);
  }

  static void Task2_3()
  {
    Console.Write("Input row count: ");
    int rows = int.Parse(Console.ReadLine());
    Console.Write("Input column count: ");
    int columns = int.Parse(Console.ReadLine());

    double[,] input = new double[rows, columns];

    for (int i = 0; i < rows; i++)
    {
      Console.WriteLine($"Fill row [{i + 1}] values separated with space:");
      double[] row = Console.ReadLine()
                     .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                     .Select(x => double.Parse(x))
                     .Take(columns)
                     .ToArray();

      for (int j = 0; j < columns; j++)
      {
        input[i, j] = row[j];
      }
    }

    List<(double, int)> valueCounts = new();

    for (int i = 0; i < rows; i++)
    {
      for (int j = 0; j < columns; j++)
      {
        int index = valueCounts.FindIndex(v => v.Item1 == input[i, j]);

        if (index != -1)
          valueCounts[index] = (input[i, j], valueCounts[index].Item2 + 1);
        else
          valueCounts.Add((input[i, j], 1));
      }
    }

    Console.WriteLine("Max repeated value: " + valueCounts.Where(v => v.Item2 > 1).MaxBy(v => v.Item1).Item1);
  }
}

