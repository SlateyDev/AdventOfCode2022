// Day 2 (first star answer)

{
    var fr = new StreamReader(File.Open("input-day2.txt", FileMode.Open));

    var total = 0;
    while (!fr.EndOfStream)
    {
        var lineData = fr.ReadLine();

        var them = (lineData.Split(' ')[0])[0] - 'A';
        var you = (lineData.Split(' ')[1])[0] - 'X';

        total += you + 1;
        if (you == them) total += 3;    //draw
        else if (you == (them + 1) % 3) total += 6; //win is next element
    }

    fr.Close();

    Console.WriteLine($"Day 2 part 1: {total}");
}

// Day 2 (second star answer)
{
    var fr = new StreamReader(File.Open("input-day2.txt", FileMode.Open));

    var total = 0;
    while (!fr.EndOfStream)
    {
        var lineData = fr.ReadLine();

        var them = (lineData.Split(' ')[0])[0] - 'A';
        var result = (lineData.Split(' ')[1])[0] - 'X';
        var you = (them + result + 2) % 3;
        total += you + 1 + result * 3;
    }

    fr.Close();
    Console.WriteLine($"Day 2 part 2: {total}");
}

// Day 3 (first star answer)
{
    var fr = new StreamReader(File.Open("input-day3.txt", FileMode.Open));

    var total = 0;
    while (!fr.EndOfStream)
    {
        var lineData = fr.ReadLine();

        var left = lineData.Take(lineData.Length / 2).Select(i => (byte)i).ToArray();
        var right = lineData.TakeLast(lineData.Length / 2).Select(i => (byte)i).ToArray();

        var overlapping = left.Intersect(right).ToArray();
        foreach (var val in overlapping)
        {
            var priority = val >= 'a' ? val - 'a' + 1 : val - 'A' + 27;
            total += priority;
        }
    }

    fr.Close();

    Console.WriteLine($"Day 3 part 1: {total}");
}

// Day 3 (second star answer)
{
    var fr = new StreamReader(File.Open("input-day3.txt", FileMode.Open));

    var total = 0;
    while (!fr.EndOfStream)
    {
        var lineData1 = fr.ReadLine().Select(i => (byte)i).ToArray();
        var lineData2 = fr.ReadLine().Select(i => (byte)i).ToArray();
        var lineData3 = fr.ReadLine().Select(i => (byte)i).ToArray();

        var overlapping = lineData1.Intersect(lineData2.Intersect(lineData3));

        foreach (var val in overlapping)
        {
            var priority = val >= 'a' ? val - 'a' + 1 : val - 'A' + 27;
            total += priority;
        }
    }

    fr.Close();

    Console.WriteLine($"Day 3 part 2: {total}");
}

// Day 4 (first star answer)
{
     var fr = new StreamReader(File.Open("input-day4.txt", FileMode.Open));

     var total = 0;
     while (!fr.EndOfStream)
     {
         var work = fr.ReadLine().Split(",");
         var first = work[0].Split("-").Select(int.Parse).ToArray();
         var second = work[1].Split("-").Select(int.Parse).ToArray();

         if ((first[0] >= second[0] && first[1] <= second[1]) || (second[0] >= first[0] && second[1] <= first[1]))
         {
             total += 1;
         }
     }

     fr.Close();

     Console.WriteLine($"Day 4 part 1: {total}");
}

// Day 4 (second star answer)
{
    var fr = new StreamReader(File.Open("input-day4.txt", FileMode.Open));

    var total = 0;
    while (!fr.EndOfStream)
    {
        var work = fr.ReadLine().Split(",");
        var first = work[0].Split("-").Select(int.Parse).ToArray();
        var second = work[1].Split("-").Select(int.Parse).ToArray();

        if (!((first[0] > second[1]) || (second[0] > first[1])))
        {
            total += 1;
        }
    }

    fr.Close();

    Console.WriteLine($"Day 4 part 2: {total}");
}

// Day 5 (first star answer)
{
    var fr = new StreamReader(File.Open("input-day5.txt", FileMode.Open));

    var towerLines = new Stack<string>();
    var line = fr.ReadLine();
    while (!string.IsNullOrWhiteSpace(line))
    {
        towerLines.Push(line);
        line = fr.ReadLine();
    }
    
    towerLines.Pop();

    var towers = new Stack<char>[9];;

    for (var towerIndex = 0; towerIndex < towers.Length; towerIndex++)
    {
        towers[towerIndex] = new Stack<char>();
    }

    while (towerLines.Count > 0)
    {
        var towerLine = towerLines.Pop();
        if (towerLine[1] != ' ') towers[0].Push(towerLine[1]);
        if (towerLine[5] != ' ') towers[1].Push(towerLine[5]);
        if (towerLine[9] != ' ') towers[2].Push(towerLine[9]);
        if (towerLine[13] != ' ') towers[3].Push(towerLine[13]);
        if (towerLine[17] != ' ') towers[4].Push(towerLine[17]);
        if (towerLine[21] != ' ') towers[5].Push(towerLine[21]);
        if (towerLine[25] != ' ') towers[6].Push(towerLine[25]);
        if (towerLine[29] != ' ') towers[7].Push(towerLine[29]);
        if (towerLine[33] != ' ') towers[8].Push(towerLine[33]);
    }

    while (!fr.EndOfStream)
    {
        var action = fr.ReadLine().Split("move ")[1];
        var split1 = action.Split(" from ");
        var split2 = split1[1].Split(" to ");

        var moveAmount = int.Parse(split1[0]);
        var from = int.Parse(split2[0]) - 1;
        var to = int.Parse(split2[1]) - 1;

        for (var moveIndex = 0; moveIndex < moveAmount; moveIndex++)
        {
            towers[to].Push(towers[from].Pop());
        }
    }

    fr.Close();

    var result = "";
    foreach (var tower in towers)
    {
        var top = tower.Peek();

        result += top;
    }

    Console.WriteLine($"Day 5 part 1: {result}");
}

// Day 5 (second star answer)
{
    var fr = new StreamReader(File.Open("input-day5.txt", FileMode.Open));

    var towerLines = new Stack<string>();
    var line = fr.ReadLine();
    while (!string.IsNullOrWhiteSpace(line))
    {
        towerLines.Push(line);
        line = fr.ReadLine();
    }
    
    towerLines.Pop();

    var towers = new List<char>[9];;

    for (var towerIndex = 0; towerIndex < towers.Length; towerIndex++)
    {
        towers[towerIndex] = new List<char>();
    }

    while (towerLines.Count > 0)
    {
        var towerLine = towerLines.Pop();
        if (towerLine[1] != ' ') towers[0].Add(towerLine[1]);
        if (towerLine[5] != ' ') towers[1].Add(towerLine[5]);
        if (towerLine[9] != ' ') towers[2].Add(towerLine[9]);
        if (towerLine[13] != ' ') towers[3].Add(towerLine[13]);
        if (towerLine[17] != ' ') towers[4].Add(towerLine[17]);
        if (towerLine[21] != ' ') towers[5].Add(towerLine[21]);
        if (towerLine[25] != ' ') towers[6].Add(towerLine[25]);
        if (towerLine[29] != ' ') towers[7].Add(towerLine[29]);
        if (towerLine[33] != ' ') towers[8].Add(towerLine[33]);
    }

    while (!fr.EndOfStream)
    {
        var action = fr.ReadLine().Split("move ")[1];
        var split1 = action.Split(" from ");
        var split2 = split1[1].Split(" to ");

        var moveAmount = int.Parse(split1[0]);
        var from = int.Parse(split2[0]) - 1;
        var to = int.Parse(split2[1]) - 1;

        towers[to].AddRange(towers[from].TakeLast(moveAmount));
        towers[from].RemoveRange(towers[from].Count - moveAmount, moveAmount);
    }

    fr.Close();

    var result = "";
    foreach (var tower in towers)
    {
        var top = tower[^1];

        result += top;
    }

    Console.WriteLine($"Day 5 part 2: {result}");
}

// Day 6 (first star answer)
{
    var fr = new StreamReader(File.Open("input-day6.txt", FileMode.Open));

    var line = fr.ReadLine().ToArray();

    const int markerLength = 4;
    var marker = new char[markerLength];
    var markerIndex = 0;
    var bufferSize = 0;
    var charIndex = 0;

    for (charIndex = 0; charIndex < line.Length; charIndex++)
    {
        marker[markerIndex] = line[charIndex];
        markerIndex = (markerIndex + 1) % markerLength;
        bufferSize = Math.Min(bufferSize + 1, markerLength);

        if (bufferSize == markerLength && marker.GroupBy(i => i).Count() == markerLength)
        {
            break;
        }
    }

    fr.Close();

    Console.WriteLine($"Day 6 part 1: {charIndex + 1}");
}

// Day 6 (second star answer)
{
    var fr = new StreamReader(File.Open("input-day6.txt", FileMode.Open));

    var line = fr.ReadLine().ToArray();

    const int markerLength = 14;
    var marker = new char[markerLength];
    var markerIndex = 0;
    var bufferSize = 0;
    var charIndex = 0;

    for (charIndex = 0; charIndex < line.Length; charIndex++)
    {
        marker[markerIndex] = line[charIndex];
        markerIndex = (markerIndex + 1) % markerLength;
        bufferSize = Math.Min(bufferSize + 1, markerLength);

        if (bufferSize == markerLength && marker.GroupBy(i => i).Count() == markerLength)
        {
            break;
        }
    }

    fr.Close();

    Console.WriteLine($"Day 6 part 2: {charIndex + 1}");
}

// Day 7 (first star answer)
{
    var fr = new StreamReader(File.Open("input-day7.txt", FileMode.Open));

    var folders = new Dictionary<string, int>();

    var currentPath = "/";

    string changePath(string path, string folder)
    {
        switch (folder)
        {
            case "/":
                return "/";
            case "..":
                return string.Join("", path[0..Math.Max(1, path.LastIndexOf("/"))]);
            default:
                return path + (path.EndsWith("/") ? "" : "/") + folder;
        }
    }

    while (!fr.EndOfStream)
    {
        var line = fr.ReadLine().Split(" ", 2);
        
        switch (line[0])
        {
            case "$":
                var commandLine = line[1].Split(" ");
                switch (commandLine[0])
                {
                    case "cd":
                        currentPath = changePath(currentPath, commandLine[1]);
                        break;
                    case "ls":
                        //ignore line
                        break;
                }
                break;
            case "dir":
                var dirPath = changePath(currentPath, line[1]);
                if (!folders.ContainsKey(dirPath))
                {
                    folders.Add(dirPath, 0);
                }
                break;
            default:
                var fileSize = int.Parse(line[0]);
                if (!folders.ContainsKey(currentPath))
                {
                    folders.Add(currentPath, 0);
                }
                folders[currentPath] += fileSize;
                var tempPath = currentPath;
                while (tempPath != "/")
                {
                    tempPath = changePath(tempPath, "..");
                    folders[tempPath] += fileSize;
                }
                break;
        }
    }

    fr.Close();

    var total = 0;
    
    foreach (var folder in folders)
    {
        if (folder.Value <= 100000)
        {
            total += folder.Value;
        }
    }

    Console.WriteLine($"Day 7 part 1: {total}");
}

// Day 7 (second star answer)
{
    var fr = new StreamReader(File.Open("input-day7.txt", FileMode.Open));

    var folders = new Dictionary<string, int>();

    var currentPath = "/";

    string changePath(string path, string folder)
    {
        switch (folder)
        {
            case "/":
                return "/";
            case "..":
                return string.Join("", path[0..Math.Max(1, path.LastIndexOf("/"))]);
            default:
                return path + (path.EndsWith("/") ? "" : "/") + folder;
        }
    }

    while (!fr.EndOfStream)
    {
        var line = fr.ReadLine().Split(" ", 2);
        
        switch (line[0])
        {
            case "$":
                var commandLine = line[1].Split(" ");
                switch (commandLine[0])
                {
                    case "cd":
                        currentPath = changePath(currentPath, commandLine[1]);
                        break;
                    case "ls":
                        //ignore line
                        break;
                }
                break;
            case "dir":
                var dirPath = changePath(currentPath, line[1]);
                if (!folders.ContainsKey(dirPath))
                {
                    folders.Add(dirPath, 0);
                }
                break;
            default:
                var fileSize = int.Parse(line[0]);
                if (!folders.ContainsKey(currentPath))
                {
                    folders.Add(currentPath, 0);
                }
                folders[currentPath] += fileSize;
                var tempPath = currentPath;
                while (tempPath != "/")
                {
                    tempPath = changePath(tempPath, "..");
                    folders[tempPath] += fileSize;
                }
                break;
        }
    }

    fr.Close();

    var spaceAvailable = 70000000;
    var unusedSpaceNeeded = 30000000;
    var spaceTaken = folders["/"];
    var currentUnusedSpace = spaceAvailable - spaceTaken;
    
    var total = 0;

    var smallestAcceptableFolder = spaceAvailable;
    
    foreach (var folder in folders)
    {
        var thisFolderMakesAvailable = currentUnusedSpace + folder.Value;
        if (thisFolderMakesAvailable >= unusedSpaceNeeded && folder.Value < smallestAcceptableFolder)
        {
            smallestAcceptableFolder = folder.Value;
        }
    }

    Console.WriteLine($"Day 7 part 2: {smallestAcceptableFolder}");
}

// Day 8 (first star answer)
{
    var fr = new StreamReader(File.Open("input-day8.txt", FileMode.Open));
    var fileData = fr.ReadToEnd();
    fr.Close();

    var rowData = fileData.Split('\n', StringSplitOptions.RemoveEmptyEntries);
    var rows = rowData.Length;
    var cols = rowData[0].Length;

    var visibleTrees = 0;
    for (var y = 1; y < rows - 1; y++)
    {
        for (var x = 1; x < cols - 1; x++)
        {
            var tree = rowData[y][x] - '0';

            bool visible = false;
            for (var xIndex = 0; xIndex < x; xIndex++)
            {
                visible = true;
                var comparer = rowData[y][xIndex] - '0';
                if (comparer >= tree)
                {
                    visible = false;
                    break;
                }
            }
            if (visible)
            {
                visibleTrees += 1;
                continue;
            }
            for (var xIndex = x + 1; xIndex < cols; xIndex++)
            {
                visible = true;
                var comparer = rowData[y][xIndex] - '0';
                if (comparer >= tree)
                {
                    visible = false;
                    break;
                }
            }
            if (visible)
            {
                visibleTrees += 1;
                continue;
            }
            for (var yIndex = 0; yIndex < y; yIndex++)
            {
                visible = true;
                var comparer = rowData[yIndex][x] - '0';
                if (comparer >= tree)
                {
                    visible = false;
                    break;
                }
            }
            if (visible)
            {
                visibleTrees += 1;
                continue;
            }
            for (var yIndex = y + 1; yIndex < rows; yIndex++)
            {
                visible = true;
                var comparer = rowData[yIndex][x] - '0';
                if (comparer >= tree)
                {
                    visible = false;
                    break;
                }
            }
            if (visible)
            {
                visibleTrees += 1;
            }
        }
    }

    visibleTrees += rows * 2;
    visibleTrees += cols * 2 - 4;

    Console.WriteLine($"Day 8 part 1: {visibleTrees}");
}

// Day 8 (second star answer)
{
    var fr = new StreamReader(File.Open("input-day8.txt", FileMode.Open));
    var fileData = fr.ReadToEnd();
    fr.Close();

    var rowData = fileData.Split('\n', StringSplitOptions.RemoveEmptyEntries);
    var rows = rowData.Length;
    var cols = rowData[0].Length;

    var highestScenicScore = 0;
    for (var y = 1; y < rows - 1; y++)
    {
        for (var x = 1; x < cols - 1; x++)
        {
            var tree = rowData[y][x] - '0';

            var leftTrees = 0;
            var rightTrees = 0;
            var topTrees = 0;
            var bottomTrees = 0;

            for (var xIndex = x - 1; xIndex >= 0; xIndex--)
            {
                var comparer = rowData[y][xIndex] - '0';
                leftTrees++;
                if (comparer >= tree) break;
            }

            for (var xIndex = x + 1; xIndex < cols; xIndex++)
            {
                var comparer = rowData[y][xIndex] - '0';
                rightTrees++;
                if (comparer >= tree) break;
            }

            for (var yIndex = y - 1; yIndex >= 0; yIndex--)
            {
                var comparer = rowData[yIndex][x] - '0';
                topTrees++;
                if (comparer >= tree) break;
            }

            for (var yIndex = y + 1; yIndex < rows; yIndex++)
            {
                var comparer = rowData[yIndex][x] - '0';
                bottomTrees++;
                if (comparer >= tree) break;
            }
            
            var scenicScore = leftTrees * rightTrees * topTrees * bottomTrees;
            if (scenicScore > highestScenicScore)
            {
                highestScenicScore = scenicScore;
            }
        }
    }

    Console.WriteLine($"Day 8 part 2: {highestScenicScore}");
}

// Day 9 (first star answer)
{
    var fr = new StreamReader(File.Open("input-day9.txt", FileMode.Open));
    const int numKnots = 2;
    var knots = new (int x, int y)[numKnots];
    var tailPositions = new Dictionary<(int x, int y), int> { { (0, 0), 1 } };
    while (!fr.EndOfStream)
    {
        var lineData = fr.ReadLine().Split(' ');
        var direction = lineData[0];
        var distance = int.Parse(lineData[1]);

        var delta = direction switch
        {
            "L" => (-1, 0),
            "R" => (1, 0),
            "U" => (0, -1),
            "D" => (0, 1),
            _ => throw new Exception("Can't happen")
        };

        for (var moveIndex = 0; moveIndex < distance; moveIndex++)
        {
            knots[0].Item1 += delta.Item1;
            knots[0].Item2 += delta.Item2;

            for (var knotIndex = 1; knotIndex < knots.Length; knotIndex++)
            {
                if (Math.Abs(knots[knotIndex].Item1 - knots[knotIndex - 1].Item1) > 1 || Math.Abs(knots[knotIndex].Item2 - knots[knotIndex - 1].Item2) > 1)
                {
                    if (knots[knotIndex - 1].Item1 != knots[knotIndex].Item1 && knots[knotIndex - 1].Item2 != knots[knotIndex].Item2)
                    {
                        knots[knotIndex].Item1 += -Math.Sign(knots[knotIndex].Item1 - knots[knotIndex - 1].Item1);
                        knots[knotIndex].Item2 += -Math.Sign(knots[knotIndex].Item2 - knots[knotIndex - 1].Item2);
                    }
                    else if (Math.Abs(knots[knotIndex].Item1 - knots[knotIndex - 1].Item1) > 1)
                    {
                        knots[knotIndex].Item1 += -Math.Sign(knots[knotIndex].Item1 - knots[knotIndex - 1].Item1);
                    }
                    else if (Math.Abs(knots[knotIndex].Item2 - knots[knotIndex - 1].Item2) > 1)
                    {
                        knots[knotIndex].Item2 += -Math.Sign(knots[knotIndex].Item2 - knots[knotIndex - 1].Item2);
                    }
                    if (knotIndex == knots.Length - 1)
                    {
                        if (!tailPositions.ContainsKey((knots[knotIndex].Item1, knots[knotIndex].Item2)))
                        {
                            tailPositions.Add((knots[knotIndex].Item1, knots[knotIndex].Item2), 0);
                        }

                        tailPositions[(knots[knotIndex].Item1, knots[knotIndex].Item2)]++;
                    }
                }
            }
        }
    }
    fr.Close();

    Console.WriteLine($"Day 9 part 1: {tailPositions.Count}");
}

// Day 9 (second star answer)
{
    var fr = new StreamReader(File.Open("input-day9.txt", FileMode.Open));
    const int numKnots = 10;
    var knots = new (int x, int y)[numKnots];
    var tailPositions = new Dictionary<(int x, int y), int> { { (0, 0), 1 } };
    while (!fr.EndOfStream)
    {
        var lineData = fr.ReadLine().Split(' ');
        var direction = lineData[0];
        var distance = int.Parse(lineData[1]);

        var delta = direction switch
        {
            "L" => (-1, 0),
            "R" => (1, 0),
            "U" => (0, -1),
            "D" => (0, 1),
            _ => throw new Exception("Can't happen")
        };

        for (var moveIndex = 0; moveIndex < distance; moveIndex++)
        {
            knots[0].Item1 += delta.Item1;
            knots[0].Item2 += delta.Item2;

            for (var knotIndex = 1; knotIndex < knots.Length; knotIndex++)
            {
                if (Math.Abs(knots[knotIndex].Item1 - knots[knotIndex - 1].Item1) > 1 || Math.Abs(knots[knotIndex].Item2 - knots[knotIndex - 1].Item2) > 1)
                {
                    if (knots[knotIndex - 1].Item1 != knots[knotIndex].Item1 && knots[knotIndex - 1].Item2 != knots[knotIndex].Item2)
                    {
                        knots[knotIndex].Item1 += -Math.Sign(knots[knotIndex].Item1 - knots[knotIndex - 1].Item1);
                        knots[knotIndex].Item2 += -Math.Sign(knots[knotIndex].Item2 - knots[knotIndex - 1].Item2);
                    }
                    else if (Math.Abs(knots[knotIndex].Item1 - knots[knotIndex - 1].Item1) > 1)
                    {
                        knots[knotIndex].Item1 += -Math.Sign(knots[knotIndex].Item1 - knots[knotIndex - 1].Item1);
                    }
                    else if (Math.Abs(knots[knotIndex].Item2 - knots[knotIndex - 1].Item2) > 1)
                    {
                        knots[knotIndex].Item2 += -Math.Sign(knots[knotIndex].Item2 - knots[knotIndex - 1].Item2);
                    }
                    if (knotIndex == knots.Length - 1)
                    {
                        if (!tailPositions.ContainsKey((knots[knotIndex].Item1, knots[knotIndex].Item2)))
                        {
                            tailPositions.Add((knots[knotIndex].Item1, knots[knotIndex].Item2), 0);
                        }

                        tailPositions[(knots[knotIndex].Item1, knots[knotIndex].Item2)]++;
                    }
                }
            }
        }
    }
    fr.Close();

    Console.WriteLine($"Day 9 part 2: {tailPositions.Count}");
}

Console.WriteLine("End of program");