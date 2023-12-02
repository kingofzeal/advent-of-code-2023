// See https://aka.ms/new-console-template for more information
var input = File.ReadAllLines("./input.txt");

void Part1(){
    var numbers = new[]{'0', '1', '2', '3', '4', '5', '6', '7', '8', '9'};
    var result = 0;

    foreach (var line in input){
        var first = line.IndexOfAny(numbers);
        var last = line.LastIndexOfAny(numbers);

        // Console.WriteLine($"{line} {line[first]} {line[last]}");

        result += int.Parse(line[first].ToString()) * 10;
        result += int.Parse(line[last].ToString());
    }

    Console.WriteLine($"Part 1: {result}");
}

void Part2(){
    var numbers = new[]{'0', '1', '2', '3', '4', '5', '6', '7', '8', '9'};
    var words = new[]{"zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine"};
    var result = 0;

    foreach(var line in input){
        var first = line.IndexOfAny(numbers);
        var last = line.LastIndexOfAny(numbers);

        var firstVal = first > -1 ? int.Parse(line[first].ToString()) : 0;
        var lastVal = last > -1 ? int.Parse(line[last].ToString()) : 0;

        if (first != 0 || last < line.Length){
            foreach(var word in words){
                var wordIndex = line.IndexOf(word);

                if (wordIndex == -1){
                    continue;
                }

                if (first == -1 || wordIndex < first){
                    first = wordIndex;
                    firstVal = Array.IndexOf(words, word);
                }

                wordIndex = line.LastIndexOf(word);

                if (wordIndex > last){
                    last = wordIndex;
                    lastVal = Array.IndexOf(words, word);
                }
            }
        }

        // Console.WriteLine($"{line} {firstVal} {lastVal}");
        
        result += firstVal * 10;
        result += lastVal;
    }

    Console.WriteLine($"Part 2: {result}");
}

Part1();
Part2();