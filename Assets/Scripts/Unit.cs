using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public event Action OnAttackEnded; 
    public static event Action OnAnyDead;
    
    [SerializeField] private int health = 100;
    [SerializeField] private int damage = 15;

    public bool IsTurn;
    
    public void Initialize()
    {
        health = 100;
    }

    public void ApplyDamage(int damage)
    {
        health = Mathf.Max(health - damage, 0);
        if (health <= 0)
        {
            Debug.Log(gameObject + " dead!");
            OnAnyDead?.Invoke();
        }
    }

    public void Attack(Unit target)
    {
        if (IsTurn){} else return;

        IsTurn = false;
        
        target.ApplyDamage(damage);
        OnAttackEnded?.Invoke();
    }
}
