using OOP_ICT.Models;

namespace OOP_ICT.Fourth;

public class PokerScoring
{
    public int ConvertValue(CardValue value)
    {
        return value switch
        {
            CardValue.Ace => 15,
            CardValue.King => 14,
            CardValue.Queen => 13,
            CardValue.Jack => 12,
            CardValue.Ten => 11,
            CardValue.Nine => 10,
            CardValue.Eight => 9,
            CardValue.Seven => 8,
            CardValue.Six => 7,
            CardValue.Five => 6,
            CardValue.Four => 5,
            CardValue.Three => 4,
            CardValue.Two => 3,
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, null)
        };
    }
}