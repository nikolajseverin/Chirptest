using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Globalization;
using System.Linq;
using CsvHelper;
using CsvHelper.Configuration;


// Klassen er nu generisk og har en begrænsning for T, så den ved, at T er en Cheep
public class CSVDatabase<T> where T : Cheep
{
    private readonly string _fileName;

    // Constructor matcher klassenavnet
    public CSVDatabase(string fileName)
    {
        _fileName = fileName;
    }
    
    // Returnerer nu en liste af T-objekter og tager limit som argument
    public IEnumerable<T> Read(int limit)
{
    try
    {
        using var reader = new StreamReader(_fileName);
        using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
        return csv.GetRecords<T>().Take(limit).ToList();
    }
    catch (FileNotFoundException)
    {
        Console.WriteLine($"Database file not found. Please ensure '{_fileName}' exists.");
        return new List<T>();
    }
    catch (Exception ex)
    {
        Console.WriteLine($"An error occurred: {ex.Message}");
        return new List<T>();
    }
}

    // Tager et generisk T-objekt som argument
    public void Store(T record)
    {
        var fileExists = File.Exists(_fileName);
        using (var stream = new StreamWriter(_fileName, append: true))
        using (var csv = new CsvWriter(stream, CultureInfo.InvariantCulture))
        {
            // Hvis filen ikke findes, skal vi først skrive header
            if (!fileExists)
            {
                csv.WriteHeader<T>();
                csv.NextRecord();
            }

        csv.WriteRecord(record);
        csv.NextRecord();
        }
    }
}
