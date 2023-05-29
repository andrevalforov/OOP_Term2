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
          Tasks.Task1_1();
          Console.ReadKey();
          break;
        case 2:
          Tasks.Task1_2();
          Console.ReadKey();
          break;
        case 3:
          Tasks.Task1_3();
          Console.ReadKey();
          break;
        case 4:
          Tasks.Task2_1();
          Console.ReadKey();
          break;
        case 5:
          Tasks.Task2_2();
          Console.ReadKey();
          break;
        case 6:
          Tasks.Task2_3();
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

  
}

