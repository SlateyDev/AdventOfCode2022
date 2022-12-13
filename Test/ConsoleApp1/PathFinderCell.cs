public class PathFinderCell
{
    public int X { get; set; }
    public int Y { get; set; }

    public List<PathFinderCell> Neighbors { get; } = new();

    public int SearchHeuristic { get; set; }
    public int SearchPriority => Distance + SearchHeuristic;
    public PathFinderCell NextWithSamePriority { get; set; }
    public PathFinderCell PathFrom { get; set; }

    public int Distance { get; set; } = int.MaxValue;
    public int Elevation { get; set; }
}