using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    // UI elements references
    public Text playerLifePointsText;
    public Text opponentLifePointsText;
    public Text playerFaeriaText;
    public Text opponentFaeriaText;
    public GameObject gameOverPanel;
    public Text gameOverMessageText;

    // Start is called before the first frame update
    void Start()
    {
        gameOverPanel.SetActive(false);
    }

    // Update player's life points on UI
    public void UpdatePlayerLifePoints(int lifePoints)
    {
        playerLifePointsText.text = lifePoints.ToString();
    }

    // Update opponent's life points on UI
    public void UpdateOpponentLifePoints(int lifePoints)
    {
        opponentLifePointsText.text = lifePoints.ToString();
    }

    // Update player's Faeria on UI
    public void UpdatePlayerFaeria(int faeria)
    {
        playerFaeriaText.text = faeria.ToString();
    }

    // Update opponent's Faeria on UI
    public void UpdateOpponentFaeria(int faeria)
    {
        opponentFaeriaText.text = faeria.ToString();
    }

    // Display game over message and panel
    public void DisplayGameOverMessage(string message)
    {
        gameOverPanel.SetActive(true);
        gameOverMessageText.text = message;
    }
}
