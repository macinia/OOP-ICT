using OOP_ICT.Models;

namespace OOP_ICT.Fourth;

public class RoyalFlushHandler : ICombinationsHandler
{
    public bool IsConditions(List<Card> cards)
    {
        var pokerUtils = new PokerUtils();
        return pokerUtils.isHighStraight(cards) && pokerUtils.IsSameColor(cards);
    }

    public PokerCombination ReturnCombination()
    {
        return PokerCombination.RoyalFlush;
    }
}