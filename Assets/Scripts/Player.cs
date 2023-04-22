using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Player properties
    public int lifePoints;
    public int faeria;
    public Deck deck;
    public Hand hand;
    public Transform handTransform;
    public GameObject cardPrefab;

    // Initialize the player
    public void SetupPlayer(int startingLifePoints, int startingFaeria)
    {
        lifePoints = startingLifePoints;
        faeria = startingFaeria;
        deck = new Deck();
        deck.Shuffle();
        hand = new Hand(cardPrefab, handTransform);
        DrawInitialCards();
    }

    // Draw the initial cards for the player
    private void DrawInitialCards()
    {
        for (int i = 0; i < 3; i++)
        {
            Card drawnCard = deck.DrawCard();
            hand.AddCard(drawnCard);
        }
    }

    // Draw a card from the deck
    public void DrawCard()
    {
        Card drawnCard = deck.DrawCard();
        hand.AddCard(drawnCard);
    }

    // Change the player's life points by the specified amount
    public void ChangeLifePoints(int amount)
    {
        lifePoints += amount;

        // Check for negative life points
        if (lifePoints < 0)
        {
            lifePoints = 0;
        }
    }

    // Change the player's Faeria by the specified amount
    public void ChangeFaeria(int amount)
    {
        faeria += amount;

        // Check for negative Faeria
        if (faeria < 0)
        {
            faeria = 0;
        }
    }

    // Play a card from the player's hand
    public bool PlayCard(int handIndex)
    {
        Card cardToPlay = hand.GetCard(handIndex);

        // Check if the player has enough Faeria to play the card
        if (cardToPlay != null && faeria >= cardToPlay.faeriaCost)
        {
            // Deduct Faeria cost and remove the card from the hand
            faeria -= cardToPlay.faeriaCost;
            hand.RemoveCard(cardToPlay);

            // Perform the card's effect
            cardToPlay.ExecuteEffect();

            return true;
        }

        return false;
    }

    public void HandleCreatureClick(Creature creature)
    {

    }
}
