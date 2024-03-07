using OOP_ICT.Models;

namespace OOP_ICT.Fourth;

public class StraightFlushHandler : ICombinationsHandler
{
    public bool IsConditions(List<Card> cards)
    {
        var pokerUtils = new PokerUtils();
        return pokerUtils.IsSameColor(cards) && pokerUtils.IsSequentual(cards);
    }

    public PokerCombination ReturnCombination()
    {
        return PokerCombination.StraightFlush;
    }
}