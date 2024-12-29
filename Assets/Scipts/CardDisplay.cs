using UnityEngine;
using UnityEngine.UI;

public class CardDisplay : MonoBehaviour
{
    [Header("Sprites")]
    [SerializeField] Sprite jack;
    [SerializeField] Sprite queen;
    [SerializeField] Sprite king;
    [SerializeField] Sprite ace;
    [Header("Value Card")]
    [SerializeField] Image valueCard;
    [Header("Card Back")]
    [SerializeField] GameObject cardBack;
    
    Card myCard;
    public Card MyCard => myCard;
    Player cardOwner;
    public Player Owner => cardOwner;
    public void SetCard(Card card, Player owner)
    {
        myCard = card;
        SetValue(card.cardValue);
        cardOwner = owner;
    }

    // void OnValidate()
    // {
    //     SetValue(CardValue.Jack);
    // }
    void SetValue(CardValue cardValue)
    {
        switch(cardValue)
        {
            case CardValue.Jack:
            {
                valueCard.sprite = jack;
            }
            break;
            case CardValue.Queen:
            {
                valueCard.sprite = queen;
            }
            break;
            case CardValue.King:
            {
                valueCard.sprite = king;
            }
            break;
            case CardValue.Ace:
            {
                valueCard.sprite = ace;
            }
            break;
        }
    }

    public void ShowCard()
    {
        cardBack.SetActive(false);
    }

    public void HideCard()
    {
        cardBack.SetActive(true);
    }
}
