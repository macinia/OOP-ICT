using OOP_ICT.Models;

namespace OOP_ICT.Fourth;

public interface ICombinationsHandler
{
    bool IsConditions(List<Card> cards);
    PokerCombination ReturnCombination();
}