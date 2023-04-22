 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour
{
    // Board dimensions
    public int boardWidth = 5;
    public int boardHeight = 5;

    // Prefabs for tiles
    public GameObject oceanTilePrefab;
    public GameObject landTilePrefab;

    // Board tile structure
    private Land[,] boardTiles;

    void Start()
    {
        SetupBoard();
    }

    public void SetupBoard()
    {
        // Initialize board tile structure
        boardTiles = new Land[boardWidth, boardHeight];

        // Create ocean tiles and land tiles
        for (int x = 0; x < boardWidth; x++)
        {
            for (int y = 0; y < boardHeight; y++)
            {
                // Calculate tile position
                Vector3 tilePosition = GetTilePosition(x, y);

                // Instantiate ocean tile
                GameObject oceanTile = Instantiate(oceanTilePrefab, tilePosition, Quaternion.identity);
                oceanTile.transform.SetParent(transform);

                // Instantiate land tile
                GameObject landTile = Instantiate(landTilePrefab, tilePosition, Quaternion.identity);
                landTile.transform.SetParent(transform);
                landTile.SetActive(false);

                // Initialize board tile data
                GameObject newLand = GameObject.Instantiate(oceanTilePrefab);
                Land land = newLand.GetComponent<Land>();
                land.landType = Land.LandType.Ocean;
                land.tileObject = landTile;
                boardTiles[x, y] = land;
            }
        }
    }

    private Vector3 GetTilePosition(int x, int y)
    {
        // Calculate the world position of the tile based on its grid position
        float xPos = x + 0.5f * (y % 2);
        float yPos = y * 0.75f;
        return new Vector3(xPos, yPos, 0);
    }

    public void PlaceLand(int x, int y, Land.LandType landType)
    {
        if (IsValidTile(x, y) && boardTiles[x, y].landType == Land.LandType.Ocean)
        {
            boardTiles[x, y].landType = landType;
            boardTiles[x, y].tileObject.SetActive(true);
            // Update land tile visuals based on the land type
        }
    }

    public bool IsValidTile(int x, int y)
    {
        // Check if the given coordinates are within the board dimensions
        return x >= 0 && x < boardWidth && y >= 0 && y < boardHeight;
    }

    public void HandleLandClick(Land land)
    {

    }
}
