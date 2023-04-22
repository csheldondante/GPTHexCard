using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hand
{
    public List<Card> cards; // list of cards in the hand
    public GameObject cardPrefab; // prefab for card UI elements
    public Transform handTransform; // transform of the hand UI container
    public float cardSpacing = 0.5f; // spacing between cards in the hand
    public float cardHeight = 1.0f; // height of cards in the hand
    public float cardWidth = 0.75f; // width of cards in the hand

    public Hand(GameObject cardPrefab, Transform handTransform)
    {
        this.cardPrefab = cardPrefab;
        this.handTransform = handTransform;
    }

    // add a card to the hand
    public void AddCard(Card card)
    {
        cards = new List<Card>();
        cards.Add(card);

        // instantiate a new card UI element and add it to the hand container
        GameObject cardObject = GameObject.Instantiate(cardPrefab, handTransform);
        cardObject.GetComponent<CardUI>().SetCard(card);

        // position the card in the hand based on its index
        int index = cards.Count - 1;
        float xPos = index * cardSpacing - (cards.Count - 1) * cardSpacing / 2;
        Vector3 cardPosition = new Vector3(xPos, cardHeight, 0);
        cardObject.transform.localPosition = cardPosition;

        // set the card's width and height
        RectTransform cardRectTransform = cardObject.GetComponent<RectTransform>();
        cardRectTransform.sizeDelta = new Vector2(cardWidth, cardHeight);
    }

    // remove a card from the hand
    public void RemoveCard(Card card)
    {
        cards.Remove(card);

        // find the card UI element and destroy it
        foreach (Transform child in handTransform)
        {
            if (child.GetComponent<CardUI>().GetCard() == card)
            {
                GameObject.Destroy(child.gameObject);
                break;
            }
        }

        // reposition the remaining cards in the hand
        for (int i = 0; i < cards.Count; i++)
        {
            float xPos = i * cardSpacing - (cards.Count - 1) * cardSpacing / 2;
            Vector3 cardPosition = new Vector3(xPos, cardHeight, 0);
            handTransform.GetChild(i).localPosition = cardPosition;
        }
    }

    // get the index of a card in the hand
    public int GetCardIndex(Card card)
    {
        return cards.IndexOf(card);
    }

    // get the number of cards in the hand
    public int GetCardCount()
    {
        return cards.Count;
    }

    // get a specific card from the hand by index
    public Card GetCard(int index)
    {
        if (index >= 0 && index < cards.Count)
        {
            return cards[index];
        }
        else
        {
            return null;
        }
    }
}
