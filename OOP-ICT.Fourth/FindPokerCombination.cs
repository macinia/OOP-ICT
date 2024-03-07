using Microsoft.VisualBasic;
using OOP_ICT.Fourth.combinations;
using OOP_ICT.Models;

namespace OOP_ICT.Fourth;

public class FindPokerCombination
{
    public PokerCombination DetectCombination(List<Card> cards)
    {
         var combinationsHandlers = new List<ICombinationsHandler>()
        {
            new PairHandler(),
            new TwoPairsHandler(),
            new SetHandler(),
            new FourOfKindHandler(),
            new FullHouseHandler(),
            new StraightHandler(),
            new FlushHandler(),
            new StraightFlushHandler(),
            new RoyalFlushHandler()
            
        };
         var foundCombination = combinationsHandlers.FirstOrDefault(handler => handler.IsConditions(cards));
         return foundCombination?.ReturnCombination() ?? PokerCombination.HighCard;
    }  
}