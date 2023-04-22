using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardUI : MonoBehaviour
{
    // Reference to the UI elements in the card prefab
    public Image artworkImage;
    public Text nameLabel;
    public Text descriptionLabel;
    public Text faeriaCostLabel;
    public Image[] landRequirementImages;

    private Card card;

    // Method to update the UI elements with the card's properties
    public void UpdateUI()
    {
        artworkImage.sprite = card.cardImage;
        nameLabel.text = card.cardName;
        descriptionLabel.text = card.cardDescription;
        faeriaCostLabel.text = card.faeriaCost.ToString();

        // Update the land requirement images based on the card's land requirements
        for (int i = 0; i < landRequirementImages.Length; i++)
        {
            if (i < card.landRequirements.Length)
            {
                landRequirementImages[i].gameObject.SetActive(true);
                //landRequirementImages[i].sprite = card.landRequirements[i].landSprite;
            }
            else
            {
                landRequirementImages[i].gameObject.SetActive(false);
            }
        }
    }

    // Getter method for the card variable
    public Card GetCard()
    {
        return card;
    }

    // Setter method for the card variable
    public void SetCard(Card newCard)
    {
        card = newCard;
        UpdateUI();
    }
}
