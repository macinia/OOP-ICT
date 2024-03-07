using OOP_ICT.Second;
using Xunit;
using Xunit.Abstractions;


namespace OOP_ICT.Fourth.Tests;

public class TestPokerFunctions
{
    private readonly ITestOutputHelper _testOutputHelper;

    public TestPokerFunctions(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }

    /// <summary>
    /// Тесты пишутся из трех частей итог - данные - что вернуло 
    /// </summary>

    [Fact]
    public void AreEquals_InputArePreGamePokerPlayers_ReturnTrue()
    {
        var pokerBank = new PokerBank();
        var bank = new Bank();
        var game = new PokerGame();
        var account1 = bank.CreateAccount(200);
        var account2 = bank.CreateAccount(200);
        var account3 = bank.CreateAccount(200);
        var account4 = bank.CreateAccount(200);
        var account5 = bank.CreateAccount(200);
        var bigBlind = 100;
        var player1 = new PokerPlayer(bank.FindAccount(account1), PlayerStatus.Active);
        var player2 = new PokerPlayer(bank.FindAccount(account2), PlayerStatus.Active);
        var player3 = new PokerPlayer(bank.FindAccount(account3), PlayerStatus.Active);
        var player4 = new PokerPlayer(bank.FindAccount(account4), PlayerStatus.Active);
        var player5 = new PokerPlayer(bank.FindAccount(account5), PlayerStatus.Active);
        var poker = new PokerGameFacade(game, pokerBank);
        var players = new List<PokerPlayer> { player1, player2, player3, player4, player5};
        poker.PreGame(players);
        Assert.Equal(players, game.Players);
    }
    
    [Fact]
    public void AreEquals_InputIsGame_ReturnTrue()
    {
        var pokerBank = new PokerBank();
        var bank = new Bank();
        var game = new PokerGame();
        var account1 = bank.CreateAccount(200);
        var account2 = bank.CreateAccount(200);
        var account3 = bank.CreateAccount(200);
        var account4 = bank.CreateAccount(200);
        var account5 = bank.CreateAccount(200);
        var smallBlind = 50;
        var bigBlind = 100;
        var player1 = new PokerPlayer(bank.FindAccount(account1), PlayerStatus.Active);
        var player2 = new PokerPlayer(bank.FindAccount(account2), PlayerStatus.Active);
        var player3 = new PokerPlayer(bank.FindAccount(account3), PlayerStatus.Active);
        var player4 = new PokerPlayer(bank.FindAccount(account4), PlayerStatus.Active);
        var player5 = new PokerPlayer(bank.FindAccount(account5), PlayerStatus.Active);
        var poker = new PokerGameFacade(game, pokerBank);
        var players = new List<PokerPlayer> { player1, player2, player3, player4, player5};
        poker.PreGame(players);
        poker.Game(smallBlind, bigBlind, 0);
        Assert.Equal(PlayerStatus.Dealer, player1.Status);
    }
    
    [Fact]
    public void AreNotEquals_InputIsGame_ReturnTrue()
    {
        var pokerBank = new PokerBank();
        var bank = new Bank();
        var game = new PokerGame();
        var account1 = bank.CreateAccount(200);
        var account2 = bank.CreateAccount(200);
        var account3 = bank.CreateAccount(200);
        var account4 = bank.CreateAccount(200);
        var account5 = bank.CreateAccount(200);
        var smallBlind = 50;
        var bigBlind = 100;
        var player1 = new PokerPlayer(bank.FindAccount(account1), PlayerStatus.Active);
        var player2 = new PokerPlayer(bank.FindAccount(account2), PlayerStatus.Active);
        var player3 = new PokerPlayer(bank.FindAccount(account3), PlayerStatus.Active);
        var player4 = new PokerPlayer(bank.FindAccount(account4), PlayerStatus.Active);
        var player5 = new PokerPlayer(bank.FindAccount(account5), PlayerStatus.Active);
        var poker = new PokerGameFacade(game, pokerBank);
        var players = new List<PokerPlayer> { player1, player2, player3, player4, player5};
        poker.PreGame(players);
        poker.Game(smallBlind, bigBlind, 0);
        _testOutputHelper.WriteLine(player2.PlayerPot.ToString());
        Assert.NotEqual(200, player2.BankAccount.Balance);
    }
}