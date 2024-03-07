using OOP_ICT.Models;

namespace OOP_ICT.Fourth;

public class FlushHandler : ICombinationsHandler
{
    public bool IsConditions(List<Card> cards)
    {
        var pokerUtils = new PokerUtils();
        return pokerUtils.IsSameColor(cards);
    }

    public PokerCombination ReturnCombination()
    {
        return PokerCombination.Flush;
    }
}