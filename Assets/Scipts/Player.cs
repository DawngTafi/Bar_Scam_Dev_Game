using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Player
{
    public string playerName;
    public List<Card> playerHand;
    public bool IsHuman{get;private set;}
    public Player(string name,bool isHuman)
    {
        playerName = name;
        playerHand = new List<Card>();
        IsHuman = isHuman;
    }  

    public void DrawCard(Card card)
    {
        playerHand.Add(card);
    }  

    public void PlayerCard(Card card)
    {
        playerHand.Remove(card);
    }
    
}
