using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{
    public List<Card> cardDeck = new List<Card>();

    void Start()
    {
        InitializeDeck();
    }
    public void  InitializeDeck()
    {
        cardDeck.Clear();
        foreach (CardValue cardValue in System.Enum.GetValues(typeof(CardValue)))
        {
            for (int i = 0; i < 5; i++) // Thêm 4 lá cho mỗi giá trị
            {
                cardDeck.Add(new Card(cardValue));
            }
        }
        ShuffleCardDeck();
    }

    public void ShuffleCardDeck()
    {
        for (int i = 0; i < cardDeck.Count; i++)
        {
            Card temp = cardDeck[i];
            int randomIndex = Random.Range(i,cardDeck.Count);
            cardDeck[i] = cardDeck[randomIndex];
            cardDeck[randomIndex] = temp;
        }
    }
    public Card DrawCard()
    {
        if(cardDeck.Count == 0)
        {
            return null;
        }
        Card drawnCard = cardDeck[0];
        cardDeck.RemoveAt(0);
        return drawnCard;
    }
}
