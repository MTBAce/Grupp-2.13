using UnityEngine;

public static class DamageModifier
{
    // The global damage multiplier
    public static float damageMultiplier = 1f;

    // Method to apply a damage boost
    public static void ApplyDamageBoost(float multiplier)
    {
        damageMultiplier = multiplier;
        Debug.Log("Damage multiplier applied: " + damageMultiplier);
    }
}
