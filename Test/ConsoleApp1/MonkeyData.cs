namespace ConsoleApp1;

public class MonkeyData
{
    public List<long> items { get; set; }
    public Func<long, long, long> operation { get; set; }
    public string operationValue { get; set; }
    public long testDivisor { get; set; }
    public int trueMonkey { get; set; }
    public int falseMonkey { get; set; }
    
    public long inspections { get; set; }
}