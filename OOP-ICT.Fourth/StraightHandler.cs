using OOP_ICT.Models;

namespace OOP_ICT.Fourth;

public class StraightHandler : ICombinationsHandler
{
    public bool IsConditions(List<Card> cards)
    {
        var pokerUtils = new PokerUtils();
        return pokerUtils.IsSequentual(cards);
    }

    public PokerCombination ReturnCombination()
    {
        return PokerCombination.Straight;
    }
}