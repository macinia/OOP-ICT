using OOP_ICT.Models;

namespace OOP_ICT.Fourth;

public class FullHouseHandler : ICombinationsHandler
{
    private const int FullHouseSize = 5;
    private const int FullHouseDifferentRanksCount = 3;
    
    public bool IsConditions(List<Card> cards)
    {
        var pokerUtils = new PokerUtils();
        return pokerUtils.HasRanksCount(cards, FullHouseDifferentRanksCount) &&
               pokerUtils.IsRepeatedRanks(cards, FullHouseSize);
    }

    public PokerCombination ReturnCombination()
    {
        return PokerCombination.FullHouse;
    }
}