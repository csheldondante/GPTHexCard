using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Unit : MonoBehaviour
{
    public string unitName;
    public int faeriaCost;
    public int requiredForests;
    public int requiredMountains;
    public int requiredLakes;
    public int requiredDeserts;

    public Player owner;
    public Land currentLand;
}

public class Creature : Unit
{
    public int attack;
    public int defense;
    public int movementRange;
    public List<Ability> abilities;

    public void MoveTo(Land targetLand)
    {
        // Implement movement logic here
    }

    public void Attack(Unit targetUnit)
    {
        // Implement attack logic here
    }

    public void ReceiveDamage(int damage)
    {
        // Implement damage logic here
    }

    public void Die()
    {
        // Implement death logic here
    }
}

public class Structure : Unit
{
    public List<PassiveEffect> passiveEffects;
    public List<ActivatedAbility> activatedAbilities;

    public void ActivateAbility(ActivatedAbility ability)
    {
        // Implement ability activation logic here
    }

    public void ApplyPassiveEffect(PassiveEffect effect)
    {
        // Implement passive effect logic here
    }
}
