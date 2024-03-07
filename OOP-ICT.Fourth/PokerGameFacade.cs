namespace OOP_ICT.Fourth;

public class PokerGameFacade
{
    private readonly PokerGame _game;
    private readonly PokerBank _pokerBank;

    public PokerGameFacade(PokerGame game, PokerBank pokerBank)
    {
        _game = game;
        _pokerBank = pokerBank;
    }
    
    public void PreGame(List<PokerPlayer> players)
    {
        foreach (var player in players)
        {
            _game.AddPlayerToTable(player);
        }
    }

    public void Game(int smallBlind, int bigBlind, int dealerPos)
    {
        _game.StartGame(bigBlind, smallBlind, dealerPos);
        Trading();
        _game.Flop();
        Trading();
        _game.Turn();
        Trading();
        _game.River();
        Trading();
        var (winners, losers) = _game.ShowDown();
        var winnersPot = _game.Pot / winners.Count;
        foreach (var winner in winners)
        {
            if (winnersPot - winner.PlayerPot < 0)
            {
                _pokerBank.PlayerLosePayment(winner.BankAccount, Math.Abs(winnersPot - winner.PlayerPot));
            }
            else
            {
                _pokerBank.PlayerWinPayment(winner.BankAccount, winnersPot - winner.PlayerPot);
            }
        }

        foreach (var loser in losers)
        {
            _pokerBank.PlayerLosePayment(loser.BankAccount, loser.PlayerPot);
        }
    }

    private void Trading()
    {
        foreach (var player in _game.Players.Where(player => player.Status == PlayerStatus.Active))
        {
            _game.ClaimBet(_pokerBank, player);
        }
    }
}