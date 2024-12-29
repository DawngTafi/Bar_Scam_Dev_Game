using System;
using UnityEngine;

public enum CardValue
{
    Jack,
    Queen,
    King,
    Ace
}

[System.Serializable]
public class Card
{

    public CardValue cardValue;

    public Card(CardValue value)
    {
        cardValue = value;
    }
    
}
