public class Valve
{
    public string valve { get; set; }
    public int flow { get; set; }
    public List<string> destinations { get; set; } = new();
    public List<Valve> valves { get; set; } = new();
    public int openedWhen { get; set; } = 0;
    public bool opened { get; set; } = false;
}