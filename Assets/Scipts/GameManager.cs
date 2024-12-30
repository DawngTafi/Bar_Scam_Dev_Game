using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public List<Player> players = new List<Player>();
    [SerializeField] Deck deck;
    [SerializeField] Transform playerHandTransform;
    [SerializeField] Transform tableTransform;
    [SerializeField] List<Transform> aiHandTransforms = new List<Transform>();
    [SerializeField] GameObject cardPrefab;
    [SerializeField] int numberOfAiPlayer;
    [SerializeField] int startingHandSize;
    [SerializeField] Button playButton;
    int currentPlayer = 0;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        deck.InitializeDeck();
        InitializePlayers();
        StartCoroutine(DealingStartingCards());
        playButton.onClick.AddListener(PlaySelectedCards);
    }

    void InitializePlayers()
    {
        players.Clear();
        players.Add(new Player("Player", true));

        for (int i = 0; i < numberOfAiPlayer; i++)
        {
            players.Add(new AiPlayer("Ai " + (i + 1)));
        }
    }

    void DealCards()
    {
        for (int i = 0; i < startingHandSize; i++)
        {
            foreach (Player player in players)
            {
                player.DrawCard(deck.DrawCard());
            }
        }
    }

    IEnumerator DealingStartingCards()
    {
        for (int i = 0; i < startingHandSize; i++)
        {
            foreach (Player player in players)
            {
                Card drawnCard = deck.DrawCard();
                player.DrawCard(drawnCard);
                Transform hand = player.IsHuman ? playerHandTransform : aiHandTransforms[players.IndexOf(player) - 1];
                GameObject card = Instantiate(cardPrefab, hand, false);
                CardDisplay cardDisplay = card.GetComponentInChildren<CardDisplay>();
                cardDisplay.SetCard(drawnCard, player);
                if (player.IsHuman)
                {
                    cardDisplay.ShowCard();
                }
                yield return new WaitForSeconds(0.1f);
            }
        }
    }

    void PlaySelectedCards()
    {
        Debug.Log("Play selected cards");
        List<CardInteraction> selectedCards = new List<CardInteraction>();
        foreach (Transform cardTransform in playerHandTransform)
        {
            CardInteraction cardInteraction = cardTransform.GetComponent<CardInteraction>();
            if (cardInteraction != null && cardInteraction.IsSelected)
            {
                selectedCards.Add(cardInteraction);
            }
        }

        foreach (CardInteraction cardInteraction in selectedCards)
        {
            Card card = cardInteraction.cardDisplay.MyCard;
            players[0].PlayerCard(card); // Remove card from player's hand
            Destroy(cardInteraction.gameObject); // Remove card from UI
            GameObject cardOnTable = Instantiate(cardPrefab, tableTransform, false);
            CardDisplay cardDisplay = cardOnTable.GetComponentInChildren<CardDisplay>();
            cardDisplay.SetCard(card, players[0]);
            cardDisplay.ShowCard();
        }
    }
}
