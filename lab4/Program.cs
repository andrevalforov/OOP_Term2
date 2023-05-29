using System;

namespace lab4;
class Program
{
  static void Main(string[] args)
  {
    string text = File.ReadAllText("../../../data1.txt");
    char[] symbols = text.ToCharArray();

    Console.WriteLine("Text:");
    Console.WriteLine(text);
    Console.WriteLine();

    Console.WriteLine($"Consonants: {symbols.CountConsonants()}");
    Console.WriteLine($"Vowels: {symbols.CountVowels()}");
    Console.WriteLine();

    string text2 = File.ReadAllText("../../../data2.txt");
    List<char> symbols2 = text2.ToList();

    Console.WriteLine("Text:");
    Console.WriteLine(text2);
    Console.WriteLine();

    (int consonants, int vowels) = symbols2.CountConsonantsAndVowels();

    Console.WriteLine($"Consonants: {consonants}");
    Console.WriteLine($"Vowels: {vowels}");
  }
}