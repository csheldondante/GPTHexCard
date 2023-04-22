// The ActivatedAbility struct represents an ability that can be activated by the player.
public struct ActivatedAbility
{
    public int faeriaCost; // The cost of the ability in Faeria.
    public Ability ability; // The Ability struct that defines the behavior of the ability.
}

// The Ability struct represents a behavior that can be triggered by the player or by other game events.
public struct Ability
{
    public string name; // The name of the ability.
    public string description; // A description of the ability.
    public bool requiresTarget; // Whether the ability requires a target.
    public int range; // The range of the ability.
    public void Execute() // The method that executes the ability's behavior.
    {
        // TODO: Define the behavior of the ability.
    }
}

// The PassiveEffect struct represents an effect that is always active while a card or structure is in play.
public struct PassiveEffect
{
    public string name; // The name of the effect.
    public string description; // A description of the effect.
    public void Apply() // The method that applies the effect's behavior.
    {
        // TODO: Define the behavior of the effect.
    }
}
