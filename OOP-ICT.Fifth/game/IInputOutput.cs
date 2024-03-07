using OOP_ICT.Fourth.Models;
using OOP_ICT.Models;

namespace OOP_ICT.Fifth.game;
using Spectre.Console;
public class IInputOutput
{
    public void Hi()
    {
        var rule = new Rule("[darkslategray2]WELCOME TO THE POKER GAME[/]");
        AnsiConsole.Write(rule);
    }
    public int CountPlayers()
    {
        var count = AnsiConsole.Ask<int>("Введите количество игроков (не менее 3):");
        return count;
    }
    public int FewPlayers()
    {
        var count = AnsiConsole.Ask<int>("Слишком мало участников! Введите количество игроков (не менее 3):");
        return count;
    }
    public string EnteringName(Dictionary<PokerPlayer, string> players) // проверять имена на уникальность
    {
        var Name = AnsiConsole.Ask<string>("Введите ваше имя:");
        if (players.ContainsValue(Name))
        {
            var name = AnsiConsole.Ask<string>("Такое имя уже вводилось, введите уникальное имя:");
        }
        return Name;
    }

    public void PresentationParticipants(string SmalBlind, string BigBlind, string Dealer)
    {
        AnsiConsole.Markup($"SmalBlind: {SmalBlind}, BigBlind: {BigBlind}, Dealer: {Dealer}, размер BigBlind = 100. \n");
    }

    public int EnteringBet(string name, uint balance)
    {
        var bet = AnsiConsole.Ask<int>($" \n Введите вашу ставку, {name}, ваш баланс {balance}, если вы хотите сбросить карты, введите '-1':");
        return bet;
    }

    public void BetsNotEqual()
    {
        AnsiConsole.Markup("Ваши ставки не равны!\n ");
    }
    public void PresentCardsInTheTable(List<Card> cards)
    {
        AnsiConsole.Markup("Карты на столе: ");
        foreach (var card in cards)
        {
            AnsiConsole.Markup($"{card.Rank} of {card.Suit}.\n ");
        }
    }
    
    public void PresentCardsInTheHand(string name, IEnumerable<Card> cards)
    {
        AnsiConsole.Markup($"\n У игрока {name} карты в руке: ");
        foreach (var card in cards)
        {
            AnsiConsole.Markup($"{card.Rank} of {card.Suit}. ");
        }
    }

    public bool PlayAgain()
    {
        AnsiConsole.WriteLine();
        var playAgain = AnsiConsole.Ask<string>("Хотите сыграть еще раз?  Введите 'yes' или 'no'.");
        if (playAgain == "yes")
        {
            return true;
        }

        if (playAgain == "no")
        {
            return false;
        }

        return PlayAgain();
    }

    public void Farewell()
    {
        AnsiConsole.Markup("Спасибо за игру!");
    }

    public bool ClarifyCompositionTeam()
    {
        var CompositionTeam = AnsiConsole.Ask<string>("Состав участников не изменится? Введите 'yes' или 'no'.");
        if (CompositionTeam == "yes")
        {
            return true;
        }
        if (CompositionTeam == "no")
        {
            return false;
        }
        else
        {
            return false;
        }
    }

    public void Winner(string name)
    {
        AnsiConsole.Markup($"Победитель: {name}");
    }
    
}