using OOP_ICT.Second;
using OOP_ICT.Third;

namespace OOP_ICT.Fourth;

public class PokerPlayer
{
    public PokerPlayer(BankAccount bankAccount, PlayerStatus status)
    {
        if (bankAccount is null) throw new AccountNotFoundException("Invalid account");
        BankAccount = bankAccount;
        Status = status;
    }

    public decimal PlayerPot { get; private set; }
    public BankAccount BankAccount { get; }
    public Hand Hand { get; } = new();
    public PlayerStatus Status;

    public void Call(decimal currentGameCall)
    {
        PlayerPot += (currentGameCall - PlayerPot);
    }

    public void Blind(int blindAmount)
    {
        PlayerPot += blindAmount;
    }

    public void AllIn()
    {
        Status = PlayerStatus.AllIn;
        PlayerPot = BankAccount.Balance;
    }

    public void Raise(int currentHighestGamePot, int newPot)
    {
        if (BankAccount.Balance <= currentHighestGamePot)
            throw new NotEnoughMoneyException("You have not enough money for raise");
        PlayerPot += (newPot - PlayerPot);
    }

    public void Fold()
    {
        Status = PlayerStatus.Folded;
        Hand.GetHand().ToList().Clear();
    }

    public Hand ShowDown()
    {
        return Hand;
    }
}