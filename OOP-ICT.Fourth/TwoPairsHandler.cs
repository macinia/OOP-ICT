using OOP_ICT.Models;

namespace OOP_ICT.Fourth;

public class TwoPairsHandler : ICombinationsHandler
{
    private const int PairSize = 2;
    private const int TwoPairsDifferentRanksCount = 5;
    
    public bool IsConditions(List<Card> cards)
    {
        var pokerUtils = new PokerUtils();
        var pairs = pokerUtils.IsPairedRanks(cards);
        return pokerUtils.HasRanksCount(cards, TwoPairsDifferentRanksCount) && pairs.Count == PairSize && pairs[0].Item2 == pairs[1].Item2;
    }

    public PokerCombination ReturnCombination()
    {
        return PokerCombination.TwoPairs;
    }
}