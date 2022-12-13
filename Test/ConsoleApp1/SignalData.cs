public class SignalData
{
    public string Data { get; private set; }
    public List<SignalData> SubSignals { get; set; } = new List<SignalData>();

    public SignalData(string data)
    {
        if (data.StartsWith("[") && data.EndsWith("]"))
        {
            var isArray = data.Aggregate(0, (i, c) =>
            {
                return c switch
                {
                    '[' => 1,
                    ']' => -1,
                    _ when i == 0 => 1,
                    _ => 0,
                };
            });

            if (isArray == 0)
            {
                SubSignals.Add(new SignalData(data[1..^1]));
            }
            else
            {
                Console.WriteLine($"Test: {isArray}");
                if (data.Contains(','))
                {
                    var level = 0;
                    var lastSplit = 0;
                    for (var i = 0; i < data.Length; i++)
                    {
                        switch (data[i])
                        {
                            case '[':
                                level++;
                                break;
                            case ']':
                                level--;
                                break;
                            case ',' when level == 0:
                                Console.WriteLine(data[lastSplit..i]);
                                break;
                        }
                    }
                }
            }
        }
    }

    public void ReorderWith(SignalData data)
    {
        
    }
}