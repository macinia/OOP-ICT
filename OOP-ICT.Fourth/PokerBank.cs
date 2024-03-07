using OOP_ICT.Second;

namespace OOP_ICT.Fourth;

public class PokerBank
{
    public void PlayerWinPayment(BankAccount account, decimal pot)
    {
        if (account is null)
        {
            throw new AccountNotFoundException("Invalid account");
        }
        
        account.AddMoney(pot);
    }

    public void PlayerLosePayment(BankAccount account, decimal bet)
    {
        if (account is null)
        {
            throw new AccountNotFoundException("Invalid account");
        }
        account.RemoveMoney(bet);
    }

    public bool CheckMoney(BankAccount account, decimal bet)
    {
        if (account is null)
        {
            throw new AccountNotFoundException("Invalid account");
        }
        if (account.Balance < bet)
        {
            throw new NotEnoughMoneyException("Not enough money");
        }

        return true;
    }
}