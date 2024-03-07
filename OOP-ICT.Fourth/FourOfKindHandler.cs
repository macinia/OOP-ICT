using OOP_ICT.Models;

namespace OOP_ICT.Fourth.combinations;

public class FourOfKindHandler : ICombinationsHandler
{
    private const int FourOfKindSize = 4;
    private const int FourOfKindDifferentRanksCount = 4;
    public bool IsConditions(List<Card> cards)
    {
        var pokerUtils = new PokerUtils();
        return pokerUtils.HasRanksCount(cards, FourOfKindDifferentRanksCount) &&
               pokerUtils.IsRepeatedRanks(cards, FourOfKindSize);
    }

    public PokerCombination ReturnCombination()
    {
        return PokerCombination.FourOfKind;
    }
}