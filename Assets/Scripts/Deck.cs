using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck
{
    public List<Card> cards; // The list of cards in the deck
    public Deck()
    {
        cards = new List<Card>();
        for(int i=0; i<20; ++i)
        {
            cards.Add(new Card());
        }
    }

    // Shuffle the deck using the Fisher-Yates algorithm
    public void Shuffle()
    {
        int n = cards.Count;
        while (n > 1)
        {
            n--;
            int k = Random.Range(0, n + 1);
            Card card = cards[k];
            cards[k] = cards[n];
            cards[n] = card;
        }
    }

    // Draw a card from the deck
    public Card DrawCard()
    {
        if (cards.Count > 0)
        {
            Card card = cards[0];
            cards.RemoveAt(0);
            return card;
        }
        else
        {
            Debug.LogWarning("Deck is empty!");
            return null;
        }
    }
}
