using OOP_ICT.Models;

namespace OOP_ICT.Fourth;

public class PairHandler : ICombinationsHandler
{
    private const int PairSize = 2;
    private const int PairDifferentRanksCount = 6;
    
    public bool IsConditions(List<Card> cards)
    {
        var pokerUtils = new PokerUtils();
        return pokerUtils.HasRanksCount(cards, PairDifferentRanksCount) && pokerUtils.IsRepeatedRanks(cards, PairSize);
    }

    public PokerCombination ReturnCombination()
    {
        return PokerCombination.Pair;
    }
}