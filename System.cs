using System.CommandLine;

using System;

public static class Program {
    /// <summary>
    /// Laver en varm drik efter dine ønsker.
    /// </summary>
    /// <param name="coffeeType">Typen af kaffe (Latte, Espresso, Americano).</param>
    /// <param name="sugar">Antallet af sukkerskefulde.</param>
    /// <param name="milk">Skal der være mælk i kaffen?</param>
    public static void Main(string coffeeType, int sugar = 0, bool milk = false) {
        Console.WriteLine($"Du har valgt en {coffeeType}.");
        Console.WriteLine($"Antal sukkerskefulde: {sugar}");
        
        if (milk) {
            Console.WriteLine("Mælk er tilføjet.");
        } else {
            Console.WriteLine("Ingen mælk tilføjet.");
        }

        Console.WriteLine("\nDin kaffe er klar. God fornøjelse!");
    }
}