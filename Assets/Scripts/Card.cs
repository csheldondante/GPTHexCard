using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card
{
    public enum CardType
    {
        Creature,
        Structure,
        Event
    }

    public string cardName;
    public string cardDescription;
    public string artwork; // path to the card's artwork file
    public CardType cardType;
    public int faeriaCost;
    public int landRequirement;
    public string landRequirements; // a string describing the land requirements for the card
    public Sprite cardImage;

    // Method to load a card from a text file
    public bool LoadCardFromFile(string filePath, int lineNumber)
    {
        try
        {
            string[] lines = File.ReadAllLines(filePath);

            if (lineNumber < 0 || lineNumber >= lines.Length)
            {
                Debug.LogError("Invalid line number for card data.");
                return false;
            }

            string line = lines[lineNumber];
            string[] cardData = line.Split(',');

            if (cardData.Length != 7)
            {
                Debug.LogError("Invalid card data format.");
                return false;
            }

            cardName = cardData[0];
            cardDescription = cardData[1];
            artwork = null;// cardData[2];
            cardType = (CardType)System.Enum.Parse(typeof(CardType), cardData[3]);
            faeriaCost = int.Parse(cardData[4]);
            landRequirement = int.Parse(cardData[5]);
            landRequirements = cardData[6];

            // Load the card image from Resources folder
            cardImage = Resources.Load<Sprite>(artwork);

            return true;
        }
        catch (System.Exception e)
        {
            Debug.LogError("Error loading card data: " + e.Message);
            return false;
        }
    }

    public void ExecuteEffect()
    {

    }
}
