using OOP_ICT.Models;

namespace OOP_ICT.Fourth;

public class PokerUtils
{
    private const int SequentualSize = 5;
    private const int FlushSize = 5;
    public bool IsSameColor(List<Card> cards)
    {
        cards.Sort((firstCard,secondCard) => 
            firstCard.Suit.CompareTo(secondCard.Suit));

        var count = 1;
        for (var i = 0; i < cards.Count - 1; i++)
        {
            if (cards[i].Suit == cards[i + 1].Suit)
            {
                count++;
            }
        }
        return count == FlushSize;
    }

    public bool IsRepeatedRanks(List<Card> cards, int size)
    {
        cards.Sort();
        var count = 1;
        for (var i = 0; i < cards.Count - 1; i++)
        {
            if (cards[i].Value == cards[i + 1].Value)
            {
                count++;
            }
        }

        return count == size;
    }
    
    public List<(CardValue, int)> IsPairedRanks(List<Card> cards)
    {
        cards.Sort();
        var count = 1;
        var ranks = new List<(CardValue, int)>();
        for (var i = 0; i < cards.Count - 1; i++)
        {
            if (cards[i].Value == cards[i + 1].Value)
            {
                count++;
            }
            else
            {
                ranks.Add((cards[i].Value, count));
                count = 1;
            }
        }

        return ranks;
    }

    public bool HasRanksCount(List<Card> cards, int ranksCount)
    {
        cards.Sort();
        var count = 1;
        for (var i = 0; i < cards.Count - 1; i++)
        {
            if (cards[i].Value != cards[i + 1].Value)
            {
                count++;
            }
        }
        return count == ranksCount;
    }

    public bool IsSequentual(List<Card> cards)
    {
        cards.Sort();
        var count = 1;
        
        for (var i = 0; i < cards.Count - 1; i++)
        {
            if ((int)cards[i].Value + 1 == (int)cards[i + 1].Value)
            {
                count++;
            }
            else
            {
                if (count != 1) return false;
            }

        }
        return count >= SequentualSize;
    }

    public bool isHighStraight(List<Card> cards)
    {
        cards.Sort((firstCard, secondCard) => 
            secondCard.Value.CompareTo(firstCard.Value));
        return cards[0].Value == CardValue.Ace && cards[1].Value == CardValue.King && cards[2].Value == CardValue.Queen &&
               cards[3].Value == CardValue.Jack && cards[4].Value == CardValue.Ten;
    }
}