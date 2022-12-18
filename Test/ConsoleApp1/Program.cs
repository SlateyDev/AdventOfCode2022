using System.Reflection.Metadata.Ecma335;
using System.Text.Json.Nodes;
using ConsoleApp1;

// Day 1 (first star answer)
{
    var fr = new StreamReader(File.Open("input-day1.txt", FileMode.Open));

    var total = 0;
    var totalCalories = 0;
    while (!fr.EndOfStream)
    {
        var lineData = fr.ReadLine();

        if (lineData.Length == 0)
        {
            if (totalCalories > total)
            {
                total = totalCalories;
            }
            totalCalories = 0;
            continue;
        }

        var calories = int.Parse(lineData);
        totalCalories += calories;
    }

    fr.Close();

    Console.WriteLine($"Day 1 part 1: {total}");
}

// Day 1 (second star answer)
{
    var fr = new StreamReader(File.Open("input-day1.txt", FileMode.Open));

    var total = 0;
    var elvesCalories = new List<int>();
    var totalCalories = 0;
    while (!fr.EndOfStream)
    {
        var lineData = fr.ReadLine();

        if (lineData.Length == 0)
        {
            elvesCalories.Add(totalCalories);
            totalCalories = 0;
            continue;
        }

        var calories = int.Parse(lineData);
        totalCalories += calories;
    }

    fr.Close();
    
    total = elvesCalories.OrderByDescending(elfCalories => elfCalories).Take(3).Sum();

    Console.WriteLine($"Day 1 part 2: {total}");
}

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

// Day 10 (first star answer)
{
    var fr = new StreamReader(File.Open("input-day10.txt", FileMode.Open));

    var cycles = 0;
    var xReg = 1;
    var signalStrength = 0;

    void handleCycle()
    {
        cycles++;
        if (cycles % 40 != 20 || cycles > 220) return;
        signalStrength += xReg * cycles;
    }

    while (!fr.EndOfStream)
    {
        var lineData = fr.ReadLine();
        handleCycle();

        if (lineData == "noop") continue;
        handleCycle();

        var addVal = int.Parse(lineData.Split(' ')[1]); 
        xReg += addVal;
    }
    fr.Close();

    Console.WriteLine($"Day 10 part 1: {signalStrength}");
}

// Day 10 (second star answer)
{
    var fr = new StreamReader(File.Open("input-day10.txt", FileMode.Open));

    var cycles = 0;
    var xReg = 1;

    var lines = new string[6] { "", "", "", "", "", "" };

    void handleCycle()
    {
        var col = cycles % 40;
        var row = cycles / 40;
        lines[row] += xReg >= col - 1 && xReg <= col + 1 ? "#" : ".";
        cycles++;
    }

    while (!fr.EndOfStream)
    {
        var lineData = fr.ReadLine();
        handleCycle();

        if (lineData == "noop") continue;
        handleCycle();

        var addVal = int.Parse(lineData.Split(' ')[1]); 
        xReg += addVal;
    }
    fr.Close();

    Console.WriteLine("Day 10 part 2:");
    foreach (var line in lines)
    {
        Console.WriteLine(line);
    }
}

// Day 11 (first star answer)
{
    var fr = new StreamReader(File.Open("input-day11.txt", FileMode.Open));

    var monkeys = new Dictionary<int, MonkeyData>();

    while (!fr.EndOfStream)
    {
        var monkeyId = int.Parse(fr.ReadLine().Split(' ')[1].Replace(":", ""));
        var startingItems = fr.ReadLine().Trim().Replace("Starting items: ", "").Split(", ").Select(i => long.Parse(i)).ToList();
        var operation = fr.ReadLine().Trim().Replace("Operation: ", "").Split(" ").ToList();
        var operationOperator = operation[3];
        var operationValue = operation[4];
        var testDivisor = long.Parse(fr.ReadLine().Trim().Replace("Test: ", "").Split(" ").ToList()[2]);
        var trueMonkey = int.Parse(fr.ReadLine().Trim().Replace("If true: throw to monkey ", ""));
        var falseMonkey = int.Parse(fr.ReadLine().Trim().Replace("If false: throw to monkey ", ""));
        fr.ReadLine();
        
        monkeys.Add(monkeyId, new MonkeyData
        {
            items = startingItems,
            operation = operationOperator == "+" ? (x, y) => x + y : (x, y) => x * y,
            operationValue = operationValue,
            testDivisor = testDivisor,
            trueMonkey = trueMonkey,
            falseMonkey = falseMonkey,
        });
    }
    fr.Close();

    for (var round = 0; round < 20; round++)
    {
        foreach (var monkey in monkeys)
        {
            while (monkey.Value.items.Count > 0)
            {
                monkey.Value.inspections++;

                var inspectionItem = monkey.Value.items[0];
                monkey.Value.items.RemoveAt(0);

                inspectionItem = monkey.Value.operation(inspectionItem,
                    monkey.Value.operationValue == "old" ? inspectionItem : long.Parse(monkey.Value.operationValue));
                inspectionItem /= 3;
                if (inspectionItem % monkey.Value.testDivisor == 0)
                {
                    monkeys[monkey.Value.trueMonkey].items.Add(inspectionItem);
                }
                else
                {
                    monkeys[monkey.Value.falseMonkey].items.Add(inspectionItem);
                }
            }
        }
    }

    var answer = monkeys.OrderByDescending(m => m.Value.inspections).Take(2).Aggregate((long)1,
        (x, y) => x * y.Value.inspections);

    Console.WriteLine($"Day 11 part 1: {answer}");
}

// Day 11 (second star answer)
{
    var fr = new StreamReader(File.Open("input-day11.txt", FileMode.Open));

    var monkeys = new Dictionary<int, MonkeyData>();

    while (!fr.EndOfStream)
    {
        var monkeyId = int.Parse(fr.ReadLine().Split(' ')[1].Replace(":", ""));
        var startingItems = fr.ReadLine().Trim().Replace("Starting items: ", "").Split(", ").Select(i => long.Parse(i)).ToList();
        var operation = fr.ReadLine().Trim().Replace("Operation: ", "").Split(" ").ToList();
        var operationOperator = operation[3];
        var operationValue = operation[4];
        var testDivisor = long.Parse(fr.ReadLine().Trim().Replace("Test: ", "").Split(" ").ToList()[2]);
        var trueMonkey = int.Parse(fr.ReadLine().Trim().Replace("If true: throw to monkey ", ""));
        var falseMonkey = int.Parse(fr.ReadLine().Trim().Replace("If false: throw to monkey ", ""));
        fr.ReadLine();
        
        monkeys.Add(monkeyId, new MonkeyData
        {
            items = startingItems,
            operation = operationOperator == "+" ? (x, y) => x + y : (x, y) => x * y,
            operationValue = operationValue,
            testDivisor = testDivisor,
            trueMonkey = trueMonkey,
            falseMonkey = falseMonkey,
        });
    }
    fr.Close();

    //Working out how to manage the extremely large numbers was a fun one!
    //The only way to properly manage the number not getting too large is by multiplying all of the divisor test numbers
    //together (due to them all being prime numbers) and using that to modulo the final result.
    //(2 * 3 * 5 * 7 * 11 * 13 * 17 * 19) / (any one number that was previously multiplied) will be a whole number.
    //It acts the same as just taking that number out of the multiplication. It doesn't even matter that the test used
    //all prime numbers other than if we had already used a number that could be divided evenly by another number
    //already multiplied, we wouldn't need to also multiply by that number. For example, if we had already multiplied by
    //4, we wouldn't also need to multiply by 2 as 2 is already divisible by a number in the list, it's the equivalent
    //of (4 * 7 / 2) = (2 * 7). The opposite does not work, it has to be the larger number that is used.
    var modulo = monkeys.Aggregate((long)1, (x, y) => x * y.Value.testDivisor);

    for (var round = 0; round < 10000; round++)
    {
        foreach (var monkey in monkeys)
        {
            while (monkey.Value.items.Count > 0)
            {
                monkey.Value.inspections++;

                var inspectionItem = monkey.Value.items[0];
                monkey.Value.items.RemoveAt(0);

                inspectionItem = monkey.Value.operation(inspectionItem,
                    monkey.Value.operationValue == "old" ? inspectionItem : long.Parse(monkey.Value.operationValue));
                inspectionItem %= modulo;
                if (inspectionItem % monkey.Value.testDivisor == 0)
                {
                    monkeys[monkey.Value.trueMonkey].items.Add(inspectionItem);
                }
                else
                {
                    monkeys[monkey.Value.falseMonkey].items.Add(inspectionItem);
                }
            }
        }
    }

    var answer = monkeys.OrderByDescending(m => m.Value.inspections).Take(2).Aggregate((long)1,
        (x, y) => x * y.Value.inspections);

    Console.WriteLine($"Day 11 part 2: {answer}");
}

List<PathFinderCell> Day12GenerateCells(char[][] data)
{
    var cells = new List<PathFinderCell>();

    for (var y = 0; y < data.GetLength(0); y++)
    {
        for (var x = 0; x < data[0].Length; x++)
        {
            var cell = new PathFinderCell();
            cell.X = x;
            cell.Y = y;
            cell.Elevation = data[y][x] switch
            {
                'S' => 'a' - 1,
                'E' => 'z' + 1,
                _ => data[y][x]
            };
            cells.Add(cell);
        }
    }

    for (var y = 0; y < data.GetLength(0); y++)
    {
        for (var x = 0; x < data[0].Length; x++)
        {
            var currentCell = cells.Find(c => c.X == x && c.Y == y);

            var deltas = new List<(int x, int y)> { (-1, 0), (1, 0), (0, -1), (0, 1) };
            foreach (var delta in deltas)
            {
                var neighborX = x + delta.x;
                var neighborY = y + delta.y;
                if (neighborX < 0 || neighborX >= data[0].Length || neighborY < 0 ||
                    neighborY >= data.GetLength(0)) continue;

                var neighbor = cells.Find(c => c.X == neighborX && c.Y == neighborY);

                currentCell.Neighbors.Add(neighbor);
            }
        }
    }

    return cells;
}

List<PathFinderCell> Day12GetPath(List<PathFinderCell> cells, (int x, int y) startLocation, (int x, int y) exitLocation)
{
    var pathFinder = new PathFinder();
    var path = pathFinder.Search(cells, cells.Find(c => c.X == startLocation.x && c.Y == startLocation.y),
        cells.Find(c => c.X == exitLocation.x && c.Y == exitLocation.y));

    return path?.ToList();
}

void Day12OutputPath(char[][] data, List<PathFinderCell> path)
{
    for (int y = 0; y < data.GetLength(0); y++)
    {
        for (int x = 0; x < data[0].Length; x++)
        {
            if (path?.Find(c => c.X == x && c.Y == y) != null)
            {
                Console.BackgroundColor = ConsoleColor.Green;
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Gray;
            }

            Console.Write(data[y][x]);
        }
        Console.WriteLine();
    }
}

// Day 12 (first star answer)
{
    var fr = new StreamReader(File.Open("input-day12.txt", FileMode.Open));

    var data = fr.ReadToEnd().Split("\n", StringSplitOptions.RemoveEmptyEntries).Select(i => i.ToArray()).ToArray();

    fr.Close();

    (int x, int y) startLocation = (-1, -1);
    (int x, int y) exitLocation = (-1, -1);

    for (var y = 0; y < data.GetLength(0); y++)
    {
        for (var x = 0; x < data[0].Length; x++)
        {
            switch (data[y][x])
            {
                case 'S':
                    startLocation = (x, y);
                    break;
                case 'E':
                    exitLocation = (x, y);
                    break;
            }

            if (startLocation != (-1, -1) && exitLocation != (-1, -1)) break;
        }

        if (startLocation != (-1, -1) && exitLocation != (-1, -1)) break;
    }

    var cells = Day12GenerateCells(data);
    var path = Day12GetPath(cells, startLocation, exitLocation);
    // Day12OutputPath(data, path);

    Console.WriteLine($"Day 12 part 1: {path.Count}");
}

// Day 12 (second star answer)
{
    var fr = new StreamReader(File.Open("input-day12.txt", FileMode.Open));

    var data = fr.ReadToEnd().Split("\n", StringSplitOptions.RemoveEmptyEntries).Select(i => i.ToArray()).ToArray();

    fr.Close();

    var possibleStartLocations = new List<(int x, int y)>();
    (int x, int y) exitLocation = (-1, -1);

    for (var y = 0; y < data.GetLength(0); y++)
    {
        for (var x = 0; x < data[0].Length; x++)
        {
            switch (data[y][x])
            {
                case 'a':
                    if (x == 0)
                    {
                        possibleStartLocations.Add((x, y));
                    }
                    break;
                case 'E':
                    exitLocation = (x, y);
                    break;
            }
        }
    }

    var cells = Day12GenerateCells(data);
    List<PathFinderCell> path = null;
    foreach (var startLocation in possibleStartLocations)
    {
        foreach (var cell in cells)
        {
            cell.Distance = int.MaxValue;
        }
        var newPathOut = Day12GetPath(cells, startLocation, exitLocation);
        if (newPathOut != null && (path == null || newPathOut.Count < path.Count))
        {
            path = newPathOut;
        }
    }
    // Day12OutputPath(data, path);
    
    Console.WriteLine($"Day 12 part 2: {path.Count}");
}

int Day13PacketCompare(object left, object right)
{
    while (true)
    {
        switch (left)
        {
            case int lv when right is int rv:
                return lv - rv;
            case List<object> lv when right is int rv:
                left = lv;
                right = new List<object> { rv };
                continue;
            case int lv when right is List<object> rv:
                left = new List<object> { lv };
                right = rv;
                continue;
        }

        {
            var lv = left as List<object>;
            var rv = right as List<object>;
            if (lv.Count == 0 && rv.Count != 0) return -1;
            if (lv.Count != 0 && rv.Count == 0) return 1;
            if (lv.Count == 0 && rv.Count == 0) return 0;

            var itemCompare = Day13PacketCompare(lv[0], rv[0]);
            if (itemCompare != 0) return itemCompare;
            left = lv.Skip(1).ToList();
            right = rv.Skip(1).ToList();
        }
    }
}

//This is just to make things easier to pass to my comparison function. I couldn't otherwise figure out
//the code easily enough to pass part of an array on to the recursive call again as it was defined as a
//JsonArray or JsonElement. I tried several different ways but had problems so just created a function
//to convert it to an object.
object JsonToObject(JsonNode node)
{
    if (node is not JsonArray) return node.AsValue().GetValue<int>();
    return node.AsArray().Select(JsonToObject).ToList();
}

// Day 13 (first star answer)
{
    var fr = new StreamReader(File.Open("input-day13.txt", FileMode.Open));

    var index = 1;
    var total = 0;
    while (!fr.EndOfStream)
    {
        var data1 = fr.ReadLine();
        var data2 = fr.ReadLine();
        fr.ReadLine();

        var left = JsonToObject(JsonNode.Parse(data1));
        var right = JsonToObject(JsonNode.Parse(data2));

        if (Day13PacketCompare(left, right) < 0)
        {
            total += index;
        }
        
        index++;
    }

    fr.Close();


    Console.WriteLine($"Day 13 part 1: {total}");
}

// Day 13 (second star answer)
{
    var fr = new StreamReader(File.Open("input-day13.txt", FileMode.Open));

    var packets = new List<(string, object)>();

    while (!fr.EndOfStream)
    {
        var data = fr.ReadLine();
        if (data.Length == 0) continue;
        var dataPacket = JsonToObject(JsonNode.Parse(data));
        
        packets.Add((data, dataPacket));
    }

    fr.Close();

    var testPackets = new List<string> { "[[2]]", "[[6]]" };
    foreach (var testPacket in testPackets)
    {
        packets.Add((testPacket, JsonToObject(JsonNode.Parse(testPacket))));
    }
    
    packets.Sort((left, right) => (Day13PacketCompare(left.Item2, right.Item2)));

    var total = 1;
    foreach (var testPacket in testPackets)
    {
        total *= packets.FindIndex(p => p.Item1 == testPacket) + 1;
    }
    
    Console.WriteLine($"Day 13 part 2: {total}");
}

// Day 14 (first star answer)
{
    var fr = new StreamReader(File.Open("input-day14.txt", FileMode.Open));

    var linesGroups = new List<List<int[]>>();
    while (!fr.EndOfStream)
    {
        var data = fr.ReadLine();

        linesGroups.Add(data.Split(" -> ").Select(lp => lp.Split(",").Select(int.Parse).ToArray()).ToList());
    }

    fr.Close();


    var minX = linesGroups.SelectMany(i => i).Min(i => i[0]);
    var minY = 0;// linesGroups.SelectMany(i => i).Min(i => i[1]);
    var maxX = linesGroups.SelectMany(i => i).Max(i => i[0]);
    var maxY = linesGroups.SelectMany(i => i).Max(i => i[1]);
    
    var grid = new char[maxY-minY + 1, maxX-minX + 1];

    foreach (var lineGroup in linesGroups)
    {
        var startLine = lineGroup[0];
        foreach (var nextline in lineGroup.Skip(1))
        {
            var linePos = startLine;

            grid[startLine[1] - minY, startLine[0] - minX] = '#';

            while (linePos[0] != nextline[0] || linePos[1] != nextline[1])
            {
                linePos[0] += Math.Sign(nextline[0] - linePos[0]);
                linePos[1] += Math.Sign(nextline[1] - linePos[1]);

                grid[linePos[1] - minY, linePos[0] - minX] = '#';
            }
            
            startLine = nextline;
        }
    }

    var simulating = true;
    var resting_sand = 0;
    while (simulating)
    {
        var sandpoint = new[] { 500, minY };

        while (true)
        {
            if (sandpoint[1] >= maxY)
            {
                simulating = false;
                break;
            }

            if (grid[sandpoint[1] - minY + 1, sandpoint[0] - minX] == 0)
            {
                sandpoint[1]++;
            }
            else if (grid[sandpoint[1] - minY + 1, sandpoint[0] - minX - 1] == 0)
            {
                sandpoint[1]++;
                sandpoint[0]--;
            }
            else if (grid[sandpoint[1] - minY + 1, sandpoint[0] - minX + 1] == 0)
            {
                sandpoint[1]++;
                sandpoint[0]++;
            }
            else
            {
                resting_sand++;
                grid[sandpoint[1] - minY, sandpoint[0] - minX] = 'O';

                break;
            }
        }
    }

    // for (var y = 0; y < maxY - minY; y++)
    // {
    //     for (var x = 0; x < maxX - minX; x++)
    //     {
    //         if (grid[y, x] != 0)
    //         {
    //             Console.Write(grid[y,x]);
    //         }
    //         else
    //         {
    //             Console.Write(".");
    //         }
    //     }
    //     Console.WriteLine();
    // }

    Console.WriteLine($"Day 14 part 1: {resting_sand}");
}

// Day 14 (second star answer)
{
    var fr = new StreamReader(File.Open("input-day14.txt", FileMode.Open));

    var linesGroups = new List<List<int[]>>();
    while (!fr.EndOfStream)
    {
        var data = fr.ReadLine();

        linesGroups.Add(data.Split(" -> ").Select(lp => lp.Split(",").Select(int.Parse).ToArray()).ToList());
    }

    fr.Close();
    
    var maxY = linesGroups.SelectMany(i => i).Max(i => i[1]);
    
    var grid = new Dictionary<(int x, int y), char>();

    foreach (var lineGroup in linesGroups)
    {
        var startLine = lineGroup[0];
        foreach (var nextline in lineGroup.Skip(1))
        {
            var linePos = startLine;

            if (!grid.ContainsKey((startLine[0], startLine[1]))) grid.Add((startLine[0], startLine[1]), '#');

            while (linePos[0] != nextline[0] || linePos[1] != nextline[1])
            {
                linePos[0] += Math.Sign(nextline[0] - linePos[0]);
                linePos[1] += Math.Sign(nextline[1] - linePos[1]);

                if (!grid.ContainsKey((linePos[0], linePos[1]))) grid.Add((linePos[0], linePos[1]), '#');
            }
            
            startLine = nextline;
        }
    }

    var simulating = true;
    var resting_sand = 0;
    while (simulating)
    {
        var sandPoint = new[] { 500, 0 };
        
        if (grid.ContainsKey((sandPoint[0], sandPoint[1])))
        {
            simulating = false;
            break;
        }

        while (true)
        {
            if (sandPoint[1] > maxY)
            {
                resting_sand++;
                grid.Add((sandPoint[0], sandPoint[1]), 'O');
                break;
            }

            if (!grid.ContainsKey((sandPoint[0], sandPoint[1] + 1)))
            {
                sandPoint[1]++;
            }
            else if (!grid.ContainsKey((sandPoint[0] - 1, sandPoint[1] + 1)))
            {
                sandPoint[1]++;
                sandPoint[0]--;
            }
            else if (!grid.ContainsKey((sandPoint[0] + 1, sandPoint[1] + 1)))
            {
                sandPoint[1]++;
                sandPoint[0]++;
            }
            else
            {
                resting_sand++;
                grid.Add((sandPoint[0], sandPoint[1]), 'O');
                break;
            }
        }
    }

    // for (var y = 0; y < maxY - minY; y++)
    // {
    //     for (var x = 0; x < maxX - minX; x++)
    //     {
    //         if (grid[y, x] != 0)
    //         {
    //             Console.Write(grid[y,x]);
    //         }
    //         else
    //         {
    //             Console.Write(".");
    //         }
    //     }
    //     Console.WriteLine();
    // }
    
    Console.WriteLine($"Day 14 part 2: {resting_sand}");
}

// Day 15 (first star answer)
{
    var fr = new StreamReader(File.Open("input-day15.txt", FileMode.Open));

    var sensors = new List<(int x, int y)>();
    var beacons = new List<(int x, int y)>();
    var testPosition = 2000000;

    // var testData = (string[])("Sensor at x=2, y=18: closest beacon is at x=-2, y=15\n" +
    //     "Sensor at x=9, y=16: closest beacon is at x=10, y=16\n" +
    //     "Sensor at x=13, y=2: closest beacon is at x=15, y=3\n" +
    //     "Sensor at x=12, y=14: closest beacon is at x=10, y=16\n" +
    //     "Sensor at x=10, y=20: closest beacon is at x=10, y=16\n" +
    //     "Sensor at x=14, y=17: closest beacon is at x=10, y=16\n" +
    //     "Sensor at x=8, y=7: closest beacon is at x=2, y=10\n" +
    //     "Sensor at x=2, y=0: closest beacon is at x=2, y=10\n" +
    //     "Sensor at x=0, y=11: closest beacon is at x=2, y=10\n" +
    //     "Sensor at x=20, y=14: closest beacon is at x=25, y=17\n" +
    //     "Sensor at x=17, y=20: closest beacon is at x=21, y=22\n" +
    //     "Sensor at x=16, y=7: closest beacon is at x=15, y=3\n" +
    //     "Sensor at x=14, y=3: closest beacon is at x=15, y=3\n" +
    //     "Sensor at x=20, y=1: closest beacon is at x=15, y=3").Split("\n", StringSplitOptions.TrimEntries);
    while (!fr.EndOfStream)
    //foreach(var t in testData)
    {
       var data = fr.ReadLine();
       //var data = t;

       data = data.Replace("Sensor at x=", "");
       data = data.Replace(", y=", ",");
       data = data.Replace(" closest beacon is at x=", "");

       var sensorBeaconSplit = data.Split(":");
       var sensor = sensorBeaconSplit[0].Split(",").Select(int.Parse).ToArray();
       var beacon = sensorBeaconSplit[1].Split(",").Select(int.Parse).ToArray();

       sensors.Add((sensor[0], sensor[1]));
       beacons.Add((beacon[0], beacon[1]));
    }
    
    fr.Close();

    var ranges = new List<(int minX, int maxX)>();
    for (var i = 0; i < sensors.Count; i++)
    {
        // see if it can even get to y=testPosition
        // see how far on y=testPosition its x extents can be based on when it would hit a beacon elsewhere

        var sensor = sensors[i];
        var beacon = beacons[i];
        
        var maxX = Math.Abs(beacon.x - sensor.x);
        var maxY = Math.Abs(beacon.y - sensor.y);

        var distanceToTest = Math.Abs(testPosition - sensor.y);

        if (distanceToTest < maxX + maxY)
        {
            var range = (maxX + maxY) - distanceToTest;

            var minRangeX = sensor.x - range;
            var maxRangeX = sensor.x + range;
            ranges.Add((minRangeX, maxRangeX));
        }
    }

    ranges = ranges.OrderBy(i => i.minX).ToList();
    
    var total = ranges[0].maxX - ranges[0].minX;
    var lastMaxX = ranges[0].maxX;
    foreach (var range in ranges.Skip(1))
    {
        if (range.maxX < lastMaxX)
        {
            continue;
        }

        if (range.minX > lastMaxX)
        {
            lastMaxX = range.minX;
        }

        total += range.maxX - lastMaxX;
        lastMaxX = range.maxX;
    }
    
    Console.WriteLine($"Day 15 part 1: {total}");
}

// Day 15 (second star answer)
{
    var fr = new StreamReader(File.Open("input-day15.txt", FileMode.Open));

    var sensors = new List<(int x, int y)>();
    var beacons = new List<(int x, int y)>();
    var maxXY = 4000000;

    // var testData = (string[])("Sensor at x=2, y=18: closest beacon is at x=-2, y=15\n" +
    //     "Sensor at x=9, y=16: closest beacon is at x=10, y=16\n" +
    //     "Sensor at x=13, y=2: closest beacon is at x=15, y=3\n" +
    //     "Sensor at x=12, y=14: closest beacon is at x=10, y=16\n" +
    //     "Sensor at x=10, y=20: closest beacon is at x=10, y=16\n" +
    //     "Sensor at x=14, y=17: closest beacon is at x=10, y=16\n" +
    //     "Sensor at x=8, y=7: closest beacon is at x=2, y=10\n" +
    //     "Sensor at x=2, y=0: closest beacon is at x=2, y=10\n" +
    //     "Sensor at x=0, y=11: closest beacon is at x=2, y=10\n" +
    //     "Sensor at x=20, y=14: closest beacon is at x=25, y=17\n" +
    //     "Sensor at x=17, y=20: closest beacon is at x=21, y=22\n" +
    //     "Sensor at x=16, y=7: closest beacon is at x=15, y=3\n" +
    //     "Sensor at x=14, y=3: closest beacon is at x=15, y=3\n" +
    //     "Sensor at x=20, y=1: closest beacon is at x=15, y=3").Split("\n", StringSplitOptions.TrimEntries);
    while (!fr.EndOfStream)
    // foreach(var t in testData)
    {
       var data = fr.ReadLine();
       // var data = t;

       data = data.Replace("Sensor at x=", "");
       data = data.Replace(", y=", ",");
       data = data.Replace(" closest beacon is at x=", "");

       var sensorBeaconSplit = data.Split(":");
       var sensor = sensorBeaconSplit[0].Split(",").Select(int.Parse).ToArray();
       var beacon = sensorBeaconSplit[1].Split(",").Select(int.Parse).ToArray();

       sensors.Add((sensor[0], sensor[1]));
       beacons.Add((beacon[0], beacon[1]));
    }
        
    fr.Close();
    
    long total = -1;
    for (var testY = 0; testY <= maxXY; testY++)
    {
        var ranges = new List<(int minX, int maxX)>();
        for (var i = 0; i < sensors.Count; i++)
        {
            // see if it can even get to y=testPosition
            // see how far on y=testPosition its x extents can be based on when it would hit a beacon elsewhere

            var sensor = sensors[i];
            var beacon = beacons[i];

            var maxX = Math.Abs(beacon.x - sensor.x);
            var maxY = Math.Abs(beacon.y - sensor.y);

            var distanceToTest = Math.Abs(testY - sensor.y);

            if (distanceToTest < maxX + maxY)
            {
                var range = (maxX + maxY) - distanceToTest;

                var minRangeX = sensor.x - range;
                var maxRangeX = sensor.x + range;
                ranges.Add((minRangeX, maxRangeX));
            }
        }

        ranges = ranges.OrderBy(r => r.minX).ToList();
        var lastMaxX = ranges[0].maxX;
        foreach (var range in ranges.Skip(1))
        {
            if (range.minX > 0 && range.minX <= maxXY && range.minX == lastMaxX + 2)
            {
                long missingX = range.minX - 1;
                total = missingX * maxXY + testY;
                break;
            }

            lastMaxX = Math.Max(range.maxX, lastMaxX);
        }
        
        if (total != -1)
        {
            break;
        }
    }
    
    Console.WriteLine($"Day 15 part 2: {total}");
}

// Day 16 (first star answer)
{
    var testData = (string[])("Valve AA has flow rate=0; tunnels lead to valves DD, II, BB\n" +
                              "Valve BB has flow rate=13; tunnels lead to valves CC, AA\n" +
                              "Valve CC has flow rate=2; tunnels lead to valves DD, BB\n" +
                              "Valve DD has flow rate=20; tunnels lead to valves CC, AA, EE\n" +
                              "Valve EE has flow rate=3; tunnels lead to valves FF, DD\n" +
                              "Valve FF has flow rate=0; tunnels lead to valves EE, GG\n" +
                              "Valve GG has flow rate=0; tunnels lead to valves FF, HH\n" +
                              "Valve HH has flow rate=22; tunnel leads to valve GG\n" +
                              "Valve II has flow rate=0; tunnels lead to valves AA, JJ\n" +
                              "Valve JJ has flow rate=21; tunnel leads to valve II\n").Split("\n", StringSplitOptions.RemoveEmptyEntries);
    // var fr = new StreamReader(File.Open("input-day16.txt", FileMode.Open));

    var valves = new List<Valve>();
    // while (!fr.EndOfStream)
    foreach (var line in testData)
    {
        // var data = fr.ReadLine();
        var data = line
            .Replace(", ", ",")
            .Replace("Valve ", "")
            .Replace(" has flow rate=", ",")
            .Replace("; tunnel leads to valve", "")
            .Replace("; tunnels lead to valves", "");

        var splitData = data.Split(" ");
        var lineDetail = splitData[0].Split(",");
        var lineValves = splitData[1].Split(",");
        valves.Add(new Valve
        {
            valve = lineDetail[0],
            flow = int.Parse(lineDetail[1]),
            destinations = lineValves.ToList()
        });
    }
    // fr.Close();

    foreach (var valve in valves)
    {
        valve.valves.AddRange(valve.destinations.Select(d => valves.Find(v => v.valve == d)).ToList());
    }

    var valveAA = valves.Find(i => i.valve == "AA");
    
    
    
    Console.WriteLine($"Day 16 part 1: {0}");
}

// Day 16 (second star answer)
{
    var fr = new StreamReader(File.Open("input-day16.txt", FileMode.Open));

    while (!fr.EndOfStream)
    {
        var data = fr.ReadLine();

    }

    fr.Close();
    
    Console.WriteLine($"Day 16 part 2: {0}");
}

long rockFallSimulation(char[] jets, long height)
{
    var rocks = new List<List<string>>
    {
        new()
        {
            "####",
        },
        new()
        {
            ".#",
            "###",
            ".#",
        },
        new()
        {
            "..#",
            "..#",
            "###",
        },
        new()
        {
            "#",
            "#",
            "#",
            "#",
        },
        new()
        {
            "##",
            "##",
        },
    };

    var pit = new List<string>();

    var jetIndex = 0;
    long extraY = 0;
    for (var rockIndex = 0; rockIndex < height; rockIndex++)
    {
        var fallingRockIndex = rockIndex % rocks.Count;
        var rockX = 2;
        var rockWidth = rocks[fallingRockIndex].Select(r => r.Length).Max();
        var rockY = pit.Count + 3;

        //Simulate rock falling
        var rock = rocks[fallingRockIndex].ToList();
        rock.Reverse();

        var resting = false;
        while (!resting)
        {
            var jetLeft = jets[jetIndex] == '<';
            jetIndex = (jetIndex + 1) % jets.Length;

            //Move on X
            if (jetLeft)
            {
                var collided = rockX == 0;
                if (!collided && rockY < pit.Count)
                {
                    for (var rockLineIndex = 0;
                         rockLineIndex < rock.Count && rockY + rockLineIndex < pit.Count;
                         rockLineIndex++)
                    {
                        var leftSide = rockX + rock[rockLineIndex].IndexOf("#", StringComparison.Ordinal);
                        if (pit[rockY + rockLineIndex][leftSide - 1] != '.')
                        {
                            collided = true;
                            break;
                        }
                    }
                }
                if (!collided)
                {
                    rockX--;
                }
            }
            else
            {
                var collided = rockX + rockWidth > 6;
                if (!collided && rockY < pit.Count)
                {
                    for (var rockLineIndex = 0;
                         rockLineIndex < rock.Count && rockY + rockLineIndex < pit.Count;
                         rockLineIndex++)
                    {
                        var rightSide = rockX + rock[rockLineIndex].LastIndexOf("#", StringComparison.Ordinal);
                        if (pit[rockY + rockLineIndex][rightSide + 1] != '.')
                        {
                            collided = true;
                            break;
                        }
                    }
                }
                if (!collided)
                {
                    rockX++;
                }
            }

            //Move on Y (rest if cannot move)
            if (rockY == 0)
            {
                resting = true;
            }
            if (!resting && rockY <= pit.Count)
            {
                for (var rockLineIndex = 0;
                     rockLineIndex < rock.Count && rockY + rockLineIndex <= pit.Count;
                     rockLineIndex++)
                {
                    for (var rockLineX = 0; rockLineX < rock[rockLineIndex].Length; rockLineX++)
                    {
                        if (rock[rockLineIndex][rockLineX] == '#')
                        {
                            if (pit[rockY + rockLineIndex - 1][rockX + rockLineX] != '.')
                            {
                                resting = true;
                                break;
                            }
                        }
                    }
                    if (resting)
                    {
                        break;
                    }
                }
            }

            if (!resting)
            {
                rockY--;
            }
            else
            {
                for (var rockLineIndex = 0;
                     rockLineIndex < rock.Count;
                     rockLineIndex++)
                {
                    if (pit.Count <= rockY + rockLineIndex)
                    {
                        pit.Add(".......");
                    }

                    if (pit.Count > 200)
                    {
                        extraY += 100;
                        rockY -= 100;
                        pit = pit.Skip(100).ToList();
                    }

                    //Edit the line
                    for (var x = 0; x < rock[rockLineIndex].Length; x++)
                    {
                        if (rock[rockLineIndex][x] == '#')
                        {
                            pit[rockY + rockLineIndex] = pit[rockY + rockLineIndex].Substring(0, rockX + x) + (char)(fallingRockIndex + '1') + pit[rockY + rockLineIndex].Substring(rockX + x + 1);
                        }
                    }
                }
            }
        }
    }

    return extraY + pit.Count;
}
// Day 17 (first star answer)
{
    var fr = new StreamReader(File.Open("input-day17.txt", FileMode.Open));

    var jets = ">>><<><>><<<>><>>><<<>>><<<><<<>><>><<>>".ToCharArray();
    // while (!fr.EndOfStream)
    // {
    //     var data = fr.ReadLine();
    //     jets = data.ToCharArray();
    // }

    fr.Close();

    var total = rockFallSimulation(jets, 2022);
    
    Console.WriteLine($"Day 17 part 1: {total}");
}

// Day 17 (second star answer)
{
    var fr = new StreamReader(File.Open("input-day17.txt", FileMode.Open));

    var jets = ">>><<><>><<<>><>>><<<>>><<<><<<>><>><<>>".ToCharArray();
    // while (!fr.EndOfStream)
    // {
    //     var data = fr.ReadLine();
    //     jets = data.ToCharArray();
    // }

    fr.Close();

    //Obviously this won't work. 1 trillion iterations would take forever and use a lot of memory.
    //How could the algorithm be improved?
    // var total = rockFallSimulation(jets, 1000000000000);
    
    Console.WriteLine($"Day 17 part 2: {0}");
}

// Day 18 (first star answer)
{
    var fr = new StreamReader(File.Open("input-day18.txt", FileMode.Open));

    while (!fr.EndOfStream)
    {
        var data = fr.ReadLine();

    }

    fr.Close();

    Console.WriteLine($"Day 18 part 1: {0}");
}

// Day 18 (second star answer)
{
    var fr = new StreamReader(File.Open("input-day18.txt", FileMode.Open));

    while (!fr.EndOfStream)
    {
        var data = fr.ReadLine();

    }

    fr.Close();
    
    Console.WriteLine($"Day 18 part 2: {0}");
}

// Day 19 (first star answer)
{
    var fr = new StreamReader(File.Open("input-day19.txt", FileMode.Open));

    while (!fr.EndOfStream)
    {
        var data = fr.ReadLine();

    }

    fr.Close();

    Console.WriteLine($"Day 19 part 1: {0}");
}

// Day 19 (second star answer)
{
    var fr = new StreamReader(File.Open("input-day19.txt", FileMode.Open));

    while (!fr.EndOfStream)
    {
        var data = fr.ReadLine();

    }

    fr.Close();
    
    Console.WriteLine($"Day 19 part 2: {0}");
}

// Day 20 (first star answer)
{
    var fr = new StreamReader(File.Open("input-day20.txt", FileMode.Open));

    while (!fr.EndOfStream)
    {
        var data = fr.ReadLine();

    }

    fr.Close();

    Console.WriteLine($"Day 20 part 1: {0}");
}

// Day 20 (second star answer)
{
    var fr = new StreamReader(File.Open("input-day20.txt", FileMode.Open));

    while (!fr.EndOfStream)
    {
        var data = fr.ReadLine();

    }

    fr.Close();
    
    Console.WriteLine($"Day 20 part 2: {0}");
}

// Day 21 (first star answer)
{
    var fr = new StreamReader(File.Open("input-day21.txt", FileMode.Open));

    while (!fr.EndOfStream)
    {
        var data = fr.ReadLine();

    }

    fr.Close();

    Console.WriteLine($"Day 21 part 1: {0}");
}

// Day 21 (second star answer)
{
    var fr = new StreamReader(File.Open("input-day21.txt", FileMode.Open));

    while (!fr.EndOfStream)
    {
        var data = fr.ReadLine();

    }

    fr.Close();
    
    Console.WriteLine($"Day 21 part 2: {0}");
}

// Day 22 (first star answer)
{
    var fr = new StreamReader(File.Open("input-day22.txt", FileMode.Open));

    while (!fr.EndOfStream)
    {
        var data = fr.ReadLine();

    }

    fr.Close();

    Console.WriteLine($"Day 22 part 1: {0}");
}

// Day 22 (second star answer)
{
    var fr = new StreamReader(File.Open("input-day22.txt", FileMode.Open));

    while (!fr.EndOfStream)
    {
        var data = fr.ReadLine();

    }

    fr.Close();
    
    Console.WriteLine($"Day 22 part 2: {0}");
}

// Day 23 (first star answer)
{
    var fr = new StreamReader(File.Open("input-day23.txt", FileMode.Open));

    while (!fr.EndOfStream)
    {
        var data = fr.ReadLine();

    }

    fr.Close();

    Console.WriteLine($"Day 23 part 1: {0}");
}

// Day 23 (second star answer)
{
    var fr = new StreamReader(File.Open("input-day23.txt", FileMode.Open));

    while (!fr.EndOfStream)
    {
        var data = fr.ReadLine();

    }

    fr.Close();
    
    Console.WriteLine($"Day 23 part 2: {0}");
}

// Day 24 (first star answer)
{
    var fr = new StreamReader(File.Open("input-day24.txt", FileMode.Open));

    while (!fr.EndOfStream)
    {
        var data = fr.ReadLine();

    }

    fr.Close();

    Console.WriteLine($"Day 24 part 1: {0}");
}

// Day 24 (second star answer)
{
    var fr = new StreamReader(File.Open("input-day24.txt", FileMode.Open));

    while (!fr.EndOfStream)
    {
        var data = fr.ReadLine();

    }

    fr.Close();
    
    Console.WriteLine($"Day 24 part 2: {0}");
}

// Day 25 (first star answer)
{
    var fr = new StreamReader(File.Open("input-day25.txt", FileMode.Open));

    while (!fr.EndOfStream)
    {
        var data = fr.ReadLine();

    }

    fr.Close();

    Console.WriteLine($"Day 25 part 1: {0}");
}

// Day 25 (second star answer)
{
    var fr = new StreamReader(File.Open("input-day25.txt", FileMode.Open));

    while (!fr.EndOfStream)
    {
        var data = fr.ReadLine();

    }

    fr.Close();
    
    Console.WriteLine($"Day 25 part 2: {0}");
}

Console.WriteLine("End of program");