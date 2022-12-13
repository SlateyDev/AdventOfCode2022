using System;
using System.Collections.Generic;
using System.Threading.Tasks;

public class PathFinder
{
    public int maxUpElevationDifference = 1;
    public int maxDownElevationDifference = 1000;
    // public int hillCost = 1;
    private PathFinderPriorityQueue _searchFrontier;
    
    public Stack<PathFinderCell> Search(List<PathFinderCell> cells, PathFinderCell sourceCell, PathFinderCell destCell)
    {
        foreach (var cell in cells)
        {
            cell.Distance = int.MaxValue;
        }

        if (_searchFrontier == null)
        {
            _searchFrontier = new PathFinderPriorityQueue();
        }
        else
        {
            _searchFrontier.Clear();
        }

        sourceCell.Distance = 0;
        _searchFrontier.Enqueue(sourceCell);
        while (_searchFrontier.Count > 0)
        {
            var currentCell = _searchFrontier.Dequeue();

            if (currentCell == destCell)
            {
                var Path = new Stack<PathFinderCell>();
                
                Path.Push(currentCell);
                currentCell = currentCell.PathFrom;
                while (currentCell != sourceCell)
                {
                    Path.Push(currentCell);
                    currentCell = currentCell.PathFrom;
                }

                return Path;
            }

            foreach (var neighbor in currentCell.Neighbors)
            {
                if (neighbor.Elevation - currentCell.Elevation > maxUpElevationDifference) continue;
                if (currentCell.Elevation - neighbor.Elevation > maxDownElevationDifference) continue;

                var distance = currentCell.Distance + 1;
                // distance += Math.Abs(neighbor.Elevation - currentCell.Elevation) * upElevationCost;
                if (distance >= neighbor.Distance) continue;

                if (neighbor.Distance == int.MaxValue)
                {
                    neighbor.Distance = distance;
                    neighbor.PathFrom = currentCell;
                    neighbor.SearchHeuristic = Math.Abs(destCell.X - neighbor.X) + Math.Abs(destCell.Y - neighbor.Y);
                    _searchFrontier.Enqueue(neighbor);
                }
                else
                {
                    var oldPriority = neighbor.SearchPriority;
                    neighbor.Distance = distance;
                    neighbor.PathFrom = currentCell;
                    _searchFrontier.Change(neighbor, oldPriority);
                }
            }
        }

        return null;
    }
}
