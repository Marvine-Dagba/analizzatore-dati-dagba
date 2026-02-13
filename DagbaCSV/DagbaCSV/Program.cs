public class Record
{
    public string NomeColonna1 { get; set; }
    public int NomeColonna2 { get; set; }
    public double NomeColonna3 { get; set; }
}

public class CsvReader
{
    public List<Record> ReadCsv(string filePath)
    {
        List<Record> records = new List<Record>();
        try
        {
            using (var reader = new StreamReader(filePath))
            {
                string header = reader.ReadLine();

                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    var values = SplitCsvLine(line);

                    {
                        NomeColonna1 = values[0],
                        NomeColonna2 = int.Parse(values[1]),
                        NomeColonna3 = double.Parse(values[2])
                    }
                    ;
                    records.Add(record);
                }
            }
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("Errore: Il file specificato non esiste. Verifica il percorso.");
        }
        catch (FormatException)
        {
            Console.WriteLine("Errore: Formato dei dati non valido. Controlla il file CSV.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Errore generico: {ex.Message}");
        }
        return records;
    }

    private string[] SplitCsvLine(string line)
    {
    }
}

public class DataAnalyzer
{
    public void Analyze(List<Record> records)
    {
        double average = records.Average(r => r.NomeColonna3);
        Console.WriteLine($"Media: {average}");
    }
}

class Program
{
    static void Main()
    {
        string filePath = "percorso/al/tuo/file.csv";
        CsvReader reader = new CsvReader();
        List<Record> records = reader.ReadCsv(filePath);

        if (records.Count > 0)
        {
            DataAnalyzer analyzer = new DataAnalyzer();
            analyzer.Analyze(records);
        }
    }
}

