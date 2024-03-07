using OOP_ICT.Fourth.Models;

namespace OOP_ICT.Fifth.game;

using System;
using System.Text.Json;

public class StatisticsWritter
{
    public string fileNamePlayers = "PlayersStatistics.json";
    public string fileNameGames = "GamesStatistics.json";
    
    public void SavePlayers(IDictionary<PokerPlayer, string> players)
    {
        var existPlayers = ReadPlayersFromFile(fileNamePlayers);
        var startIndex = existPlayers.Count > 0 ? existPlayers.Max(x => x.Id) + 1 : 1;
        foreach (var player in players)
        {
            string playerName = player.Value;

            if (!existPlayers.Select(x => x.Name).Contains(playerName))
            {
                var playerToJson = new JsonPlayer { Id = startIndex, Name = playerName };
                startIndex++;
                
                existPlayers.Add(playerToJson);
            }
        }
        SavePlayersList(existPlayers);
    }

    private void SavePlayersList(List<JsonPlayer> players)
    {
        var json = JsonSerializer.Serialize(players);
        File.WriteAllText(fileNamePlayers, json);
    }

    public void UpdateWinsAndLoses(string name)
    {
        var players = ReadPlayersFromFile(fileNamePlayers);

        var Winner = players.Find(player => player.Name == name);

        if (Winner != null)
        {
            Winner.CountOfWins++;
            Winner.CountOfGames++;

            foreach (var player in players)
            {
                if (player != Winner)
                {
                    player.CountOfLooses++;
                    player.CountOfGames++;
                }
            }

            SavePlayersList(players);
        }
    }

    static List<JsonPlayer> ReadPlayersFromFile(string fileNamePlayers)
    {
        if (!File.Exists(fileNamePlayers)) return new List<JsonPlayer>();

        var json = File.ReadAllText(fileNamePlayers);
        return json.Length == 0 ? new List<JsonPlayer>() : JsonSerializer.Deserialize<List<JsonPlayer>>(json);
    }
    
    public void SaveGames(IDictionary<PokerPlayer, string> players, int benefit)
    {
        var existGames = ReadGamesFromFile(fileNameGames);
        var index = existGames.Count > 0 ? existGames.Max(x => x.Id) + 1 : 1;
        var WinnerOfTheGame = "";
        foreach (var player in players)
        {
            if (player.Key.WinningState is Winner)
            {
                WinnerOfTheGame = player.Value;
            }
        }

        var gameToJson = new JsonGame
            { Id = index, CountOfPlayers = players.Count, Winner = WinnerOfTheGame, AmountOfMoney = benefit };
        existGames.Add(gameToJson);
        SaveGamesToJson(existGames);
    }

    private void SaveGamesToJson(List<JsonGame> game)
    {
        var json = JsonSerializer.Serialize(game);
        File.WriteAllText(fileNameGames, json);
    }

    static List<JsonGame> ReadGamesFromFile(string fileNameGames)
    {
        if (!File.Exists(fileNameGames)) return new List<JsonGame>();

        var json = File.ReadAllText(fileNameGames);
        return json.Length == 0 ? new List<JsonGame>() : JsonSerializer.Deserialize<List<JsonGame>>(json);
    }
    
}
