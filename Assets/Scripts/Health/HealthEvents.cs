using System;
using UnityEngine;

[DisallowMultipleComponent]
public class HealthEvents : MonoBehaviour
{
    public event Action<HealthEvents, HealthChangedEventArgs> OnHealthChanged;
    public event Action<HealthEvents, DestroyEventArgs> OnDestroyed;

    public void CallHealthChangedEvent(float healthPercent, int healthAmount, int damage)
    {
        OnHealthChanged?.Invoke(this,
            new HealthChangedEventArgs()
                { healthPercent = healthPercent, healthAmount = healthAmount, damage = damage });
    }

    public void CallDestroyEvent(bool playerDied, int points)
    {
        OnDestroyed?.Invoke(this, new DestroyEventArgs() { playerDied = playerDied, points = points });
    }
}

public class HealthChangedEventArgs : EventArgs
{
    public float healthPercent;
    public int healthAmount;
    public int damage;
}

public class DestroyEventArgs : EventArgs
{
    public bool playerDied;
    public int points;
}