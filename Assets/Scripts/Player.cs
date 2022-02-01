using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
    public int CurrentHealth { get; private set; }
    public int MaximumHealth { get; private set; }

    public event EventHandler<HealEventArgs> Healed;
    public event EventHandler<DamageEventArgs> Damaged;

    public Player(int currentHealth, int maximumHealth = 12)
    {
        if (currentHealth < 0) throw new ArgumentOutOfRangeException("currentHealth");
        if (currentHealth > maximumHealth) throw new ArgumentOutOfRangeException("currentHealth");
        CurrentHealth = currentHealth;
        MaximumHealth = maximumHealth;
    }

    public void Heal(int amount)
    {
        int newHealth = Mathf.Min(CurrentHealth + amount, MaximumHealth);
        Healed?.Invoke(this, new HealEventArgs(newHealth - CurrentHealth));
        CurrentHealth = newHealth;
    }

    public void Damage(int amount)
    {
        int newHealth = Mathf.Max(CurrentHealth - amount, 0);
        Damaged?.Invoke(this, new DamageEventArgs(CurrentHealth - newHealth));
        CurrentHealth = newHealth;
    }

    public class HealEventArgs : EventArgs
    {
        public int Amount { get; private set; }

        public HealEventArgs(int amount)
        {
            Amount = amount;
        }
    }

    public class DamageEventArgs : EventArgs
    {
        public int Amount { get; private set; }

        public DamageEventArgs(int amount)
        {
            Amount = amount;
        }
    }
}
