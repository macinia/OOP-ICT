using System.Collections;
using System.Collections.Specialized;
using OOP_ICT.Fourth.Models;
using OOP_ICT.Models;

namespace OOP_ICT.Fifth.game;

public class Game
{
    private CardDeck deck = new();
    private Casino _casino = new();
    private DealerDecorator _dealer;
    public PokerBank Bank = new();
    public PokerGame PokerGame;
    private IInputOutput _inputOutput = new();
    private Dictionary<PokerPlayer, string> Players;
    private OrderedDictionary orderedPlayers;
    private StatisticsWritter StatisticsWritter = new();

    public Game()
    {
        _dealer = new DealerDecorator(deck);
        PokerGame = new PokerGame(_dealer, _casino, Bank);
    }

    public void CountPlayers()
    {
        _inputOutput.Hi();
        Players = new Dictionary<PokerPlayer, string>();
        orderedPlayers = new OrderedDictionary();
        var CountPlayers = _inputOutput.CountPlayers();
        if (CountPlayers < 3)
        {
            CountPlayers = _inputOutput.FewPlayers();
        }
        for (var i = 1; i <= CountPlayers; i++)
        {
            var name = _inputOutput.EnteringName(Players);
            var player = new PokerPlayer(PokerGame.Bank);
            PokerGame.JoinGame(player);
            Players.Add(player, name);
        }

        PokerGame.Bets.Clear();
        FullGame();
    }

    public void FullGame()
    {
        orderedPlayers.Clear();
        PokerGame.Bets.Clear();
        deck = new CardDeck();
        _dealer = new DealerDecorator(deck);
        _casino = new Casino();
        PokerGame = new PokerGame(_dealer, _casino, Bank);
        foreach (var player in Players)
        {
            if (!PokerGame.Team.Contains(player.Key))
            {
                PokerGame.JoinGame(player.Key);
            }
        }

        PokerGame.StartGame();
        var nameSmallBlind = "";
        var nameBigBlind = "";

        foreach (var player in Players)
        {
            if (player.Key == PokerGame.CurrentBigBlind)
            {
                nameBigBlind = player.Value;
            }

            if (player.Key == PokerGame.CurrentSmallBlind)
            {
                nameSmallBlind = player.Value;
            }
        }

        _inputOutput.PresentationParticipants(nameSmallBlind, nameBigBlind, Players.Values.First());


        orderedPlayers.Add(PokerGame.CurrentSmallBlind, nameSmallBlind);
        orderedPlayers.Add(PokerGame.CurrentBigBlind, nameBigBlind);
        foreach (var player in Players)
        {
            if (player.Value != nameSmallBlind && player.Value != nameBigBlind)
            {
                orderedPlayers.Add(player.Key, player.Value);
            }
        }

        PokerGame.OpenThreeCards();
        _inputOutput.PresentCardsInTheTable(PokerGame.CardsInTheTable);

        foreach (var player in orderedPlayers.Keys)
        {
            var playerObject = (PokerPlayer)player;
            _inputOutput.PresentCardsInTheHand((string)orderedPlayers[playerObject], playerObject.GetCardsInTheHand());
        }


        MakeBets();
        PokerGame.OpenOneCard();
        _inputOutput.PresentCardsInTheTable(PokerGame.CardsInTheTable);
        MakeBets();
        PokerGame.OpenOneCard();
        _inputOutput.PresentCardsInTheTable(PokerGame.CardsInTheTable);
        MakeBets();
        PokerGame.Combinations();
        var winner = PokerGame.FindWinner();
        var winnerName = Players[winner];
        _inputOutput.Winner(winnerName);
        PokerGame.DistributionMoney();
        StatisticsWritter.SaveGames(Players, (int)PokerGame.Bets.Values.Sum(x => x));
        StatisticsWritter.SavePlayers(Players);
        StatisticsWritter.UpdateWinsAndLoses(winnerName);
        if (_inputOutput.PlayAgain())
        {
            if (_inputOutput.ClarifyCompositionTeam())
            {
                orderedPlayers.Clear();
                Players.Clear();
                CountPlayers();
            }
            else
            {
                FullGame();
            }
        }
        else
        {
            _inputOutput.Farewell();
        }
    }

    private bool CheckIfPlayerInTeam(PokerPlayer player)
    {
        try
        {
            PokerGame.CheckPlayerInTeam(player);
        }
        catch (YouAreNotAMemberOfTheTeamException)
        {
            return false;
        }

        return true;
    }

    public void MakeBets()
    {
        var bets = PokerGame.Bets;
        foreach (var player in orderedPlayers)
        {
            var playerEntry = (DictionaryEntry)player;
            var playerObject = (PokerPlayer)playerEntry.Key;
            if (!CheckIfPlayerInTeam(playerObject)) continue;
            
            var playerName = (string)playerEntry.Value;
            var bet = _inputOutput.EnteringBet(playerName, playerObject.CasinoBalance);
            if (bet == -1)
            {
                PokerGame.RemovePlayer(playerObject);
                continue;
            }

            PokerGame.ChooseSizeOfTheBet(playerObject, (uint)bet);
        }

        var someBet = 0u; 
        foreach (var bet in bets)
        {
            if (!CheckIfPlayerInTeam(bet.Key)) continue;
            if (someBet == 0u) someBet = bet.Value;
            if (someBet == bet.Value) continue;
            
            _inputOutput.BetsNotEqual();
            MakeBets();

        }
    }
}