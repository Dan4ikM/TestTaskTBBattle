using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class HealthSystem : MonoBehaviour
{
    public static event Action OnAnyDead;

    public event EventHandler OnHealthChanged;
    
    private int health;
    private int healthMax;

    public void ApplyDamage(int damage)
    {
        health -= damage;
        OnHealthChanged.Invoke(this, EventArgs.Empty);
        if (health <= 0)
        {
            OnAnyDead.Invoke();
        }
    }

    public void RecoverHealth(int recoveringHealth)
    {
        health += recoveringHealth;
        
        OnHealthChanged.Invoke(this, EventArgs.Empty);
    }
    
}

/*
 * IParameter
 *
 * OnChanged
 *
 * Change
 *
 * 
 */
