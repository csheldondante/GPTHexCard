using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Land : MonoBehaviour
{
    // Enum for land types
    public enum LandType
    {
        Plains,
        Forest,
        Mountain,
        Lake,
        Desert,
        Ocean
    }

    // Variables for land properties
    public LandType landType;
    public Creature creatureOnLand;
    public Structure structureOnLand;
    public GameObject tileObject;

    // Set the land type
    public void SetLandType(LandType newLandType)
    {
        landType = newLandType;
        UpdateVisuals();
    }

    // Update the land visuals based on its type
    private void UpdateVisuals()
    {
        // Replace with your specific implementation for updating visuals
        // e.g., changing the material or mesh of the GameObject based on the land type
    }

    // Place a creature on the land
    public void PlaceCreature(Creature newCreature)
    {
        creatureOnLand = newCreature;
        newCreature.transform.position = transform.position; // Adjust position based on your model
        newCreature.currentLand = this;
    }

    // Place a structure on the land
    public void PlaceStructure(Structure newStructure)
    {
        structureOnLand = newStructure;
        newStructure.transform.position = transform.position; // Adjust position based on your model
        newStructure.currentLand = this;
    }

    // Remove the creature from the land
    public void RemoveCreature()
    {
        if (creatureOnLand != null)
        {
            creatureOnLand.currentLand = null;
            creatureOnLand = null;
        }
    }

    // Remove the structure from the land
    public void RemoveStructure()
    {
        if (structureOnLand != null)
        {
            structureOnLand.currentLand = null;
            structureOnLand = null;
        }
    }
}
