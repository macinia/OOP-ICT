using OOP_ICT.Models;
using OOP_ICT.Third;

namespace OOP_ICT.Fourth;

public class PokerGame
{
    private readonly List<PokerPlayer> _players = new();
    public List<PokerPlayer> Players => _players;
    private  PokerDealer _dealer = new(new PerfectShuffle());
    private Hand _board = new(); 
    private int _currentCall = 0;
    public decimal Pot;

    private const int StartPokerCardsCount = 2;
    private const int FlopCardsCount = 3;
    private const int TurnCardsCount = 1;
    private const int RiverCardsCount = 1;
    
    public void AddPlayerToTable(PokerPlayer player)
    {
        if (player is null) throw new NullPlayerException("Player is null");
        _players.Add(player);
    }

    public void StartGame(int bigBlind, int smallBlind, int dealerPos)
    {
        _players[dealerPos].Status = PlayerStatus.Dealer;
        var hands = _players.Where(player => player.Status != PlayerStatus.Dealer).Select(player => player.Hand).ToList();
        _players[(dealerPos + 1) % _players.Count].Blind(smallBlind);
        _players[(dealerPos + 2) % _players.Count].Blind(bigBlind);
        _dealer.DealCards(hands, StartPokerCardsCount);
    }
    
    public void Flop()
    {
        _dealer.DealCards(new List<Hand> {_board}, FlopCardsCount);
    }

    public void Turn()
    {
        _dealer.DealCards(new List<Hand> {_board}, TurnCardsCount);
    }
    
    public void River()
    {
        _dealer.DealCards(new List<Hand> {_board}, RiverCardsCount);
    }

    public (List<PokerPlayer> winners, List<PokerPlayer> losers) ShowDown()
    {
        PotScore();
        var playersCombinations = new List<(PokerPlayer, PokerCombination)>();
        var winners = new List<PokerPlayer>();
        var losers = new List<PokerPlayer>();
        var combinationFinder = new FindPokerCombination();

        foreach (var player in _players)
        {
            if (player.Status is PlayerStatus.Active or PlayerStatus.AllIn)
            {
                var cards = player.Hand.GetHand().Concat(_board.GetHand()).ToList();
                playersCombinations.Add((player, combinationFinder.DetectCombination(cards)));
            }
            else if (player.Status is not PlayerStatus.Dealer)
            {
                losers.Add(player);
            }
        }
        
        playersCombinations.Sort(
            (firstPlayer,secondPlayer) => 
                secondPlayer.Item2.CompareTo(firstPlayer.Item2)
        );
        var highestCombination = playersCombinations[0].Item2;
        foreach (var (player, combination) in playersCombinations)
        {
            if (combination == highestCombination)
            {
                winners.Add(player);
            }
            else
            {
                losers.Add(player);
            }
        }
        return (winners, losers);
    }

    public void ClaimBet (PokerBank bank, PokerPlayer player)
    {
        if (player is null) throw new NullPlayerException("Player is null");
        bank.CheckMoney(player.BankAccount, player.PlayerPot);
    }

    private void PotScore()
    {
        foreach (var player in _players)
        {
            Pot += player.PlayerPot;
        }
    }
}