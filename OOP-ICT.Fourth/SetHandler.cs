using OOP_ICT.Models;

namespace OOP_ICT.Fourth;

public class SetHandler : ICombinationsHandler
{
    private const int SetSize = 3;
    private const int SetDifferentRanksCount = 5;
    
    public bool IsConditions(List<Card> cards)
    {
        var pokerUtils = new PokerUtils();
        var pairs = pokerUtils.IsPairedRanks(cards);
        return pokerUtils.HasRanksCount(cards, SetDifferentRanksCount) && pairs.Count == 1 && pairs[0].Item2 == SetSize;
    }

    public PokerCombination ReturnCombination()
    {
        return PokerCombination.Set;
    }
}