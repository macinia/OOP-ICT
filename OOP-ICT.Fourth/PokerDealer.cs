using OOP_ICT.Models;
using OOP_ICT.Third;

namespace OOP_ICT.Fourth;

public class PokerDealer: Dealer
{
    public PokerDealer(IShuffle shuffleAlgorithm) : base(shuffleAlgorithm)
    {
    }
    public void DealCards(List<Hand> hands, int cardsInHand)
    {
        for (var i = 0; i < cardsInHand; i++)
        {
            foreach (var hand in hands) 
            {
                hand.AddCardToHand(GiveCard());
                
            }
        }
    }
}