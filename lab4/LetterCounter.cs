using System;
namespace lab4
{
  public static class LetterCounterExtension
  {
    private static char[] Consonants =
    {
      'b', 'c', 'd', 'f', 'g', 'h', 'j', 'k', 'l', 'm', 'n', 'p', 'q', 'r', 's', 't', 'v', 'w', 'x', 'y', 'z'
    };

    private static char[] Vowels = { 'a', 'e', 'i', 'o', 'u' };

    public static int CountConsonants(this char[] symbols)
    {
      int count = 0;

      foreach (var symbol in symbols)
      {
        if (Consonants.Any(c => c == char.ToLower(symbol)))
          count++;
      }

      return count;
    }

    public static int CountConsonants(this List<char> symbols)
    {
      int count = 0;

      foreach (var symbol in symbols)
      {
        if (Consonants.Any(c => c == char.ToLower(symbol)))
          count++;
      }

      return count;
    }

    public static int CountVowels(this char[] symbols)
    {
      int count = 0;

      foreach (var symbol in symbols)
      {
        if (Vowels.Any(c => c == char.ToLower(symbol)))
          count++;
      }

      return count;
    }

    public static int CountVowels(this List<char> symbols)
    {
      int count = 0;

      foreach (var symbol in symbols)
      {
        if (Vowels.Any(c => c == char.ToLower(symbol)))
          count++;
      }

      return count;
    }

    public static (int, int) CountConsonantsAndVowels(this char[] symbols)
    {
      int consonantCount = 0, vowelCount = 0;

      foreach (var symbol in symbols)
      {
        if (Consonants.Any(c => c == char.ToLower(symbol)))
          consonantCount++;
        else if (Vowels.Any(c => c == char.ToLower(symbol)))
          vowelCount++;
      }

      return (consonantCount, vowelCount);
    }

    public static (int, int) CountConsonantsAndVowels(this List<char> symbols)
    {
      int consonantCount = 0, vowelCount = 0;

      foreach (var symbol in symbols)
      {
        if (Consonants.Any(c => c == char.ToLower(symbol)))
          consonantCount++;
        else if (Vowels.Any(c => c == char.ToLower(symbol)))
          vowelCount++;
      }

      return (consonantCount, vowelCount);
    }
  }
}

