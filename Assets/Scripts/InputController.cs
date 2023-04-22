using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    // Reference to other game components
    public GameManager gameManager;
    public BoardManager boardManager;
    public UIController uiController;

    // Raycast settings
    public LayerMask landLayer;
    public LayerMask creatureLayer;

    void Update()
    {
        if (gameManager.currentState == GameManager.GameState.PlayerTurn)
        {
            HandleInput();
        }
    }

    void HandleInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // Check if a land tile was clicked
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, landLayer))
            {
                Land clickedLand = hit.collider.GetComponent<Land>();
                if (clickedLand != null)
                {
                    // Perform actions related to the clicked land
                    boardManager.HandleLandClick(clickedLand);
                }
            }
            // Check if a creature was clicked
            else if (Physics.Raycast(ray, out hit, Mathf.Infinity, creatureLayer))
            {
                Creature clickedCreature = hit.collider.GetComponent<Creature>();
                if (clickedCreature != null)
                {
                    // Perform actions related to the clicked creature
                    gameManager.player.HandleCreatureClick(clickedCreature);
                }
            }
        }
    }
}
