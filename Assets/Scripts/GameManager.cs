using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Game state enums
    public enum GameState
    {
        Setup,
        PlayerTurn,
        OpponentTurn,
        GameOver
    }

    public GameState currentState;

    // Reference to other game components
    public BoardManager boardManager;
    public Player player;
    public Player opponent;
    public UIController uiController;

    // Game settings
    public int startingLifePoints = 20;
    public int startingFaeria = 3;

    void Start()
    {
        InitializeGame();
    }

    void Update()
    {
        HandleGameState();
    }

    void InitializeGame()
    {
        // Initialize the game board
        boardManager.SetupBoard();

        // Initialize player and opponent
        player.SetupPlayer(startingLifePoints, startingFaeria);
        opponent.SetupPlayer(startingLifePoints, startingFaeria);

        // Set initial game state
        currentState = GameState.Setup;
    }

    void HandleGameState()
    {
        switch (currentState)
        {
            case GameState.Setup:
                // Perform any necessary setup actions
                break;
            case GameState.PlayerTurn:
                // Handle player turn logic
                break;
            case GameState.OpponentTurn:
                // Handle opponent (AI or another player) turn logic
                break;
            case GameState.GameOver:
                // Handle game over logic
                break;
            default:
                break;
        }
    }

    public void EndTurn()
    {
        if (currentState == GameState.PlayerTurn)
        {
            currentState = GameState.OpponentTurn;
        }
        else if (currentState == GameState.OpponentTurn)
        {
            currentState = GameState.PlayerTurn;
        }
    }

    public void CheckGameOver()
    {
        if (player.lifePoints <= 0 || opponent.lifePoints <= 0)
        {
            currentState = GameState.GameOver;

            if (player.lifePoints <= 0)
            {
                uiController.DisplayGameOverMessage("Opponent Wins!");
            }
            else
            {
                uiController.DisplayGameOverMessage("Player Wins!");
            }
        }
    }
}
