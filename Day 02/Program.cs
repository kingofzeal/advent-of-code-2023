using System.Collections.Generic;
using System.Linq;

// See https://aka.ms/new-console-template for more information
var input = File.ReadAllLines("./input.txt");

var games = new List<Game>();

foreach (var line in input){
    var game = new Game();
    var gameSpace = line.IndexOf(' ') + 1;
    var gameId = line.IndexOf(':');

    game.Id = int.Parse(line[gameSpace..gameId]);

    var reveals = line.Split(';', ':')[1..];

    foreach (var reveal in reveals){
        var results = reveal.Split(',');

        var gameReveal = new Reveal();

        foreach (var result in results){
            var tokens = result.Split(' ');

            switch (tokens[2]){
                case "red": gameReveal.Red = int.Parse(tokens[1]); break;
                case "blue": gameReveal.Blue = int.Parse(tokens[1]); break;
                case "green": gameReveal.Green = int.Parse(tokens[1]); break;
            }
        }

        Console.WriteLine($"{reveal}: {gameReveal.Red}, {gameReveal.Blue}, {gameReveal.Green}");
        game.Reveals.Add(gameReveal);
    }

    games.Add(game);
}

void Part1(){
    var redLimit = 12;
    var greenLimit = 13;
    var blueLimit = 14;

    var sum = games.Where(x => x.Reveals.All(y => y.Red <= redLimit && y.Green <= greenLimit && y.Blue <= blueLimit)).Select(x => x.Id).Sum();

    Console.WriteLine($"Part 1: {sum}");
}

void Part2(){
    var res = games.Select(x => (x, red: x.Reveals.Max(y => y.Red), blue: x.Reveals.Max(y => y.Blue), green: x.Reveals.Max(y => y.Green)));

    foreach(var game in res){
        Console.WriteLine(game);
    }

    var sum = res.Select(x => x.red * x.blue * x.green).Sum();

    Console.WriteLine($"Part 2: {sum}");
}

Part1();
Part2();

class Game{
    public int Id { get; set; }
    public List<Reveal> Reveals { get; set; } = new();
}

class Reveal{
    public int Red { get; set; }
    public int Blue { get; set; }
    public int Green { get; set; }
}
