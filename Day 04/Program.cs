using System.Linq;
using System.Collections.Generic;

var input = File.ReadAllLines("./input.txt");

void Part1(){
    var total = 0;

    foreach (var line in input){
        var winners = line[(line.IndexOf(':') + 1)..line.IndexOf('|')].Split(' ', StringSplitOptions.RemoveEmptyEntries);
        var card = line[(line.IndexOf('|') + 1)..].Split(' ', StringSplitOptions.RemoveEmptyEntries);

        var numWinners = winners.Intersect(card).Count();

        if (numWinners == 0){
            continue;
        }

        var currentScore = 1 << (numWinners - 1);

        total += currentScore;
    }

    Console.WriteLine($"Part 1: {total}");
}

void Part2(){
    var previous = new Dictionary<int, int>();

    int calculateCards(int cardNum){
        if (previous.ContainsKey(cardNum)){
            return previous[cardNum];
        }

        var line = input[cardNum - 1];

        var winners = line[(line.IndexOf(':') + 1)..line.IndexOf('|')].Split(' ', StringSplitOptions.RemoveEmptyEntries);
        var card = line[(line.IndexOf('|') + 1)..].Split(' ', StringSplitOptions.RemoveEmptyEntries);

        var numWinners = winners.Intersect(card).Count();

        var result = Enumerable.Range((cardNum + 1), numWinners).Select(calculateCards).Sum() + numWinners;

        previous.Add(cardNum, result);

        return result;
    }

    var result = Enumerable.Range(1, input.Length).Select(calculateCards).Sum() + input.Length;

    Console.WriteLine($"Part 2: {result}");
}

Part1();
Part2();
